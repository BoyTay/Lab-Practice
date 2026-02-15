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
    public partial class UpdateRoleForm : Form
    {
        private readonly RestaurantContext _dbContext;
        private readonly int _roleId;
        public UpdateRoleForm(int? roleId = null)
        {
            InitializeComponent();
            _dbContext = new RestaurantContext();
            _roleId = roleId ?? 0;
        }
        private Role GetRoleById(int roleId)
        {
            return roleId > 0 ? _dbContext.Roles.Find(roleId) : null;
        }

        private void ShowRole()
        {
            var role = GetRoleById(_roleId);
            if (role == null) return;
            txtRoleId.Text = role.Id.ToString();
            txtRoleName.Text = role.RoleName;
            txtPath.Text = role.Path;
            txtNotes.Text = role.Notes;
        }

        private void UpdateRoleForm_Load(object sender, EventArgs e)
        {
            ShowRole();
        }
        private bool ValidateUserInput()
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("RoleName cannot be empty", "Info");
                return false;
            }
            return true;
        }

        private Role GetUpdatedRole()
        {
            var role = new Role
            {
                RoleName = txtRoleName.Text.Trim(),
                Path = txtPath.Text.Trim(),
                Notes = txtNotes.Text
            };
            if (_roleId > 0) role.Id = _roleId;
            return role;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateUserInput()) return;

            var newRole = GetUpdatedRole();
            var oldRole = GetRoleById(_roleId);

            if (oldRole == null)
            {
                _dbContext.Roles.Add(newRole);
            }
            else
            {
                oldRole.RoleName = newRole.RoleName;
                oldRole.Path = newRole.Path;
                oldRole.Notes = newRole.Notes;
            }
            _dbContext.SaveChanges();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
