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
    public partial class AccountLogForm : Form
    {
        private string accountName;
        public AccountLogForm(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            LoadDates();
            LoadSummary();

        }
        private void LoadDates()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT DISTINCT CAST(CheckoutDate AS DATE) AS Ngay
                    FROM Bills
                    WHERE Account = @accountName
                    ORDER BY Ngay";
                cmd.Parameters.AddWithValue("@accountName", accountName);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                lbDates.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    lbDates.Items.Add(Convert.ToDateTime(row["Ngay"]).ToString("yyyy-MM-dd"));
                }
            }
        }

        private void lbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDates.SelectedItem == null) return;
            string selectedDate = lbDates.SelectedItem.ToString();
            LoadBillsByDate(selectedDate);
        }

        private void LoadBillsByDate(string date)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT b.ID, b.Amount, b.Discount, b.CheckoutDate, f.Name AS FoodName, bd.Quantity, f.Price
                    FROM Bills b
                    JOIN BillDetails bd ON b.ID = bd.InvoiceID
                    JOIN Food f ON bd.FoodID = f.ID
                    WHERE b.Account = @accountName AND CAST(b.CheckoutDate AS DATE) = @date";
                cmd.Parameters.AddWithValue("@accountName", accountName);
                cmd.Parameters.AddWithValue("@date", date);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                dgvBills.DataSource = dt;
            }
        }

        private void LoadSummary()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT COUNT(*) AS TotalBills, ISNULL(SUM(Amount),0) AS TotalAmount
                    FROM Bills
                    WHERE Account = @accountName";
                cmd.Parameters.AddWithValue("@accountName", accountName);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblTotalBills.Text = "Số lượng hóa đơn: " + reader["TotalBills"].ToString();
                        lblTotalAmount.Text = "Tổng tiền: " + Convert.ToDecimal(reader["TotalAmount"]).ToString("N0");
                    }
                }
            }
        }
    }
}
