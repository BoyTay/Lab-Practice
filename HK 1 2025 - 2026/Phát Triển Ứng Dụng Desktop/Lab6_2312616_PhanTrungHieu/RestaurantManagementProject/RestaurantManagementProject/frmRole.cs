using BusinessLogic;
using DataAccess;
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
    public partial class frmRole : Form
    {
        List<Role> listRole = new List<Role>();
        Role roleCurrent = new Role();

        public frmRole()
        {
            InitializeComponent();
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            LoadRoleDataToListView();
            bool admin = Authorization.IsInRole(RoleNames.Admin);
            //Chỉ admin được thêm , sửa, xóa Role
            cmdAdd.Enabled = admin;
            cmdUpdate.Enabled = admin;
            cmdDelete.Enabled = admin;
        }

        private void LoadRoleDataToListView()
        {
            var bl = new RoleBL();
            listRole = bl.GetAll();
            lsvRole.Items.Clear();
            int count = 1;
            foreach (var r in listRole)
            {
                var item = lsvRole.Items.Add(count.ToString());
                item.SubItems.Add(r.RoleName);
                item.SubItems.Add(r.Path);
                item.SubItems.Add(r.Notes);
                count++;
            }
        }

        private void lsvRole_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvRole.Items.Count; i++)
            {
                if (lsvRole.Items[i].Selected)
                {
                    roleCurrent = listRole[i];
                    txtRoleName.Text = roleCurrent.RoleName;
                    txtPath.Text = roleCurrent.Path;
                    txtNotes.Text = roleCurrent.Notes;
                }
            }
        }
        private int InsertRole()
        {
            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                MessageBox.Show("Vui lòng nhập RoleName.");
                return -1;
            }
            var r = new Role
            {
                ID = 0,
                RoleName = txtRoleName.Text.Trim(),
                Path = txtPath.Text.Trim(),
                Notes = txtNotes.Text.Trim()
            };
            var bl = new RoleBL();
            return bl.Insert(r);
        }

        private int UpdateRole()
        {
            if (roleCurrent == null || roleCurrent.ID <= 0) return -1;

            roleCurrent.RoleName = txtRoleName.Text.Trim();
            roleCurrent.Path = txtPath.Text.Trim();
            roleCurrent.Notes = txtNotes.Text.Trim();

            var bl = new RoleBL();
            return bl.Update(roleCurrent);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var result = InsertRole();
            if (result > 0) { MessageBox.Show("Thêm dữ liệu thành công"); LoadRoleDataToListView(); }
            else MessageBox.Show("Thêm dữ liệu không thành công.");
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            var result = UpdateRole();
            if (result > 0) { MessageBox.Show("Cập nhật dữ liệu thành công"); LoadRoleDataToListView(); }
            else MessageBox.Show("Cập nhật dữ liệu không thành công.");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (roleCurrent == null || roleCurrent.ID <= 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var bl = new RoleBL();
                if (bl.Delete(roleCurrent) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadRoleDataToListView();
                }
                else MessageBox.Show("Xóa không thành công.");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtRoleName.Text = "";
            txtPath.Text = "";
            txtNotes.Text = "";
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }  
}
