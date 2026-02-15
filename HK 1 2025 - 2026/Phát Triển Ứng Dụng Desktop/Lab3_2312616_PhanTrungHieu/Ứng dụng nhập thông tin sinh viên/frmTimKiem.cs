using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ứng_dụng_nhập_thông_tin_sinh_viên
{
    public partial class frmTimKiem : Form
    {
        public string MSSV => mtbMSSV.Text.Trim();
        public string HoLot => txtHoLot.Text.Trim();
        public string Ten => txtTen.Text.Trim();
        public string Lop => cboLop.Text.Trim();
        public string GioiTinh => cboGioiTinh.SelectedItem == null ? "" : cboGioiTinh.SelectedItem.ToString();
        public string CMND => mtbCMND.Text.Replace("_", "").Trim();
        public string DienThoai => new string(mtbSoDT.Text.Where(char.IsDigit).ToArray());
        public string DiaChi => txtDiaChi.Text.Trim();
        public string MonHoc => cboMonHoc.SelectedItem == null ? "" : cboMonHoc.SelectedItem.ToString();
        public bool TimTheoNgaySinh => chkNgaySinh.Checked;
        public DateTime NgaySinh => dtpNgaySinh.Value.Date;
        public frmTimKiem(List<string> dsLop)
        {
            InitializeComponent();
            cboLop.Items.AddRange(dsLop.Distinct().ToArray());
            cboLop.SelectedIndex = -1;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
