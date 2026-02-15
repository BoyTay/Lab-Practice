using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._4
{
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnXepLoai_Click(object sender, EventArgs e)
        {
            int diemLT= int.Parse(txtDiemLT.Text);
            int diemTH= int.Parse(txtDiemTH.Text);
            string xepLoai;

            if (!double.TryParse(txtDiemLT.Text, out double lyThuyet) ||
            !double.TryParse(txtDiemTH.Text, out double thucHanh) ||
            lyThuyet < 0 || lyThuyet > 10 || thucHanh < 0 || thucHanh > 10)
            {
                lblKetQua.Text = "Vui lòng nhập điểm hợp lệ (0-10)";
                return;
            }

            if(lyThuyet < 5 || thucHanh<5)
            {
                xepLoai ="Yếu";
            }

            else
            {
                double diemTB = (lyThuyet + thucHanh) / 2;
                if (diemTB < 7)
                    xepLoai = "Trung bình";
                else if (diemTB < 8)
                    xepLoai = "Khá";
                else if (diemTB < 9)
                    xepLoai = "Giỏi";
                else
                    xepLoai = "Xuất sắc";
            }   
            lblKetQua.Text =xepLoai.ToString();
        }
    }
}
