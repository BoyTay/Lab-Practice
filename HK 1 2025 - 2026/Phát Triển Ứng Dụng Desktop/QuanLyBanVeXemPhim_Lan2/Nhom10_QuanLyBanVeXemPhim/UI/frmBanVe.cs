using Nhom10_QuanLyBanVeXemPhim.BLL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Nhom10_QuanLyBanVeXemPhim
{
    public partial class frmBanVe : Form
    {
        private readonly PhimBLL phimBll = new PhimBLL();
        private List<PhimDTO> _allPhim = new List<PhimDTO>();

        public frmBanVe()
        {
            InitializeComponent();

            // Gắn sự kiện cần thiết (Designer chưa gắn Load / SelectedIndexChanged / TextChanged).
            this.Load += frmBanVe_Load;
            lbDSPhim.SelectedIndexChanged += lbDSPhim_SelectedIndexChanged;
            txtTimKiemPhim.TextChanged += txtTimKiemPhim_TextChanged;

            // OwnerDraw đã gắn trong Designer (tránh gắn lần 2). Nếu Designer chưa gắn thì bỏ comment dưới:
            // lbDSPhim.DrawMode = DrawMode.OwnerDrawFixed;
            // lbDSPhim.DrawItem += lbDSPhim_DrawItem;
        }

        private void frmBanVe_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhim();
        }

        private void LoadDanhSachPhim()
        {
            try
            {
                _allPhim = phimBll.LayDanhSachPhim() ?? new List<PhimDTO>();

                lbDSPhim.DataSource = null;
                lbDSPhim.DisplayMember = "TenPhim";
                lbDSPhim.ValueMember = "MaPhim";

                if (_allPhim.Count == 0)
                {
                    // Không được Add Items khi DataSource != null
                    lbDSPhim.Items.Clear();
                    lbDSPhim.Items.Add("Không có dữ liệu phim (kiểm tra DB).");
                }
                else
                {
                    lbDSPhim.DataSource = _allPhim;
                }

                ClearChiTietPhim();
            }
            catch (Exception ex)
            {
                lbDSPhim.DataSource = null;
                lbDSPhim.Items.Clear();
                lbDSPhim.Items.Add("Lỗi tải phim: " + ex.Message);
            }
        }

        private void txtTimKiemPhim_TextChanged(object sender, EventArgs e)
        {
            if (_allPhim == null || _allPhim.Count == 0)
                return;

            string keyword = txtTimKiemPhim.Text.Trim().ToLower();
            var filtered = string.IsNullOrEmpty(keyword)
                ? _allPhim
                : _allPhim.Where(p => (p.TenPhim ?? "").ToLower().Contains(keyword)).ToList();

            lbDSPhim.DataSource = null;
            lbDSPhim.Items.Clear();

            if (filtered.Count == 0)
            {
                lbDSPhim.Items.Add("Không tìm thấy phim phù hợp.");
            }
            else
            {
                lbDSPhim.DataSource = filtered;
                lbDSPhim.DisplayMember = "TenPhim";
                lbDSPhim.ValueMember = "MaPhim";
            }

            ClearChiTietPhim();
        }

        private void lbDSPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDSPhim.SelectedItem is PhimDTO p)
            {
                HienThiChiTietPhim(p);
                LoadSuatChieuChoPhim(p.MaPhim);
            }
        }

        private void HienThiChiTietPhim(PhimDTO p)
        {
            lblTenPhim.Text = p.TenPhim;
            lblMoTa.Text = p.MoTa;
            lblThoiLuong.Text = p.ThoiLuong + " phút";
            lblQuocGia.Text = p.QuocGia;
            lblGioiHanTuoi.Text = p.GioiHanTuoi.ToString();
            lblTheLoai.Text = p.TheLoaiHienThi;
        }

        private void ClearChiTietPhim()
        {
            lblTenPhim.Text = "";
            lblMoTa.Text = "";
            lblTheLoai.Text = "";
            lblThoiLuong.Text = "";
            lblQuocGia.Text = "";
            lblGioiHanTuoi.Text = "";
            lbSuatChieu.Items.Clear();
        }
        private void LoadSuatChieuChoPhim(int maPhim)
        {
            try
            {
                var scBll = new SuatChieuBLL();
                var dsSC = scBll.LayDanhSachSuatChieu()
                                .Where(x => x.MaPhim == maPhim)
                                .OrderBy(x => x.ThoiGianChieu)
                                .ToList();

                lbSuatChieu.Items.Clear();

                if (dsSC.Count == 0)
                {
                    lbSuatChieu.Items.Add("Chưa có suất chiếu.");
                    return;
                }

                var groupByDate = dsSC
                    .GroupBy(sc => sc.ThoiGianChieu.Date)
                    .OrderBy(g => g.Key);

                foreach (var g in groupByDate)
                {
                    string line = $"Ngày {g.Key:dd/MM}: {string.Join(" | ", g.Select(x => x.ThoiGianChieu.ToString("HH:mm")))}";
                    lbSuatChieu.Items.Add(line);
                }
            }
            catch (Exception ex)
            {
                lbSuatChieu.Items.Clear();
                lbSuatChieu.Items.Add("Lỗi tải suất chiếu: " + ex.Message);
            }
        }
        private void lbDSPhim_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index < 0) return;

            string text;
            if (lbDSPhim.Items[e.Index] is PhimDTO phim)
                text = phim.TenPhim ?? "(Không tên)";
            else
                text = lbDSPhim.Items[e.Index].ToString();

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            using (var bg = new SolidBrush(isSelected ? Color.MediumPurple : Color.WhiteSmoke))
            using (var fg = new SolidBrush(isSelected ? Color.White : Color.Black))
            {
                e.Graphics.FillRectangle(bg, e.Bounds);
                e.Graphics.DrawString(text, e.Font, fg, e.Bounds);
            }
            e.DrawFocusRectangle();
        }
    }
}
