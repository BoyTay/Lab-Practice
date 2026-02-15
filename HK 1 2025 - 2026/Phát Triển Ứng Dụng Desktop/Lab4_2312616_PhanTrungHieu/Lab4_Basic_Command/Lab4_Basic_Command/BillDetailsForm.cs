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
    public partial class BillDetailsForm : Form
    {
        public BillDetailsForm()
        {
            InitializeComponent();
        }
        public void LoadBillDetails(int invoiceId)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true; ";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    SELECT BillDetails.ID, BillDetails.InvoiceID, BillDetails.FoodID, Food.Name AS [Tên món], BillDetails.Quantity
                    FROM BillDetails
                    JOIN Food ON BillDetails.FoodID = Food.ID
                    WHERE BillDetails.InvoiceID = @InvoiceID";
                sqlCommand.Parameters.AddWithValue("@InvoiceID", invoiceId);

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDetails.DataSource = dt;
            }
        }
       
    }
}
