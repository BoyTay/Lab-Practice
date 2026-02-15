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
    public partial class frmBills : Form
    {
        List<Bills> listBills = new List<Bills>();
        Bills billsCurrent = new Bills();
        List<Table> listTable = new List<Table>();
        List<Account> listAccount = new List<Account>();
        public frmBills()
        {
            InitializeComponent();
        }

        private void frmBills_Load(object sender, EventArgs e)
        {
            LoadCombos();
            dtpCheckoutDate.Enabled = false;
            LoadBillsToListView();
            //Admin quản lý kế toán được sửa
            bool canEdit = Authorization.IsInAny(RoleNames.Admin, RoleNames.QuanLy, RoleNames.KeToan);
            cmdAdd.Enabled = canEdit;
            cmdUpdate.Enabled = canEdit;
            cmdDelete.Enabled = canEdit;
        }

        private void LoadCombos()
        {
            var tableBL = new TableBL();
            listTable = tableBL.GetAll();
            cbbTableID.DataSource = listTable;
            cbbTableID.ValueMember = "ID";
            cbbTableID.DisplayMember = "Name";

            var accBL = new AccountBL();
            listAccount = accBL.GetAll();
            cbbAccount.DataSource = listAccount;
            cbbAccount.ValueMember = "AccountName";
            cbbAccount.DisplayMember = "AccountName";
        }

        private void LoadBillsToListView()
        {
            var bl = new BillsBL();
            listBills = bl.GetAll();
            lsvBills.Items.Clear();
            int count = 1;
            foreach (var b in listBills)
            {
                var item = lsvBills.Items.Add(count.ToString());
                item.SubItems.Add(b.Name ?? "");
                var tableName = listTable.Find(x => x.ID == b.TableID)?.Name ?? "";
                item.SubItems.Add(tableName);
                item.SubItems.Add(b.Amount.ToString());
                item.SubItems.Add((b.Discount ?? 0).ToString());
                item.SubItems.Add((b.Tax ?? 0).ToString());
                item.SubItems.Add((b.Status ?? false) ? "1" : "0");
                item.SubItems.Add(b.CheckoutDate?.ToString("yyyy-MM-dd HH:mm") ?? "");
                item.SubItems.Add(b.Account ?? "");
                count++;
            }
        }

        private void lsvBills_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvBills.Items.Count; i++)
            {
                if (lsvBills.Items[i].Selected)
                {
                    billsCurrent = listBills[i];
                    txtName.Text = billsCurrent.Name ?? "";
                    cbbTableID.SelectedIndex = listTable.FindIndex(x => x.ID == billsCurrent.TableID);
                    txtAmount.Text = billsCurrent.Amount.ToString();
                    txtDiscount.Text = (billsCurrent.Discount ?? 0).ToString();
                    txtTax.Text = (billsCurrent.Tax ?? 0).ToString();
                    chkStatus.Checked = billsCurrent.Status ?? false;
                    dtpCheckoutDate.Value = billsCurrent.CheckoutDate ?? DateTime.Now;
                    cbbAccount.SelectedIndex = listAccount.FindIndex(x => x.AccountName == billsCurrent.Account);
                }
            }
        }

        private int InsertBills()
        {
            int amount = 0; int.TryParse(txtAmount.Text, out amount);
            float discount = 0; float.TryParse(txtDiscount.Text, out discount);
            float tax = 0; float.TryParse(txtTax.Text, out tax);

            var b = new Bills
            {
                ID = 0,
                Name = txtName.Text.Trim(),
                TableID = (int)cbbTableID.SelectedValue,
                Amount = amount,
                Discount = discount,
                Tax = tax,
                Status = chkStatus.Checked,
                CheckoutDate = dtpCheckoutDate.Value,
                Account = cbbAccount.SelectedValue?.ToString()
            };
            var bl = new BillsBL();
            return bl.Insert(b);
        }

        private int UpdateBills()
        {
            if (billsCurrent == null || billsCurrent.ID <= 0) return -1;

            int amount = 0; int.TryParse(txtAmount.Text, out amount);
            float discount = 0; float.TryParse(txtDiscount.Text, out discount);
            float tax = 0; float.TryParse(txtTax.Text, out tax);

            billsCurrent.Name = txtName.Text.Trim();
            billsCurrent.TableID = (int)cbbTableID.SelectedValue;
            billsCurrent.Amount = amount;
            billsCurrent.Discount = discount;
            billsCurrent.Tax = tax;
            billsCurrent.Status = chkStatus.Checked;
            billsCurrent.CheckoutDate = dtpCheckoutDate.Value;
            billsCurrent.Account = cbbAccount.SelectedValue?.ToString();

            var bl = new BillsBL();
            return bl.Update(billsCurrent);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var result = InsertBills();
            if (result > 0) { MessageBox.Show("Thêm dữ liệu thành công"); LoadBillsToListView(); }
            else MessageBox.Show("Thêm dữ liệu không thành công.");
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            var result = UpdateBills();
            if (result > 0) { MessageBox.Show("Cập nhật dữ liệu thành công"); LoadBillsToListView(); }
            else MessageBox.Show("Cập nhật dữ liệu không thành công.");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (billsCurrent == null || billsCurrent.ID <= 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var bl = new BillsBL();
                if (bl.Delete(billsCurrent) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadBillsToListView();
                }
                else MessageBox.Show("Xóa không thành công.");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            if (cbbTableID.Items.Count > 0) cbbTableID.SelectedIndex = 0;
            txtAmount.Text = "0";
            txtDiscount.Text = "0";
            txtTax.Text = "0";
            chkStatus.Checked = false;
            dtpCheckoutDate.Value = DateTime.Now;
            if (cbbAccount.Items.Count > 0) cbbAccount.SelectedIndex = 0;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
