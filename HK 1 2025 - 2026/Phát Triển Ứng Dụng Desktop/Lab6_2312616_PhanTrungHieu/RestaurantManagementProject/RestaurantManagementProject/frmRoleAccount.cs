using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantManagementProject
{
    public partial class frmRoleAccount : Form
    {
        List<RoleAccount> listRA = new List<RoleAccount>();
        RoleAccount current = null;
        RoleAccount original = null;
        List<Role> listRole = new List<Role>();
        List<Account> listAccount = new List<Account>();

        public frmRoleAccount()
        {
            InitializeComponent();
        }

        private void frmRoleAccount_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadRoleAccountToListView();

            // Only Administrator can manage role assignments
            bool admin = Authorization.IsInRole(RoleNames.Admin);
            cmdAdd.Enabled = admin;
            cmdUpdate.Enabled = admin;
            cmdDelete.Enabled = admin;
        }

        private void LoadComboBox()
        {
            var roleBL = new RoleBL();
            listRole = roleBL.GetAll();
            cbbRole.DataSource = listRole;
            cbbRole.ValueMember = "ID";
            cbbRole.DisplayMember = "RoleName";

            var accBL = new AccountBL();
            listAccount = accBL.GetAll();
            cbbAccount.DataSource = listAccount;
            cbbAccount.ValueMember = "AccountName";
            cbbAccount.DisplayMember = "AccountName";
        }

        private void LoadRoleAccountToListView()
        {
            var bl = new RoleAccountBL();
            listRA = bl.GetAll();
            lsvRoleAccount.Items.Clear();
            int count = 1;
            foreach (var ra in listRA)
            {
                var item = lsvRoleAccount.Items.Add(count.ToString());
                item.SubItems.Add(ra.RoleID.ToString());
                item.SubItems.Add(ra.AccountName);
                item.SubItems.Add(ra.Actived ? "1" : "0");
                item.SubItems.Add(ra.Notes);
                count++;
            }
            // Reset state
            current = null;
            original = null;
            cbbAccount.Enabled = true;
            chkActived.Checked = true;
        }

        private void lsvRoleAccount_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvRoleAccount.Items.Count; i++)
            {
                if (lsvRoleAccount.Items[i].Selected)
                {
                    current = listRA[i];
                    original = new RoleAccount
                    {
                        RoleID = current.RoleID,
                        AccountName = current.AccountName,
                        Actived = current.Actived,
                        Notes = current.Notes
                    };
                    cbbRole.SelectedIndex = listRole.FindIndex(r => r.ID == current.RoleID);
                    cbbAccount.SelectedIndex = listAccount.FindIndex(a => a.AccountName == current.AccountName);
                    chkActived.Checked = current.Actived;
                    txtNotes.Text = current.Notes;
                    cbbAccount.Enabled = false; // lock account on edit
                }
            }
        }

        private int InsertRoleAccount()
        {
            // Duplicate guard
            if (listRA.Any(x => x.RoleID == (int)cbbRole.SelectedValue &&
                                x.AccountName == cbbAccount.SelectedValue.ToString()))
                return 0;

            var ra = new RoleAccount
            {
                RoleID = (int)cbbRole.SelectedValue,
                AccountName = cbbAccount.SelectedValue.ToString(),
                Actived = chkActived.Checked,
                Notes = txtNotes.Text.Trim()
            };
            var bl = new RoleAccountBL();
            return bl.Insert(ra);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var result = InsertRoleAccount();
            if (result > 0)
            {
                MessageBox.Show("Gán quyền thành công");
                LoadRoleAccountToListView();
            }
            else
            {
                MessageBox.Show("Gán quyền thất bại (đã tồn tại hoặc dữ liệu không hợp lệ)");
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (original == null) return;
            int newRoleId = (int)cbbRole.SelectedValue;
            bool actived = chkActived.Checked;
            string notes = txtNotes.Text.Trim();
            var bl = new RoleAccountBL();

            if (newRoleId == original.RoleID)
            {
                // Update in place
                var res = bl.Update(new RoleAccount
                {
                    RoleID = original.RoleID,
                    AccountName = original.AccountName,
                    Actived = actived,
                    Notes = notes
                });
                MessageBox.Show(res > 0 ? "Cập nhật quyền thành công" : "Cập nhật quyền thất bại");
                LoadRoleAccountToListView();
            }
            else
            {
                // Change role: insert new mapping first
                var insert = bl.Insert(new RoleAccount
                {
                    RoleID = newRoleId,
                    AccountName = original.AccountName,
                    Actived = actived,
                    Notes = notes
                });

                if (insert > 0)
                {
                    bl.Delete(new RoleAccount
                    {
                        RoleID = original.RoleID,
                        AccountName = original.AccountName
                    });
                    MessageBox.Show("Đổi vai trò thành công");
                    LoadRoleAccountToListView();
                }
                else
                {
                    MessageBox.Show("Không đổi được vai trò (vai trò mới đã tồn tại)");
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (original == null) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa quyền này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var bl = new RoleAccountBL();
                var res = bl.Delete(new RoleAccount
                {
                    RoleID = original.RoleID,
                    AccountName = original.AccountName
                });
                MessageBox.Show(res > 0 ? "Xóa quyền thành công" : "Xóa quyền thất bại");
                LoadRoleAccountToListView();
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            if (cbbRole.Items.Count > 0) cbbRole.SelectedIndex = 0;
            if (cbbAccount.Items.Count > 0) cbbAccount.SelectedIndex = 0;
            chkActived.Checked = true;
            txtNotes.Text = "";
            original = null;
            current = null;
            cbbAccount.Enabled = true;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
