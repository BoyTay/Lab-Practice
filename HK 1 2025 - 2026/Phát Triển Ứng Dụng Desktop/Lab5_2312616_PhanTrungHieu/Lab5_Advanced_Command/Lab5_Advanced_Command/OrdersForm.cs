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

namespace Lab5_Advanced_Command
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true; ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT ID, Name, TableID, CheckoutDate, Amount, Discount,Account
                    FROM Bills
                    WHERE CheckoutDate >= @from AND CheckoutDate <= @to";
                cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = dtpFrom.Value.Date;
                cmd.Parameters.Add("@to", SqlDbType.DateTime).Value = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                dgvOrders.DataSource = dt;

                // Tính tổng tiền, giảm giá, thực thu
                decimal total = 0, discountAmount = 0, revenue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    decimal amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0;
                    decimal discountPercent = row["Discount"] != DBNull.Value ? Convert.ToDecimal(row["Discount"]) : 0;
                    decimal discountValue = amount * discountPercent / 100;
                    total += amount;
                    discountAmount += discountValue;
                    revenue += (amount - discountValue);
                }
                txtTotal.Text = total.ToString("N0");
                txtDiscount.Text = discountAmount.ToString("N0");
                txtRevenue.Text = revenue.ToString("N0");
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy BillID từ dòng được nhấp
                int billID = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["ID"].Value);
                // Mở form chi tiết hóa đơn
                OrderDetailsForm detailsForm = new OrderDetailsForm(billID);
                detailsForm.ShowDialog();
            }
        }
    }
}
