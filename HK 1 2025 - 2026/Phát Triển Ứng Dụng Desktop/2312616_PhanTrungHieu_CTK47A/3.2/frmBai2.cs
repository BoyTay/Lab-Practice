using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._2
{
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            int a=int.Parse(txtSoThuNhat.Text);
            int b=int.Parse(txtSoThuHai.Text);
            int kq = 0;
            float kqChia = 0;

            if (rdCong.Checked)
            {
                TinhToan.CongHaiSo(a, b, ref kq);
                lblKetQua.Text = kq.ToString();
            }
            else if (rdTru.Checked)
            {
                TinhToan.TruHaiSo(a, b, ref kq);
                lblKetQua.Text = kq.ToString();
            }
            else if (rdNhan.Checked)
            {
                TinhToan.NhanHaiSo(a, b, ref kq);
                lblKetQua.Text = kq.ToString();
            }
            else if (rdChia.Checked)
            {
                if (b == 0)
                {
                    MessageBox.Show("Không thể chia cho 0.");
                    return;
                }
                TinhToan.ChiaHaiSo(a, b, ref kqChia);
                lblKetQua.Text =kqChia.ToString();
            }
        }

        private void frmBai2_Load(object sender, EventArgs e)
        {

        }
    }
}
