using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillsForm : Form
    {
        public BillsForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true; ";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    SELECT ID, Name,TableID, Amount, Discount,Tax,Status,CheckoutDate,Account
                    FROM Bills
                    WHERE CheckoutDate >= @From AND CheckoutDate <= @To";
                sqlCommand.Parameters.AddWithValue("@From", dtpFrom.Value.Date);
                sqlCommand.Parameters.AddWithValue("@To", dtpTo.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);              
                dgvBills.DataSource = dt;

                // Tính tổng
                decimal total = 0, totalDiscount = 0, net = 0;
                foreach (DataRow row in dt.Rows)
                {
                    decimal amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0;
                    decimal discount = row["Discount"] != DBNull.Value ? Convert.ToDecimal(row["Discount"]) : 0;
                    decimal tax = row["Tax"] != DBNull.Value ? Convert.ToDecimal(row["Tax"]) : 0;

                    total += amount;
                    decimal discountMoney = amount * discount;
                    totalDiscount += discountMoney;
                    decimal netAmount = (amount - discountMoney) * (1 + tax);
                    net += netAmount;

                    //Tổng giảm giá = Amount * Discount
                    //Thực thu = (Amount - Tổng giảm giá) * (1 + Tax)
                }
                lblTotal.Text = $"Tổng tiền chưa giảm giá: {total:N0} VNĐ";
                lblDiscount.Text = $"Tổng giảm giá: {totalDiscount:N0} VNĐ";
                lblNet.Text = $"Thực thu: {net:N0} VNĐ";
            }
        }

        private void dgvBills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBills.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                bool status = false;
                // Xử lý kiểu bool hoặc số
                if (e.Value is bool)
                    status = (bool)e.Value;
                else if (e.Value is int)
                    status = (int)e.Value != 0;
                else
                {
                    string statusStr = e.Value.ToString().Trim();
                    status = statusStr == "1" || statusStr.Equals("True", StringComparison.OrdinalIgnoreCase);
                }
                e.Value = status ? "Bàn có khách" : "Trống";
                e.FormattingApplied = true;
            }
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua header
            var billIdObj = dgvBills.Rows[e.RowIndex].Cells["ID"].Value;
            if (billIdObj == null) return;
            int billId = Convert.ToInt32(billIdObj);

            BillDetailsForm detailsForm = new BillDetailsForm();
            detailsForm.LoadBillDetails(billId);
            detailsForm.ShowDialog();
        }
    }
}
