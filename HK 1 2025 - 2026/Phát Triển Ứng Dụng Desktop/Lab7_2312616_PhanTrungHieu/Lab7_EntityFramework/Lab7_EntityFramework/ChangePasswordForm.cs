using Lab7_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_EntityFramework
{
    public partial class ChangePasswordForm : Form
    {
        private readonly string _accountName;
        private RestaurantContext _db;
        public ChangePasswordForm(string accountName)
        {
            InitializeComponent();
            _accountName = accountName;
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            _db = new RestaurantContext();
            txtAccount.Text = _accountName;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                txtNewPassword.Text != txtConfirm.Text)
            {
                MessageBox.Show("Mật khẩu không hợp lệ hoặc xác nhận sai.");
                return;
            }
            var acc = _db.Accounts.Find(_accountName);
            if (acc == null) return;
            acc.Password = txtNewPassword.Text;
            _db.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
