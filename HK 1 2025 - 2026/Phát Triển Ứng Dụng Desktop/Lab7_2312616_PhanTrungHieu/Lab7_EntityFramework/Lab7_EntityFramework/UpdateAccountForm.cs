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
    public partial class UpdateAccountForm : Form
    {
        private readonly string _accountName;
        private RestaurantContext _db;
        public UpdateAccountForm(string accountName = null)
        {
            InitializeComponent();
            _accountName = accountName;
        }

        private void UpdateAccountForm_Load(object sender, EventArgs e)
        {
            _db = new RestaurantContext();
        }

        private void LoadRoles()
        {
            clbRoles.Items.Clear();
            var roles = _db.Roles.OrderBy(r => r.RoleName).ToList();
            foreach (var r in roles)
            {
                clbRoles.Items.Add(r.RoleName, false);
            }
        }

        private Account GetAccount() =>
            _accountName == null ? null : _db.Accounts.Find(_accountName);

        private void ShowAccount()
        {
            var acc = GetAccount();
            if (acc == null) return;

            txtAccountName.Text = acc.AccountName;
            txtAccountName.ReadOnly = true;
            txtFullName.Text = acc.FullName;
            txtEmail.Text = acc.Email;
            mtbTell.Text = acc.Tell;
            txtPassword.Text = acc.Password; // chỉ hiển thị để biết, có thể để rỗng

            var activeRoles = acc.RoleAccounts.Where(ra => ra.Actived)
                                              .Select(ra => ra.Role.RoleName).ToHashSet();

            for (int i = 0; i < clbRoles.Items.Count; i++)
            {
                var roleName = clbRoles.Items[i].ToString();
                if (activeRoles.Contains(roleName))
                    clbRoles.SetItemChecked(i, true);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                MessageBox.Show("AccountName không được rỗng");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var acc = GetAccount();
            bool isNew = acc == null;

            if (isNew)
            {
                acc = new Account
                {
                    AccountName = txtAccountName.Text.Trim(),
                    Password = string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text,
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Tell = mtbTell.Text.Trim(),
                    DateCreated = DateTime.Now
                };
                _db.Accounts.Add(acc);
            }
            else
            {
                acc.FullName = txtFullName.Text.Trim();
                acc.Email = txtEmail.Text.Trim();
                acc.Tell = mtbTell.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    acc.Password = txtPassword.Text;
            }

            // Cập nhật RoleAccounts
            var checkedRoles = clbRoles.CheckedItems.Cast<string>().ToList();
            var allRoles = _db.Roles.ToList();

            // Tạo hoặc cập nhật
            foreach (var role in allRoles)
            {
                var existing = acc.RoleAccounts.FirstOrDefault(ra => ra.RoleId == role.Id);
                bool shouldActive = checkedRoles.Contains(role.RoleName);
                if (existing == null && shouldActive)
                {
                    acc.RoleAccounts.Add(new RoleAccount
                    {
                        RoleId = role.Id,
                        AccountName = acc.AccountName,
                        Actived = true
                    });
                }
                else if (existing != null)
                {
                    existing.Actived = shouldActive;
                }
            }

            _db.SaveChanges();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
