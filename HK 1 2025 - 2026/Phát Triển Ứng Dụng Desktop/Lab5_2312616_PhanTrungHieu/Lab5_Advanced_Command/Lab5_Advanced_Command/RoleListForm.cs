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
    public partial class RoleListForm : Form
    {
        private string accountName;
        // Helper class để hiển thị vai trò
        public class RoleItem
        {
            public int RoleID { get; set; }
            public string RoleName { get; set; }
            public override string ToString() => RoleName;
        }
        public RoleListForm(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
            LoadRoles();
        }
        private void LoadRoles()
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Lấy tất cả vai trò
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, RoleName FROM Role";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtRoles = new DataTable();
                conn.Open();
                adapter.Fill(dtRoles);

                // Lấy các vai trò đã gán cho tài khoản
                SqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandText = "SELECT RoleID FROM RoleAccount WHERE AccountName = @accountName";
                cmd2.Parameters.AddWithValue("@accountName", accountName);
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                DataTable dtAccountRoles = new DataTable();
                adapter2.Fill(dtAccountRoles);

                clbRoles.Items.Clear();
                foreach (DataRow row in dtRoles.Rows)
                {
                    int idx = clbRoles.Items.Add(new RoleItem
                    {
                        RoleID = Convert.ToInt32(row["ID"]),
                        RoleName = row["RoleName"].ToString()
                    });

                    // Check nếu tài khoản đã có vai trò này
                    foreach (DataRow accRole in dtAccountRoles.Rows)
                    {
                        if (Convert.ToInt32(accRole["RoleID"]) == Convert.ToInt32(row["ID"]))
                        {
                            clbRoles.SetItemChecked(idx, true);
                            break;
                        }
                    }
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (AddRoleForm addRoleForm = new AddRoleForm())
            {
                if (addRoleForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRoles();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Xóa hết vai trò cũ
                SqlCommand cmdDelete = conn.CreateCommand();
                cmdDelete.CommandText = "DELETE FROM RoleAccount WHERE AccountName = @accountName";
                cmdDelete.Parameters.AddWithValue("@accountName", accountName);
                cmdDelete.ExecuteNonQuery();

                // Thêm lại các vai trò được check
                foreach (var item in clbRoles.CheckedItems)
                {
                    var role = item as RoleItem;
                    SqlCommand cmdInsert = conn.CreateCommand();
                    cmdInsert.CommandText = "INSERT INTO RoleAccount (RoleID, AccountName, Actived) VALUES (@roleID, @accountName, 1)";
                    cmdInsert.Parameters.AddWithValue("@roleID", role.RoleID);
                    cmdInsert.Parameters.AddWithValue("@accountName", accountName);
                    cmdInsert.ExecuteNonQuery();
                }
                MessageBox.Show("Cập nhật vai trò thành công!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
