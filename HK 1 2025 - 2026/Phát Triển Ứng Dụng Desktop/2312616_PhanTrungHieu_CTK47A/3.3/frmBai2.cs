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
    public partial class frmBai2 : Form
    {
        public frmBai2()
        {
            InitializeComponent();
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            int n,kq;
            if (!int.TryParse(txtSoN.Text, out n) || n <= 0)
            {
                lblKetQua.Text = "Vui lòng nhập số nguyên dương!";
                return;
            }

            if (rdTinhTong.Checked)
            {
                XuLy.TinhTongN(n, out kq);
                lblKetQua.Text = kq.ToString();

            }
            else
            {
                XuLy.TinhGiaiThuaN(n, out kq);
                lblKetQua.Text = kq.ToString();
            }

        }
    }
}
