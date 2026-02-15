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
    public partial class frmAccount : Form
    {
        List<Account> listAccount = new List<Account>();
        Account accountCurrent = new Account();
        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadAccountDataToListView();
        }
        private void LoadAccountDataToListView()
        {
            var bl = new AccountBL();
            listAccount = bl.GetAll();
            lsvAccount.Items.Clear();
            int count = 1;
            foreach (var a in listAccount)
            {
                var item = lsvAccount.Items.Add(count.ToString());
                item.SubItems.Add(a.AccountName);
                item.SubItems.Add(a.FullName);
                item.SubItems.Add(a.Email);
                item.SubItems.Add(a.Tell);
                item.SubItems.Add(a.DateCreated?.ToString("yyyy-MM-dd HH:mm") ?? "");
                count++;
            }
        }

        private void lsvAccount_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvAccount.Items.Count; i++)
            {
                if (lsvAccount.Items[i].Selected)
                {
                    accountCurrent = listAccount[i];
                    txtAccountName.Text = accountCurrent.AccountName;
                    txtPassword.Text = accountCurrent.Password;
                    txtFullName.Text = accountCurrent.FullName;
                    txtEmail.Text = accountCurrent.Email;
                    mtbTell.Text = accountCurrent.Tell;
                    dtpDateCreated.Value = accountCurrent.DateCreated ?? DateTime.Now;
                }
            }
        }

        private int InsertAccount()
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập AccountName và Password.");
                return -1;
            }
            var a = new Account
            {
                AccountName = txtAccountName.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Tell = mtbTell.Text.Trim(),
                DateCreated = dtpDateCreated.Value
            };
            var bl = new AccountBL();
            return bl.Insert(a);
        }

        private int UpdateAccount()
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text)) return -1;

            accountCurrent.AccountName = txtAccountName.Text.Trim();
            accountCurrent.Password = txtPassword.Text.Trim();
            accountCurrent.FullName = txtFullName.Text.Trim();
            accountCurrent.Email = txtEmail.Text.Trim();
            accountCurrent.Tell = mtbTell.Text.Trim();
            accountCurrent.DateCreated = dtpDateCreated.Value;

            var bl = new AccountBL();
            return bl.Update(accountCurrent);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var result = InsertAccount();
            if (result > 0) { MessageBox.Show("Thêm dữ liệu thành công"); LoadAccountDataToListView(); }
            else MessageBox.Show("Thêm dữ liệu không thành công.");
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            var result = UpdateAccount();
            if (result > 0) { MessageBox.Show("Cập nhật dữ liệu thành công"); LoadAccountDataToListView(); }
            else MessageBox.Show("Cập nhật dữ liệu không thành công.");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountName.Text)) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var bl = new AccountBL();
                if (bl.Delete(new Account { AccountName = txtAccountName.Text.Trim() }) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadAccountDataToListView();
                }
                else MessageBox.Show("Xóa không thành công.");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtAccountName.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            mtbTell.Text = "";
            dtpDateCreated.Value = DateTime.Now;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
