using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab4_Basic_Command
{
    public partial class BillLogForm : Form
    {
        private int tableId;
        public BillLogForm(int tableId)
        {
            InitializeComponent();
            this.tableId = tableId;
            LoadBillLog();
        }

        private void LoadBillLog()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    SELECT ID AS MaHoaDon, Amount AS TongTien, Tax AS Thue, Discount AS GiamGia, 
                           CheckoutDate AS NgayLap, Account AS NhanVienLap
                    FROM Bills
                    WHERE TableID = @TableID";
                sqlCommand.Parameters.AddWithValue("@TableID", tableId);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBillLog.DataSource = dt;

                // Hiển thị số lượng hóa đơn
                lblSoLuongHoaDon.Text = "Số lượng hóa đơn: " + dt.Rows.Count.ToString();
            }
        }
    }
}
