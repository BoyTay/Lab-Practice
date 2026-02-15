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
    public partial class FoodForm : Form
    {
        private int currentCategoryID = -1;

        public FoodForm()
        {
            InitializeComponent();
        }

        public void LoadFood(int categoryID)
        {
            currentCategoryID = categoryID;
            //Tạo đối tượng kết nối
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true; ";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //Thiết lập lệnh truy vấn cho đối tượng Command
            sqlCommand.CommandText = "SELECT Name FROM Category where ID = " + categoryID;

            //Mở kết nối tới cơ sở dữ liệu
            sqlConnection.Open();

            //Gán tên nhóm sản phẩm cho tiêu đề
            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;
            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + categoryID;

            //Tạo đối tượng DataAdapter
            SqlDataAdapter da =new SqlDataAdapter(sqlCommand);

            //Tạo DataTable để chứa dữ liệu
            DataTable dt = new DataTable("Food");
            da.Fill(dt);

            //Hiển thị danh sách món ăn lên form
            dgvFood.DataSource=dt;

            //Đóng kết nối và giải phóng bộ nhớ
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy dòng đang chọn
            if (dgvFood.CurrentRow == null) return;
            DataGridViewRow row = dgvFood.CurrentRow;

            // Lấy thông tin từ dòng
            string id = row.Cells["Column1"].Value?.ToString();
            string name = row.Cells["Column2"].Value?.ToString();
            string unit = row.Cells["Column3"].Value?.ToString();
            string categoryId = row.Cells["Column4"].Value?.ToString();
            string price = row.Cells["Column5"].Value?.ToString();
            string notes = row.Cells["Column6"].Value?.ToString();

            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true; ";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                if (string.IsNullOrEmpty(id)) // Thêm mới
                {
                    sqlCommand.CommandText = "INSERT INTO Food (Name, Unit, FoodCategoryID, Price, Notes) VALUES (@Name, @Unit, @FoodCategoryID, @Price, @Notes)";
                }
                else // Sửa
                {
                    sqlCommand.CommandText = "UPDATE Food SET Name=@Name, Unit=@Unit, FoodCategoryID=@FoodCategoryID, Price=@Price, Notes=@Notes WHERE ID=@ID";
                    sqlCommand.Parameters.AddWithValue("@ID", id);
                }
                sqlCommand.Parameters.AddWithValue("@Name", name ?? "");
                sqlCommand.Parameters.AddWithValue("@Unit", unit ?? "");
                sqlCommand.Parameters.AddWithValue("@FoodCategoryID", categoryId ?? "");
                sqlCommand.Parameters.AddWithValue("@Price", price ?? "0");
                sqlCommand.Parameters.AddWithValue("@Notes", notes ?? "");

                int result = sqlCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0 ? "Lưu thành công!" : "Lưu thất bại!");

                // Tải lại dữ liệu
                LoadFood(currentCategoryID);              
            }
        }

        private void dgvFood_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Column4"].Value = currentCategoryID; // Gán mã nhóm tự động
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFood.CurrentRow == null) return;
            DataGridViewRow row = dgvFood.CurrentRow;
            string id = row.Cells["Column1"].Value?.ToString();
            string categoryId = row.Cells["Column4"].Value?.ToString();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn món ăn có ID để xóa!");
                return;
            }

            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true; ";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM Food WHERE ID=@ID";
                sqlCommand.Parameters.AddWithValue("@ID", id);

                int result = sqlCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0 ? "Xóa thành công!" : "Xóa thất bại!");

                // Tải lại dữ liệu
                if (!string.IsNullOrEmpty(categoryId))
                    LoadFood(int.Parse(categoryId));
            }
        }
    }
}
