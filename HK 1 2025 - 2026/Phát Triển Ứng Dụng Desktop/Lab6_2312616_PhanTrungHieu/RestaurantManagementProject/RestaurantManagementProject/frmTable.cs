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
    public partial class frmTable : Form
    {
        List<Table> listTable = new List<Table>();
        Table tableCurrent = new Table();
        public frmTable()
        {
            InitializeComponent();
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            LoadTableDataToListView();
        }
        private void LoadTableDataToListView()
        {
            var bl = new TableBL();
            listTable = bl.GetAll();
            lsvTable.Items.Clear();
            int count = 1;
            foreach (var t in listTable)
            {
                var item = lsvTable.Items.Add(count.ToString());
                item.SubItems.Add(t.Name);
                item.SubItems.Add((t.Status ?? 0).ToString());
                item.SubItems.Add((t.Capacity ?? 0).ToString());
                count++;
            }
        }

        private void lsvTable_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lsvTable.Items.Count; i++)
            {
                if (lsvTable.Items[i].Selected)
                {
                    tableCurrent = listTable[i];
                    txtName.Text = tableCurrent.Name;
                    txtStatus.Text = (tableCurrent.Status ?? 0).ToString();
                    txtCapacity.Text = (tableCurrent.Capacity ?? 0).ToString();
                }
            }
        }
        private int InsertTable()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Name.");
                return -1;
            }
            int status = 0, capacity = 0;
            int.TryParse(txtStatus.Text, out status);
            int.TryParse(txtCapacity.Text, out capacity);

            var t = new Table
            {
                ID = 0,
                Name = txtName.Text.Trim(),
                Status = status,
                Capacity = capacity
            };
            var bl = new TableBL();
            return bl.Insert(t);
        }

        private int UpdateTable()
        {
            if (tableCurrent == null || tableCurrent.ID <= 0) return -1;
            int status = 0, capacity = 0;
            int.TryParse(txtStatus.Text, out status);
            int.TryParse(txtCapacity.Text, out capacity);

            tableCurrent.Name = txtName.Text.Trim();
            tableCurrent.Status = status;
            tableCurrent.Capacity = capacity;

            var bl = new TableBL();
            return bl.Update(tableCurrent);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var result = InsertTable();
            if (result > 0) { MessageBox.Show("Thêm dữ liệu thành công"); LoadTableDataToListView(); }
            else MessageBox.Show("Thêm dữ liệu không thành công.");
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            var result = UpdateTable();
            if (result > 0) { MessageBox.Show("Cập nhật dữ liệu thành công"); LoadTableDataToListView(); }
            else MessageBox.Show("Cập nhật dữ liệu không thành công.");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (tableCurrent == null || tableCurrent.ID <= 0) return;
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var bl = new TableBL();
                if (bl.Delete(tableCurrent) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadTableDataToListView();
                }
                else MessageBox.Show("Xóa không thành công.");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtStatus.Text = "";
            txtCapacity.Text = "";
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }   
}
