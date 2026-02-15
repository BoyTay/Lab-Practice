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
    public partial class AccountRolesForm : Form
    {
        public AccountRolesForm()
        {
            InitializeComponent();
        }

        public void LoadRoles(string accountName)
        {
            string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = @"
                    SELECT r.RoleName, ra.Actived, ra.Notes
                    FROM RoleAccount ra
                    JOIN Role r ON ra.RoleID = r.ID
                    WHERE ra.AccountName = @AccountName";
                sqlCommand.Parameters.AddWithValue("@AccountName", accountName);

                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvRoles.DataSource = dt;
            }
        }
    }
}
