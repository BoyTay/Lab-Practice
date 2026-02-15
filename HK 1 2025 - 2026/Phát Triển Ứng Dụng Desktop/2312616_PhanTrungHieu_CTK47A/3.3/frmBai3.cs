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
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            int n1=int.Parse(txtN1.Text);
            int n2 = int.Parse(txtN2.Text);

            if (rdTachChuoi.Checked)
            {
                string ho,ten;
                XuLy.TachChuoi(txtHoTen.Text, out ho, out ten);
                lblKetQua.Text = $"Họ: {ho}, Tên: {ten}";
            }
            else
            {
                bool kq = XuLy.ThuTu(n1, n2);
                if (kq)
                    lblKetQua.Text = "Đây là 2 số nguyên liên tiếp";
                else
                    lblKetQua.Text = "Đây Không phải 2 số nguyên liên tiếp";
            }
        }
    }
}
