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
    public partial class AddRoleForm : Form
    {
        public AddRoleForm()
        {
            InitializeComponent();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Role (RoleName, Path, Notes) VALUES (@name, @path, @notes)";
                cmd.Parameters.AddWithValue("@name", txtRoleName.Text);
                cmd.Parameters.AddWithValue("@path", txtPath.Text);
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm vai trò thành công!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
