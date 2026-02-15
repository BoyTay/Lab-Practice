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
    public partial class RoleForm : Form
    {
        private RestaurantContext _dbContext;
        public RoleForm()
        {
            InitializeComponent();
            _dbContext = new RestaurantContext();
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {
            ShowRoles();
        }
        private List<Role> GetRoles()
        {
            return _dbContext.Roles
                .ToList();
        }

        private void ShowRoles()
        {
            lvwRoles.Items.Clear();
            foreach (var role in GetRoles())
            {
                var item = lvwRoles.Items.Add(role.Id.ToString());
                item.SubItems.Add(role.RoleName);
                item.SubItems.Add(role.Path);
                item.SubItems.Add(role.Notes);
            }
        }
        private List<AccountInRoleModel> GetAccountsForRole(int roleId)
        {
            return _dbContext.RoleAccounts
                .Where(ra => ra.RoleId == roleId)
                .OrderBy(ra => ra.AccountName)
                .Select(ra => new AccountInRoleModel
                {
                    AccountName = ra.AccountName,
                    FullName = ra.Account.FullName,
                    Email = ra.Account.Email,
                    Tell = ra.Account.Tell,
                    Actived = ra.Actived,
                    Notes = ra.Notes
                }).ToList();
        }
        private void ShowAccountsForSelectedRole()
        {
            lvwAccount.Items.Clear();
            if (lvwRoles.SelectedItems.Count == 0) return;

            var roleId = int.Parse(lvwRoles.SelectedItems[0].Text);
            var accounts = GetAccountsForRole(roleId);

            foreach (var acc in accounts)
            {
                var item = lvwAccount.Items.Add(acc.AccountName);
                item.SubItems.Add(acc.FullName);
                item.SubItems.Add(acc.Email);
                item.SubItems.Add(acc.Tell);
                item.SubItems.Add(acc.Actived ? "Active" : "Inactive");
                item.SubItems.Add(acc.Notes);
            }
        }

        private void lvwRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAccountsForSelectedRole();
        }

        private void btnReloadFood_Click(object sender, EventArgs e)
        {
            //Tạo lại DbContext để tránh tracking cũ
            _dbContext.Dispose();
            _dbContext = new RestaurantContext();
            ShowRoles();
            lvwAccount.Items.Clear();
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            var dialog = new UpdateRoleForm();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowRoles();
            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            if (lvwRoles.SelectedItems.Count == 0) return;
            var roleId = int.Parse(lvwRoles.SelectedItems[0].Text);
            var dialog = new UpdateRoleForm(roleId);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ShowRoles();
            }
        }
    }
}
