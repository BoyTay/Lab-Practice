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
    public partial class frmBai3 : Form
    {
        public frmBai3()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            int m = int.Parse(txtSoM.Text);
            int n = int.Parse(txtSoN.Text);
            bool gioiTinh = rdNam.Checked;
            if (rdChaoHoi.Checked)
            {
                XuLy.ChaoHoi(hoTen, gioiTinh);
            }
            else
            {              
                    int uscln = XuLy.USCLN(m, n);
                    lblHienThi.Text = uscln.ToString();
            }
        }
    }
}
