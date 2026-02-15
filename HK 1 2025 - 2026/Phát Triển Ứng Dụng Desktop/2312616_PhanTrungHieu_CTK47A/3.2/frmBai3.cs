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
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            int n = int.Parse(txtSoN.Text);
            if (rdNoiChuoi.Checked)
            {
                string s = "";
                XuLyChuoiVaSo.NoiChuoi(ho, ten, out s);
                lblKetQuaNC.Text = s;
            }
            else
            {
                if (!int.TryParse(txtSoN.Text, out n) || n < 0)
                {
                    MessageBox.Show("Vui lòng nhập số nguyên dương.");
                    return;
                }
                long kq = XuLyChuoiVaSo.GiaiThua(n);
                lblKetQuaGT.Text = kq.ToString();
            }
        }
    }
}
