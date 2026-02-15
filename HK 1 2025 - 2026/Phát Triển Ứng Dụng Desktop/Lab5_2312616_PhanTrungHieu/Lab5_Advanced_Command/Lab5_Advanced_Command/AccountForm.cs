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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
            LoadAccount();
        }

        private void LoadAccount()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT AccountName, FullName, Password, Email, Tell, DateCreated FROM Account";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                dgvAccounts.DataSource = dt;
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            using (AddRoleForm addRoleForm = new AddRoleForm())
            {
                addRoleForm.ShowDialog();
                // Sau khi thêm vai trò, có thể load lại danh sách vai trò nếu cần
            }
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Account (AccountName, Password, FullName, Email, Tell, DateCreated) VALUES (@name, @pass, @full, @email, @tell, @date)";
                cmd.Parameters.AddWithValue("@name", txtAccountName.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@full", txtFullName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@tell", mtbTell.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                conn.Open();
                // Trước khi thêm mới
                SqlCommand checkCmd = conn.CreateCommand();
                checkCmd.CommandText = "SELECT COUNT(*) FROM Account WHERE AccountName = @name";
                checkCmd.Parameters.AddWithValue("@name", txtAccountName.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại!");
                    return;
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadAccount(); // Load lại danh sách tài khoản
                ResetAccountFields(); // Xóa trắng các ô nhập
            }
        }

        private void ResetAccountFields()
        {
            txtAccountName.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            mtbTell.Text = "";
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn tài khoản chưa
            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật!", "Thông báo");
                return;
            }

            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE Account SET 
                                Password = @pass, 
                                FullName = @full, 
                                Email = @email, 
                                Tell = @tell
                            WHERE AccountName = @name";
                cmd.Parameters.AddWithValue("@name", txtAccountName.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@full", txtFullName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@tell", mtbTell.Text);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Cập nhật tài khoản thành công!");
                else
                    MessageBox.Show("Không tìm thấy tài khoản để cập nhật!");
                LoadAccount();
                ResetAccountFields();
            }
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];
                txtAccountName.Text = row.Cells["AccountName"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                mtbTell.Text = row.Cells["Tell"].Value.ToString();
                txtAccountName.Enabled = false; // Không cho sửa tên tài khoản
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần reset mật khẩu!");
                return;
            }

            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Account SET Password = @pass WHERE AccountName = @name";
                cmd.Parameters.AddWithValue("@name", txtAccountName.Text);
                cmd.Parameters.AddWithValue("@pass", "123456"); // Mật khẩu mặc định

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Đã reset mật khẩu về 123456!");
                else
                    MessageBox.Show("Không tìm thấy tài khoản để reset!");
                LoadAccount();
                ResetAccountFields();
            }
        }

        private void tsmiViewRoles_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();
                RoleListForm roleForm = new RoleListForm(accountName);
                roleForm.ShowDialog();
            }
        }

        private void tsmiViewLog_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count > 0)
            {
                string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();
                AccountLogForm logForm = new AccountLogForm(accountName);
                logForm.ShowDialog();
            }
        }
    }
}
