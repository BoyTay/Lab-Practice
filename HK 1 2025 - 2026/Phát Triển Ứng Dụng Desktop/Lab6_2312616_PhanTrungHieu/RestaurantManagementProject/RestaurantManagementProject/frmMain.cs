using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagementProject
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            bool isAdmin = Authorization.IsInRole(RoleNames.Admin);
            bool isQuanLy = Authorization.IsInRole(RoleNames.QuanLy);
            bool isKeToan = Authorization.IsInRole(RoleNames.KeToan);

            btnRole.Enabled = isAdmin;
            btnRoleAccount.Enabled = isAdmin;
            btnFood.Enabled = isAdmin || isQuanLy;
            btnCategory.Enabled = isAdmin || isQuanLy;
            btnBills.Enabled = isAdmin || isQuanLy || isKeToan;
            btnBillDetails.Enabled = isAdmin || isQuanLy || isKeToan;
            btnAccount.Enabled = isAdmin;

            lblCurrentUser.Text = "Xin chào " + Authorization.CurrentAccountName +
                      " (" + string.Join(", ", Authorization.CurrentRoles()) + ")";

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Authorization.SignOut();
            var login = new frmLogin();
            login.Show();
            Close();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            frmFood frmFood = new frmFood();
            frmFood.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmCategory frmCategory = new frmCategory();
            frmCategory.Show();
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            frmBills frmBills = new frmBills();
            frmBills.Show();
        }

        private void btnBillDetails_Click(object sender, EventArgs e)
        {
            frmBillDetails frmBillDetails = new frmBillDetails();
            frmBillDetails.Show();
        }

        private void btnRoleAccount_Click(object sender, EventArgs e)
        {
            frmRoleAccount frmRoleAccount = new frmRoleAccount();   
            frmRoleAccount.Show();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            frmRole frmRole = new frmRole();
            frmRole.Show();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            frmAccount frmAccount = new frmAccount();
            frmAccount.Show();
        }

    }
}
