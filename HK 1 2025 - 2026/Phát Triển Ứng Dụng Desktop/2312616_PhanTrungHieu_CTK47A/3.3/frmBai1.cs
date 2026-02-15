using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._3
{
    public partial class frmBai1 : Form
    {
        public frmBai1()
        {
            InitializeComponent();
        }

        private void frmBai1_Load(object sender, EventArgs e)
        {

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btnKetQua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string tenNV = txtHoTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            float heSoLuong = float.Parse(txtHeSoLuong.Text);
            float heSoPhuCap = float.Parse(txtHeSoPC.Text);

            NhanVien nv = new NhanVien(maNV, tenNV, ngaySinh, heSoLuong, heSoPhuCap);

            if (rdLuongNV.Checked)
                lblKetQua.Text =  nv.TinhLuong().ToString();
            else
                lblKetQua.Text = nv.HienThi().ToString();
        }

        
    }
}
