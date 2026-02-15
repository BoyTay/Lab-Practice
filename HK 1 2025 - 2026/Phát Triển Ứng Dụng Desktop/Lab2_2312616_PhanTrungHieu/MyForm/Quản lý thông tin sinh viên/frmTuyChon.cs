using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public enum KieuTuyChon
{
    MaSV,
    HoTen,
    NgaySinh
}

namespace Quản_lý_thông_tin_sinh_viên
{
    public partial class frmTuyChon : Form
    {
        public frmTuyChon()
        {
            InitializeComponent();
        }
      
        public KieuTuyChon Kieu
        {
            get
            {
                if (rdMaSV.Checked) return KieuTuyChon.MaSV;
                if (rdHoTen.Checked) return KieuTuyChon.HoTen;
                return KieuTuyChon.NgaySinh;
            }
        }
        public string ChuoiTim
        {
            get { return txtChuoiTim.Text.Trim(); }
        }

        private void btnSapXep_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtChuoiTim.Text))
            {
                MessageBox.Show("Hãy nhập thông tin tìm!", "Lỗi nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Reset về mặc định
            rdMaSV.Checked = true; // hoặc radio mặc định bạn muốn
            txtChuoiTim.Text = string.Empty;
            this.Close();
        }
    }
}
