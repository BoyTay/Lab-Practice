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
    public partial class frmBillDetails : Form
    {
        List<BillDetails> listDetails = new List<BillDetails>();
        BillDetails current = new BillDetails();
        List<Bills> listBills = new List<Bills>();
        List<Food> listFood = new List<Food>();
        public frmBillDetails()
        {
            InitializeComponent();
        }

        private void frmBillDetails_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadDetailsToListView();
            //Admin, Quản lý, Kế toán được sửa.
            bool canEdit = Authorization.IsInAny(RoleNames.Admin, RoleNames.QuanLy, RoleNames.KeToan);
            cmdAdd.Enabled = canEdit;
            cmdUpdate.Enabled = canEdit;
            cmdDelete.Enabled = canEdit;
        }
        private void LoadCombobox()
        {
            var billsBL = new BillsBL();
            listBills = billsBL.GetAll();
            cbbInvoice.DataSource = listBills;
            cbbInvoice.ValueMember = "ID";
            cbbInvoice.DisplayMember = "Name";

            var foodBL = new FoodBL();
            listFood = foodBL.GetAll();
            cbbFood.DataSource = listFood;
            cbbFood.ValueMember = "ID";
            cbbFood.DisplayMember = "Name";
        }

        private void LoadDetailsToListView()
        {
            var bl = new BillDetailsBL();
            listDetails = bl.GetAll();
            lsvBillDetails.Items.Clear();
            int count = 1;
            foreach (var d in listDetails)
            {
                var item = lsvBillDetails.Items.Add(count.ToString());
                item.SubItems.Add(d.InvoiceID.ToString());
                item.SubItems.Add(d.FoodID.ToString());
                item.SubItems.Add(d.Quantity.ToString());
                count++;
            }
        }

        private void lsvBillDetails_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvBillDetails.Items.Count; i++)
            {
                if (lsvBillDetails.Items[i].Selected)
                {
                    current = listDetails[i];
                    cbbInvoice.SelectedIndex = listBills.FindIndex(x => x.ID == current.InvoiceID);
                    cbbFood.SelectedIndex = listFood.FindIndex(x => x.ID == current.FoodID);
                    txtQuantity.Text = current.Quantity.ToString();
                }
            }
        }
        private int InsertDetail()
        {
            int qty = 0; int.TryParse(txtQuantity.Text, out qty);
            var d = new BillDetails
            {
                ID = 0,
                InvoiceID = (int)cbbInvoice.SelectedValue,
                FoodID = (int)cbbFood.SelectedValue,
                Quantity = qty
            };
            var bl = new BillDetailsBL();
            return bl.Insert(d);
        }

        private int UpdateDetail()
        {
            if (current == null || current.ID <= 0) return -1;
            int qty = 0; int.TryParse(txtQuantity.Text, out qty);
            current.InvoiceID = (int)cbbInvoice.SelectedValue;
            current.FoodID = (int)cbbFood.SelectedValue;
            current.Quantity = qty;
            var bl = new BillDetailsBL();
            return bl.Update(current);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var result = InsertDetail();
            if (result > 0) { MessageBox.Show("Thêm dữ liệu thành công"); LoadDetailsToListView(); }
            else MessageBox.Show("Thêm dữ liệu không thành công.");      
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            var result = UpdateDetail();
            if (result > 0) { MessageBox.Show("Cập nhật dữ liệu thành công"); LoadDetailsToListView(); }
            else MessageBox.Show("Cập nhật dữ liệu không thành công.");      
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (current == null || current.ID <= 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var bl = new BillDetailsBL();
                if (bl.Delete(current) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadDetailsToListView();
                }
                else MessageBox.Show("Xóa không thành công.");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            if (cbbInvoice.Items.Count > 0) cbbInvoice.SelectedIndex = 0;
            if (cbbFood.Items.Count > 0) cbbFood.SelectedIndex = 0;
            txtQuantity.Text = "0";
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
