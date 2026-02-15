using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RestaurantManagementProject
{
    public partial class frmCategory : Form
    {
        List<Category> listCategory = new List<Category>();
        Category categoryCurrent = new Category();

        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            InitTypeCombo();
            LoadCategoryDataToListView();
            //Admin + Quản lý được thêm/sửa/xóa, còn lại chỉ xem.
            bool canEdit = Authorization.IsInAny(RoleNames.Admin, RoleNames.QuanLy);
            cmdAdd.Enabled = canEdit;
            cmdUpdate.Enabled = canEdit;
            cmdDelete.Enabled = canEdit;
        }

        // Bind friendly text to numeric values: 0 = Đồ uống, 1 = Thức ăn
        private void InitTypeCombo()
        {
            var data = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("Đồ uống", 0),
                new KeyValuePair<string, int>("Thức ăn", 1)
            };
            cbbType.DataSource = data;
            cbbType.DisplayMember = "Key";
            cbbType.ValueMember = "Value";
            cbbType.SelectedValue = 0; // default to 0
        }

        private void LoadCategoryDataToListView()
        {
            CategoryBL bl = new CategoryBL();
            listCategory = bl.GetAll();
            lsvCategory.Items.Clear();
            int count = 1;
            foreach (var c in listCategory)
            {
                var item = lsvCategory.Items.Add(count.ToString());
                item.SubItems.Add(c.Name);
                // Show raw 0/1 in ListView (as requested)
                item.SubItems.Add(c.Type.ToString());
                count++;
            }
        }

        private void lsvCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvCategory.Items.Count; i++)
            {
                if (lsvCategory.Items[i].Selected)
                {
                    categoryCurrent = listCategory[i];
                    txtName.Text = categoryCurrent.Name;
                    // Select friendly text by numeric value (0/1)
                    cbbType.SelectedValue = categoryCurrent.Type;
                }
            }
        }

        private int InsertCategory()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Name và Type.");
                return -1;
            }

            int type = (int)cbbType.SelectedValue;

            var c = new Category
            {
                ID = 0,
                Name = txtName.Text.Trim(),
                Type = type
            };
            var bl = new CategoryBL();
            return bl.Insert(c);
        }

        private int UpdateCategory()
        {
            if (categoryCurrent == null || categoryCurrent.ID <= 0) return -1;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Name và Type.");
                return -1;
            }

            int type = (int)cbbType.SelectedValue;

            categoryCurrent.Name = txtName.Text.Trim();
            categoryCurrent.Type = type;

            var bl = new CategoryBL();
            return bl.Update(categoryCurrent);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var result = InsertCategory();
            if (result > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công");
                LoadCategoryDataToListView();
            }
            else MessageBox.Show("Thêm dữ liệu không thành công.");
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            var result = UpdateCategory();
            if (result > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                LoadCategoryDataToListView();
            }
            else MessageBox.Show("Cập nhật dữ liệu không thành công.");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (categoryCurrent == null || categoryCurrent.ID <= 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var bl = new CategoryBL();
                if (bl.Delete(categoryCurrent) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadCategoryDataToListView();
                }
                else MessageBox.Show("Xóa không thành công.");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            cbbType.SelectedValue = 0; // reset to "Đồ uống"
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
