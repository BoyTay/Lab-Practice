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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadTables();
        }

        private void LoadTables()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM [Table]";
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTables.DataSource = dt;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                INSERT INTO [Table] (Name, Status, Capacity)
                VALUES (@Name, 0, @Capacity)";
                sqlCommand.Parameters.AddWithValue("@Name", txtNameTable.Text);
                sqlCommand.Parameters.AddWithValue("@Capacity", Convert.ToInt32(txtCapacity.Text));
                int result = sqlCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0 ? "Thêm bàn thành công!" : "Thêm thất bại!");
                LoadTables();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                UPDATE [Table] SET Name = @Name, Capacity = @Capacity
                WHERE ID = @ID";
                sqlCommand.Parameters.AddWithValue("@Name", txtNameTable.Text);
                sqlCommand.Parameters.AddWithValue("@Capacity", Convert.ToInt32(txtCapacity.Text));
                sqlCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(txtTableID.Text));
                int result = sqlCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0 ? "Cập nhật thành công!" : "Cập nhật thất bại!");
                LoadTables();
            }
        }

        private void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvTables.Rows[e.RowIndex];
            txtTableID.Text = row.Cells["ID"].Value?.ToString();
            txtNameTable.Text = row.Cells["TableName"].Value?.ToString();
            txtCapacity.Text = row.Cells["Capacity"].Value?.ToString();
            // Nếu có thêm trạng thái:
            // txtStatus.Text = row.Cells["Status"].Value?.ToString();
            txtTableID.Enabled = false;
            if (dgvTables.SelectedRows.Count == 0) return;
            int tableId = Convert.ToInt32(dgvTables.SelectedRows[0].Cells["ID"].Value);
            BillListForm billListForm = new BillListForm(tableId);
            billListForm.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM [Table] WHERE ID = @ID";
                sqlCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(txtTableID.Text));
                int result = sqlCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0 ? "Xóa bàn thành công!" : "Xóa thất bại!");
                LoadTables();
            }
        }

        private void dgvTables_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvTables.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvTables.ClearSelection();
                    dgvTables.Rows[hit.RowIndex].Selected = true;
                }
            }
        }

        private void tsmiXoaBan_Click(object sender, EventArgs e)
        {
            if (dgvTables.SelectedRows.Count == 0) return;
            int tableId = Convert.ToInt32(dgvTables.SelectedRows[0].Cells["ID"].Value);

            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "DELETE FROM [Table] WHERE ID = @ID";
                sqlCommand.Parameters.AddWithValue("@ID", tableId);
                int result = sqlCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0 ? "Xóa bàn thành công!" : "Xóa thất bại!");
                LoadTables();
            }
        }

        private void tsmiDanhMucHD_Click(object sender, EventArgs e)
        {
            if (dgvTables.SelectedRows.Count == 0) return;
            int tableId = Convert.ToInt32(dgvTables.SelectedRows[0].Cells["ID"].Value);
            BillListForm billListForm = new BillListForm(tableId);
            billListForm.ShowDialog();
        }

        private void tsmiNhatKyHD_Click(object sender, EventArgs e)
        {
            if (dgvTables.SelectedRows.Count == 0) return;
            int tableId = Convert.ToInt32(dgvTables.SelectedRows[0].Cells["ID"].Value);
            BillLogForm billLogForm = new BillLogForm(tableId);
            billLogForm.ShowDialog();
        }
    }
}
