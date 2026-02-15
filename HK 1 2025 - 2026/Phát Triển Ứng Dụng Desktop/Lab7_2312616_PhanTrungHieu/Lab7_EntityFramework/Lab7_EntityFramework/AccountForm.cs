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
    public partial class AccountForm : Form
    {
        private RestaurantContext _db;
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            _db = new RestaurantContext();
            LoadRoleFilter();
            ShowAccounts();
        }
        private void LoadRoleFilter()
        {
            var roles = _db.Roles
                .OrderBy(r => r.RoleName)
                .Select(r => new { r.Id, r.RoleName })
                .ToList();

            cbbRoleFilter.Items.Clear();
            cbbRoleFilter.Items.Add("(Tất cả)");
            foreach (var r in roles)
                cbbRoleFilter.Items.Add(r.RoleName);

            cbbRoleFilter.SelectedIndex = 0;
        }
        private List<AccountModel> GetAccounts(string roleNameFilter, string keyword)
        {
            keyword = (keyword ?? "").Trim().ToLower();

            var query = _db.Accounts.AsQueryable();

            // Filter by keyword (AccountName hoặc FullName)
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(a =>
                    a.AccountName.ToLower().Contains(keyword) ||
                    (a.FullName != null && a.FullName.ToLower().Contains(keyword)));
            }
            // Filter by role
            if (!string.IsNullOrEmpty(roleNameFilter) && roleNameFilter != "(Tất cả)")
            {
                query = query.Where(a =>
                    a.RoleAccounts.Any(ra => ra.Role.RoleName == roleNameFilter && ra.Actived));
            }

            // Sửa: chuyển Roles sang join ở client sau AsEnumerable()
            var accounts = query
                .OrderBy(a => a.AccountName)
                .Select(a => new
                {
                    a.AccountName,
                    a.FullName,
                    a.Email,
                    a.Tell,
                    Active = a.Password != null && a.RoleAccounts.Any(ra => ra.Actived),
                    RoleNames = a.RoleAccounts
                                .Where(ra => ra.Actived)
                                .Select(ra => ra.Role.RoleName)
                })
                .AsEnumerable() // từ đây chạy trên bộ nhớ
                .Select(a => new AccountModel
                {
                    AccountName = a.AccountName,
                    FullName = a.FullName,
                    Email = a.Email,
                    Tell = a.Tell,
                    Active = a.Active,
                    Roles = string.Join(",", a.RoleNames)
                })
                .ToList();

            return accounts;
        }
        private void ShowAccounts()
        {
            lvwAccount.Items.Clear();
            var roleFilter = cbbRoleFilter.SelectedItem?.ToString();
            var keyword = txtSearchName.Text;

            foreach (var acc in GetAccounts(roleFilter, keyword))
            {
                var item = lvwAccount.Items.Add(acc.AccountName);
                item.SubItems.Add(acc.FullName);
                item.SubItems.Add(acc.Email);
                item.SubItems.Add(acc.Tell);
                item.SubItems.Add(acc.Active ? "Active" : "Inactive");
                item.SubItems.Add(acc.Roles);
            }
        }
        private void FilterChanged(object sender, EventArgs e)
        {
            ShowAccounts();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            _db.Dispose();
            _db = new RestaurantContext();
            LoadRoleFilter();
            ShowAccounts();
        }
        private string GetSelectedAccountName()
        {
            return lvwAccount.SelectedItems.Count == 0
                ? null
                : lvwAccount.SelectedItems[0].Text;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            using (var dlg = new UpdateAccountForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    ShowAccounts();
                }
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            var accName = GetSelectedAccountName();
            if (accName == null) return;
            using (var dlg = new UpdateAccountForm(accName))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    ShowAccounts();
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            var accName = GetSelectedAccountName();
            if (accName == null) return;

            var account = _db.Accounts.Find(accName);
            if (account == null) return;

            if (MessageBox.Show("Reset mật khẩu? Password sẽ về null và tài khoản Inactive.",
                "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                account.Password = null;
                foreach (var ra in account.RoleAccounts) ra.Actived = false;
                _db.SaveChanges();
                ShowAccounts();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var accName = GetSelectedAccountName();
            if (accName == null) return;
            using (var dlg = new ChangePasswordForm(accName))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    ShowAccounts();
                }
            }
        }

        private void mnuDeleteAccount_Click(object sender, EventArgs e)
        {
            var accName = GetSelectedAccountName();
            if (accName == null) return;

            var account = _db.Accounts.Find(accName);
            if (account == null) return;

            if (MessageBox.Show("Xóa tài khoản (Password -> null, Inactive)?",
                "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                account.Password = null;
                foreach (var ra in account.RoleAccounts) ra.Actived = false;
                _db.SaveChanges();
                ShowAccounts();
            }
        }

        private void mnuViewRoles_Click(object sender, EventArgs e)
        {
            var accName = GetSelectedAccountName();
            if (accName == null) return;
            using (var dlg = new AccountRolesForm(accName))
            {
                dlg.ShowDialog(this);
            }
        }
    }
}
