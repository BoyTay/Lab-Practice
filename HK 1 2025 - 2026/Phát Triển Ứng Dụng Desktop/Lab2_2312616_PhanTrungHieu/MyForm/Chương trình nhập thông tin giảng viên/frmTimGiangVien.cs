using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chương_trình_nhập_thông_tin_giảng_viên
{
    public partial class frmTimGiangVien : Form
    {
        private QuanLyGiangVien qlGiangVien;

        public frmTimGiangVien(QuanLyGiangVien ql)
        {
            InitializeComponent();
            qlGiangVien = ql;
        }

        private void frmTimGiangVien_Load(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            SoSanh ss;
            object key = txtTimKiem.Text.Trim();
            if (rdMaGV.Checked)
                ss = SoSanhTheoMa;
            else if (rdHoTen.Checked)
                ss = SoSanhTheoHoTen;
            else
                ss = SoSanhTheoSDT;

            GiangVien gv = qlGiangVien.Tim(key, ss);
            if (gv != null)
            {
                frmTBGiangVien frm = new frmTBGiangVien();
                frm.SetText(gv.ToString());
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private int SoSanhTheoMa(object a, object b)
        {
            GiangVien gv = b as GiangVien;
            return string.Compare(a.ToString(), gv.MaSo, StringComparison.OrdinalIgnoreCase);
        }

        private int SoSanhTheoHoTen(object a, object b)
        {
            GiangVien gv = b as GiangVien;
            return string.Compare(a.ToString(), gv.HoTen, StringComparison.OrdinalIgnoreCase);
        }

        private int SoSanhTheoSDT(object a, object b)
        {
            GiangVien gv = b as GiangVien;
            return string.Compare(a.ToString(), gv.SoDT, StringComparison.OrdinalIgnoreCase);
        }

    }
}
