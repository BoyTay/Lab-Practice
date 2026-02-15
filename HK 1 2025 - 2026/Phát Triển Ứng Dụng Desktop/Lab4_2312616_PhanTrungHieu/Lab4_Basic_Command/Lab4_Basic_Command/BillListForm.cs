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
    public partial class BillListForm : Form
    {
        private int tableId;
        public BillListForm(int tableId)
        {
            InitializeComponent();
            this.tableId = tableId;
            LoadBillDates();
        }

        private void LoadBillDates()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT ID, CheckoutDate FROM Bills WHERE TableID = @TableID";
                sqlCommand.Parameters.AddWithValue("@TableID", tableId);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                lbBillDates.Items.Clear();
                while (reader.Read())
                {
                    lbBillDates.Items.Add(new { BillID = reader["ID"], Date = reader["CheckoutDate"] });
                }
            }
        }

        private void lbBillDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBillDates.SelectedItem == null) return;
            dynamic selected = lbBillDates.SelectedItem;
            int billId = (int)selected.BillID;

            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                SELECT Food.Name, BillDetails.Quantity
                FROM BillDetails
                JOIN Food ON BillDetails.FoodID = Food.ID
                WHERE BillDetails.InvoiceID = @BillID";
                sqlCommand.Parameters.AddWithValue("@BillID", billId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBillDetails.DataSource = dt;
            }
        }
    }
}
