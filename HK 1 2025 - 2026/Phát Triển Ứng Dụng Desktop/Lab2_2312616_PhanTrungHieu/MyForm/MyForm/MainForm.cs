using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.cboMaHV.Text = string.Empty;
            this.tbHoTen.Text = string.Empty;
            this.tbTongTien.Text = string.Empty;
            this.dtpNgayDK.Value= DateTime.Now;
            this.cbNam.Checked = true;
            this.cbNu.Checked = false;
            this.cbTiengAnhA.Checked = false;
            this.cbTiengAnhB.Checked = false;
            this.cbTinHocA.Checked = false;
            this.cbTinHocB.Checked = false;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int s = 0;
            if (cbTinHocA.Checked)
                s += int.Parse(lblTienTHA.Text.Split('.')[0]);
            if (cbTinHocB.Checked)
                s += int.Parse(lblTienTHB.Text.Split('.')[0]);
            if (cbTiengAnhA.Checked)
                s += int.Parse(lblTienTAA.Text.Split('.')[0]);
            if (cbTiengAnhB.Checked)
                s += int.Parse(lblTienTAB.Text.Split('.')[0]);
            this.tbTongTien.Text = s + (".000 đồng");
        }
    }
}
