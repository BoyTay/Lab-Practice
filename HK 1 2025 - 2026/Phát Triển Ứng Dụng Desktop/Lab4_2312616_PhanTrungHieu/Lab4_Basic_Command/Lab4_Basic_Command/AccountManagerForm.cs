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
    public partial class AccountManagerForm : Form
    {
        public AccountManagerForm()
        {
            InitializeComponent();
            LoadAccounts(null, null);
            LoadRoles();
        }
        private void LoadAccounts(string roleFilter, bool? activeFilter)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                 SELECT a.AccountName, a.Password, a.FullName, a.Email, a.Tell, a.DateCreated,
                   CASE WHEN ra.Actived = 1 THEN N'Kích hoạt' ELSE N'Không kích hoạt' END AS Status,
                   ra.RoleID
                 FROM Account a
                 LEFT JOIN RoleAccount ra ON a.AccountName = ra.AccountName
                 LEFT JOIN Role r ON ra.RoleID = r.ID
                 WHERE (@RoleFilter IS NULL OR r.RoleName = @RoleFilter)
                 AND (@ActiveFilter IS NULL OR ra.Actived = @ActiveFilter)";
                sqlCommand.Parameters.AddWithValue("@RoleFilter", string.IsNullOrEmpty(roleFilter) ? (object)DBNull.Value : roleFilter);
                sqlCommand.Parameters.AddWithValue("@ActiveFilter", activeFilter.HasValue ? (object)(activeFilter.Value ? 1 : 0) : DBNull.Value);

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAccounts.DataSource = dt;
            }
        }

        private void LoadRoles()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT RoleName FROM Role";
                SqlDataReader reader = sqlCommand.ExecuteReader();
                cbbRole.Items.Clear();
                cbbRole.Items.Add(""); // Cho phép chọn tất cả
                while (reader.Read())
                {
                    cbbRole.Items.Add(reader["RoleName"].ToString());
                }
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string selectedRole = cbbRole.SelectedItem?.ToString();
            bool? active = null;
            if (cbActive.CheckState == CheckState.Checked)
                active = true;
            else if (cbActive.CheckState == CheckState.Unchecked)
                active = false;
            // Nếu CheckState là Indeterminate thì active = null (lọc tất cả)

            LoadAccounts(selectedRole, active);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // Kiểm tra trùng tên tài khoản
                SqlCommand checkCmd = sqlConnection.CreateCommand();
                checkCmd.CommandText = "SELECT COUNT(*) FROM Account WHERE AccountName = @AccountName";
                checkCmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng chọn tên tài khoản khác!");
                    return;
                }

                // Thêm mới nếu không trùng
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    INSERT INTO Account (AccountName, Password, FullName, Email, Tell, DateCreated)
                    VALUES (@AccountName, @Password, @FullName, @Email, @Tell, GETDATE())";
                sqlCommand.Parameters.AddWithValue("@AccountName", txtAccountName.Text);
                sqlCommand.Parameters.AddWithValue("@Password", txtPassword.Text);
                sqlCommand.Parameters.AddWithValue("@FullName", txtFullName.Text);
                sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                sqlCommand.Parameters.AddWithValue("@Tell", mtbTell.Text);

                int result = sqlCommand.ExecuteNonQuery();

                // Thêm vai trò và trạng thái kích hoạt vào RoleAccount nếu chọn
                string roleName = cbbRole.SelectedItem?.ToString();
                bool actived = cbActive.Checked;
                if (!string.IsNullOrEmpty(roleName))
                {
                    // Lấy RoleID từ RoleName
                    SqlCommand getRoleIdCmd = sqlConnection.CreateCommand();
                    getRoleIdCmd.CommandText = "SELECT ID FROM Role WHERE RoleName = @RoleName";
                    getRoleIdCmd.Parameters.AddWithValue("@RoleName", roleName);
                    object roleIdObj = getRoleIdCmd.ExecuteScalar();
                    if (roleIdObj != null)
                    {
                        int roleId = Convert.ToInt32(roleIdObj);
                        SqlCommand addRoleCmd = sqlConnection.CreateCommand();
                        addRoleCmd.CommandText = @"
                            INSERT INTO RoleAccount (RoleID, AccountName, Actived)
                            VALUES (@RoleID, @AccountName, @Actived)";
                        addRoleCmd.Parameters.AddWithValue("@RoleID", roleId);
                        addRoleCmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text);
                        addRoleCmd.Parameters.AddWithValue("@Actived", actived ? 1 : 0);
                        addRoleCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(result > 0 ? "Thêm tài khoản thành công!" : "Thêm thất bại!");
                LoadAccounts(null, null);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // Kiểm tra tài khoản có tồn tại không
                SqlCommand checkCmd = sqlConnection.CreateCommand();
                checkCmd.CommandText = "SELECT COUNT(*) FROM Account WHERE AccountName = @AccountName";
                checkCmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                    return;
                }

                // Cập nhật thông tin
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    UPDATE Account
                    SET FullName = @FullName, Email = @Email, Tell = @Tell
                    WHERE AccountName = @AccountName";
                sqlCommand.Parameters.AddWithValue("@FullName", txtFullName.Text);
                sqlCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                sqlCommand.Parameters.AddWithValue("@Tell", mtbTell.Text);
                sqlCommand.Parameters.AddWithValue("@AccountName", txtAccountName.Text);

                int result = sqlCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0 ? "Cập nhật thành công!" : "Cập nhật thất bại!");
                LoadAccounts(null, null);
            }
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua header
            DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];

            txtAccountName.Text = row.Cells["AccountName"].Value?.ToString();
            txtPassword.Text = row.Cells["Password"].Value?.ToString();
            txtFullName.Text = row.Cells["FullName"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            mtbTell.Text = row.Cells["Tell"].Value?.ToString();

            // Lấy RoleID và truy vấn tên vai trò từ bảng Role
            string roleIdStr = row.Cells["RoleID"].Value?.ToString();
            string roleName = "";
            if (!string.IsNullOrEmpty(roleIdStr))
            {
                string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand cmd = sqlConnection.CreateCommand();
                    cmd.CommandText = "SELECT RoleName FROM Role WHERE ID = @RoleID";
                    cmd.Parameters.AddWithValue("@RoleID", roleIdStr);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        roleName = result.ToString();
                }
            }
            cbbRole.SelectedItem = roleName;
            // Hiển thị trạng thái kích hoạt
            cbActive.Checked = row.Cells["Status"].Value?.ToString() == "Kích hoạt";


            btnThem.Enabled = false; // Không cho phép thêm khi đang chọn 1 tài khoản
            cbbRole.Enabled = false;
            cbActive.Enabled = false;
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // Kiểm tra tài khoản có tồn tại không
                SqlCommand checkCmd = sqlConnection.CreateCommand();
                checkCmd.CommandText = "SELECT COUNT(*) FROM Account WHERE AccountName = @AccountName";
                checkCmd.Parameters.AddWithValue("@AccountName", txtAccountName.Text);
                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại!");
                    return;
                }

                // Reset mật khẩu về giá trị mặc định (ví dụ: "123456")
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                UPDATE Account SET Password = '123456'
                WHERE AccountName = @AccountName";
                sqlCommand.Parameters.AddWithValue("@AccountName", txtAccountName.Text);

                int result = sqlCommand.ExecuteNonQuery();
                MessageBox.Show(result > 0 ? "Đã reset mật khẩu về 123456!" : "Reset thất bại!");
                LoadAccounts(null, null);
            }
        }

        private void dgvAccounts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvAccounts.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvAccounts.ClearSelection();
                    dgvAccounts.Rows[hit.RowIndex].Selected = true;
                }
            }
        }

        private void tsmiDeleteAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0) return;
            string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();

            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "UPDATE RoleAccount SET Actived = 0 WHERE AccountName = @AccountName";
                sqlCommand.Parameters.AddWithValue("@AccountName", accountName);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Đã xóa tài khoản (đánh dấu vai trò không kích hoạt)!");
                LoadAccounts(null, null);
            }
        }

        private void tsmiViewRoles_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0) return;
            string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();

            AccountRolesForm rolesForm = new AccountRolesForm();
            rolesForm.LoadRoles(accountName);
            rolesForm.ShowDialog();
        }
    }
}
