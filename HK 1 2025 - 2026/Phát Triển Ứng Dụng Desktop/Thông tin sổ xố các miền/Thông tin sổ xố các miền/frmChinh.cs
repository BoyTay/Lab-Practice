using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thong_tin_so_xo_cac_mien;

namespace Thông_tin_sổ_xố_các_miền
{
    public partial class frmChinh : Form
    {
        private List<KetQuaXoSo> _dsKetQua = new List<KetQuaXoSo>();
        public frmChinh()
        {
            InitializeComponent();
        }


        private void HienThiLenGrid(List<KetQuaXoSo> listKq)
        {
            dgvHienThi.Rows.Clear();
            foreach (var kq in listKq)
            {
                dgvHienThi.Rows.Add(
                    kq.Tinh,
                    kq.Ngay.ToString("dd/MM/yyyy"),
                    kq.GiaiDacBiet,
                    kq.GiaiNhat,
                    kq.GiaiNhi,
                    kq.GiaiBa,
                    kq.GiaiTu,
                    kq.GiaiNam,
                    kq.GiaiSau,
                    kq.GiaiBay,
                    kq.GiaiTam
                );
            }
        }
        private void tvMien_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string rssUrl = "";

            if (e.Node.Name == "nMienBac")
                rssUrl = "https://xosodaiphat.com/ket-qua-xo-so-mien-bac-xsmb.rss";
            else if (e.Node.Name == "nMienNam")
                rssUrl = "https://xosodaiphat.com/ket-qua-xo-so-mien-nam-xsmn.rss";
            else if (e.Node.Name == "nMienTrung")
                rssUrl = "https://xosodaiphat.com/ket-qua-xo-so-mien-trung-xsmt.rss";

            if (!string.IsNullOrEmpty(rssUrl))
            {
                try
                {
                    _dsKetQua = XuLy.LoadRss(rssUrl);
                    HienThiLenGrid(_dsKetQua);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải RSS: " + ex.Message);
                }
            }
        }

        private void dtpNgayDo_ValueChanged(object sender, EventArgs e)
        {
            var ketQuaLoc = XuLy.LocTheoNgay(_dsKetQua, dtpNgayDo.Value);
            HienThiLenGrid(ketQuaLoc);
        }

        private void txtTinh_TextChanged(object sender, EventArgs e)
        {
            var ketQuaLoc = XuLy.LocTheoTinh(_dsKetQua, txtTinh.Text.Trim());
            HienThiLenGrid(ketQuaLoc);
        }
    }

}

