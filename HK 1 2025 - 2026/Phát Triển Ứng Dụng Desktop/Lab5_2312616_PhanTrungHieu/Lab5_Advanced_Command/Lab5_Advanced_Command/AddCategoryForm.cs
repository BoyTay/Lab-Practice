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
    public partial class AddCategoryForm : Form
    {
        public int NewCategoryID { get;private set; }
        public string NewCategoryName { get;private set; }
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=HIEUPHAN\\SQLEXPRESS; database = Restaurant Management; Integrated Security = true; ";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "EXEC InsertCategory @id OUTPUT, @name, @type";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000).Value = txtCatName.Text;
                    cmd.Parameters.Add("@type", SqlDbType.Int).Value = nudCatType.Value;
                    

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    NewCategoryID = (int)cmd.Parameters["@id"].Value;
                    NewCategoryName = txtCatName.Text;

                    MessageBox.Show("Added new category successfully!", "Message");
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
