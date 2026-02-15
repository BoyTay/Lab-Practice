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
    public partial class OrderDetailsForm : Form
    {
        private int billID;
        public OrderDetailsForm(int billID)
        {
            InitializeComponent();
            this.billID = billID;
            LoadOrderDetails();
        }
        private void LoadOrderDetails()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true; ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT f.Name, bd.Quantity, f.Unit, f.Price, (bd.Quantity * f.Price) AS Amount
                    FROM BillDetails bd
                    JOIN Food f ON bd.FoodID = f.ID
                    WHERE bd.InvoiceID = @billID";
                cmd.Parameters.Add("@billID", SqlDbType.Int).Value = billID;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                dgvOrderDetails.DataSource = dt;
            }
        }
    }
}
