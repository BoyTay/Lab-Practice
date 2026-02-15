using Nhom10_QuanLyBanVeXemPhim.BLL;
using Nhom10_QuanLyBanVeXemPhim.DAL;
using Nhom10_QuanLyBanVeXemPhim.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom10_QuanLyBanVeXemPhim
{
    public partial class frmAdmin : Form
    {
        private PhongChieuBLL phongbll = new PhongChieuBLL();
        private SuatChieuBLL scbll = new SuatChieuBLL();
        private TheLoaiPhimBLL tlbll = new TheLoaiPhimBLL();
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private PhimBLL phimBll = new PhimBLL();

        public frmAdmin()
        {
            InitializeComponent();
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            // Chỉ cho nhập số ở ô Số chỗ ngồi
            txtSoCN.KeyPress += txtSoCN_KeyPress;
            txtSoCN.TextChanged += txtSoCN_TextChanged;

            // Khởi tạo quyền
            ConfigureRoleCombo();

            LoadDSPhong();
            SetMaPhong();

            LoadPhongToComboBox();
            LoadPhimToComboBox();
            LoadDSSuatChieu();
            SetMaSuatChieu();

            LoadDSTheloai();
            SetMaTL();

            LoadDSNhanVien();
            SetMaNhanVien();

            LoadDSPhim();
            LoadTheLoaiToCheckedListBox();
            SetMaPhim();
        }

        private void ConfigureRoleCombo()
        {
            cbQuyen.Items.Clear();
            // Thứ tự: mặc định “Nhân viên”
            cbQuyen.Items.AddRange(new object[] { "Nhân viên", "Quản trị" });
            cbQuyen.SelectedItem = "Nhân viên";
        }
        //=========================================PHÒNG CHIẾU===================================================
        private void LoadDSPhong()
        {
            dgvPhongChieu.DataSource = phongbll.LayDanhSachPhong();
        }
        private void SetMaPhong()
        {
            var list = phongbll.LayDanhSachPhong();
            int nextId = list.Count > 0 ? list.Max(x => x.MaPhong) + 1 : 1;

            txtMaPC.Text = nextId.ToString();
            txtMaPC.ReadOnly = true;
        }
        private void RefreshComboPhong(int? selectMaPhong = null)
        {
            var ds = phongbll.LayDanhSachPhong();
            cbMaPhong.DataSource = null;
            cbMaPhong.DataSource = ds;
            cbMaPhong.DisplayMember = "TenPhong";
            cbMaPhong.ValueMember = "MaPhong";

            if (selectMaPhong.HasValue && ds.Any(x => x.MaPhong == selectMaPhong.Value))
                cbMaPhong.SelectedValue = selectMaPhong.Value;
        }
        private void dgvPhongChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhongChieu.Rows[e.RowIndex];
                txtMaPC.Text = row.Cells["MaPhong"].Value.ToString();
                txtTenPC.Text = row.Cells["TenPhong"].Value.ToString();
                txtSoCN.Text = row.Cells["SoChoNgoi"].Value.ToString();
                cbTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
                btnThemPC.Text = "Cập nhật";
                txtMaPC.ReadOnly = true;
            }
        }
        private void btnThemPC_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoCN.Text, out int soCho) || soCho <= 0)
            {
                MessageBox.Show("Số chỗ ngồi phải là số nguyên dương.", "Thông báo");
                txtSoCN.Focus();
                return;
            }

            PhongChieuDTO p = new PhongChieuDTO
            {
                TenPhong = txtTenPC.Text,
                SoChoNgoi = soCho,
                TinhTrang = cbTinhTrang.Text
            };

            int? maPhongVuaThaoTac = null;

            if (btnThemPC.Text == "Thêm")
            {
                if (phongbll.ThemPhong(p))
                {
                    // lấy mã phòng lớn nhất hiện tại xem như phòng vừa thêm
                    maPhongVuaThaoTac = phongbll.LayDanhSachPhong().Max(x => x.MaPhong);
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                }
                else MessageBox.Show("Thêm thất bại!", "Thông báo");
            }
            else
            {
                p.MaPhong = int.Parse(txtMaPC.Text);
                if (phongbll.SuaPhong(p))
                {
                    maPhongVuaThaoTac = p.MaPhong;
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                }
                else MessageBox.Show("Cập nhật thất bại!", "Thông báo");

                btnThemPC.Text = "Thêm";
            }

            LoadDSPhong();
            // Refresh combobox phòng và chọn ngay phòng vừa thêm/cập nhật
            RefreshComboPhong(maPhongVuaThaoTac);

            SetMaPhong();
            txtTenPC.Clear();
            txtSoCN.Clear();
            cbTinhTrang.SelectedIndex = 0;
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (dgvPhongChieu.SelectedRows.Count > 0)
            {
                string maPhong = dgvPhongChieu.SelectedRows[0].Cells["MaPhong"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa phòng {maPhong}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (phongbll.XoaPhong(int.Parse(maPhong)))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadDSPhong();
                        // reload combobox, chọn phần tử đầu nếu còn
                        RefreshComboPhong();
                        SetMaPhong();
                        txtTenPC.Clear();
                        txtSoCN.Clear();
                        cbTinhTrang.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thông báo");
                    }
                }
            }
        }
        //=========================================SUẤT CHIẾU===================================================
        private void LoadDSSuatChieu()
        {
            var data = scbll.LayDanhSachSuatChieu();
            dgvSuatChieu.DataSource = data;

            // Ẩn 2 cột ID
            if (dgvSuatChieu.Columns.Contains("MaPhong"))
                dgvSuatChieu.Columns["MaPhong"].Visible = false;
            if (dgvSuatChieu.Columns.Contains("MaPhim"))
                dgvSuatChieu.Columns["MaPhim"].Visible = false;

            // Đặt tiêu đề và format cho đẹp
            if (dgvSuatChieu.Columns.Contains("TenPhong"))
                dgvSuatChieu.Columns["TenPhong"].HeaderText = "Tên phòng";
            if (dgvSuatChieu.Columns.Contains("TenPhim"))
                dgvSuatChieu.Columns["TenPhim"].HeaderText = "Tên phim";
            if (dgvSuatChieu.Columns.Contains("ThoiGianChieu"))
                dgvSuatChieu.Columns["ThoiGianChieu"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            if (dgvSuatChieu.Columns.Contains("GiaVe"))
                dgvSuatChieu.Columns["GiaVe"].DefaultCellStyle.Format = "N0";
        }
        private void LoadPhongToComboBox()
        {
            RefreshComboPhong();
        }
        private void LoadPhimToComboBox()
        {
            var ds = phimBll.LayDanhSachPhim();
            cbMaPhim.DataSource = ds;
            cbMaPhim.DisplayMember = "TenPhim";
            cbMaPhim.ValueMember = "MaPhim";
        }
        private void SetMaSuatChieu()
        {
            var list = scbll.LayDanhSachSuatChieu();
            int nextId = list.Count > 0 ? list.Max(x => x.MaSC) + 1 : 1;
            txtMaSC.Text = nextId.ToString();
            txtMaSC.ReadOnly = true;
        }

        private void dgvSuatChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var sc = dgvSuatChieu.Rows[e.RowIndex].DataBoundItem as SuatChieuDTO;
            if (sc == null) return;

            txtMaSC.Text = sc.MaSC.ToString();
            cbMaPhong.SelectedValue = sc.MaPhong;
            cbMaPhim.SelectedValue  = sc.MaPhim;

            dtpTGChieu.Value = sc.ThoiGianChieu;
            txtGiaVe.Text = sc.GiaVe.ToString();

            btnThemSC.Text = "Cập nhật";
            txtMaSC.ReadOnly = true;
        }

        private void btnThemSC_Click(object sender, EventArgs e)
        {
            SuatChieuDTO sc = new SuatChieuDTO
            {
                MaPhong = Convert.ToInt32(cbMaPhong.SelectedValue),
                MaPhim = Convert.ToInt32(cbMaPhim.SelectedValue),
                ThoiGianChieu = dtpTGChieu.Value,
                GiaVe = decimal.Parse(txtGiaVe.Text)
            };

            if (btnThemSC.Text == "Thêm")
            {
                if (scbll.ThemSuatChieu(sc))
                    MessageBox.Show("Thêm thành công!");
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            else
            {
                sc.MaSC = int.Parse(txtMaSC.Text);
                if (scbll.SuaSuatChieu(sc))
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Cập nhật thất bại!");

                btnThemSC.Text = "Thêm";
            }

            LoadDSSuatChieu();
            SetMaSuatChieu();
            txtGiaVe.Clear();
            cbMaPhong.SelectedIndex = 0;
            cbMaPhim.SelectedIndex = 0;
        }

        private void tsmDeleteSC_Click(object sender, EventArgs e)
        {
            if (dgvSuatChieu.SelectedRows.Count > 0)
            {
                string maSC = dgvSuatChieu.SelectedRows[0].Cells["MaSC"].Value.ToString();
                DialogResult dr = MessageBox.Show($"Xóa suất chiếu {maSC}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (scbll.XoaSuatChieu(int.Parse(maSC)))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadDSSuatChieu();
                        SetMaSuatChieu();
                        txtGiaVe.Clear();
                        cbMaPhong.SelectedIndex = 0;
                        cbMaPhim.SelectedIndex = 0;
                    }
                    else
                        MessageBox.Show("Xóa thất bại!");
                }
            }
        }
        //==========================================THẺ LOẠI===================================================
        private void LoadDSTheloai()
        {
            dgvTLPhim.DataSource = tlbll.LayDanhSachTheLoai();
        }
        private void SetMaTL()
        {
            var list = tlbll.LayDanhSachTheLoai();
            int nextId = list.Count > 0 ? list.Max(x => x.MaTheLoai) + 1 : 1;
            txtMaTheLoai.Text = nextId.ToString();
            txtMaTheLoai.ReadOnly = true;
        }

        private void dgvTLPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTLPhim.Rows[e.RowIndex];
                txtMaTheLoai.Text = row.Cells["MaTheLoai"].Value.ToString();
                txtTenTheLoai.Text = row.Cells["TenTheLoai"].Value.ToString();
                btnThemTL.Text = "Cập nhật";
                txtMaTheLoai.ReadOnly = true;
            }
        }

        private void btnThemTL_Click(object sender, EventArgs e)
        {
            TheLoaiPhimDTO tl = new TheLoaiPhimDTO
            {
                TenTheLoai = txtTenTheLoai.Text
            };

            if (btnThemTL.Text == "Thêm")
            {
                if (tlbll.ThemTheLoai(tl))
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                else
                    MessageBox.Show("Thêm thất bại!", "Thông báo");
            }
            else
            {
                tl.MaTheLoai = int.Parse(txtMaTheLoai.Text);
                if (tlbll.SuaTheLoai(tl))
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                else
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo");

                btnThemTL.Text = "Thêm";
            }

            LoadDSTheloai();
            SetMaTL();
            txtTenTheLoai.Clear();
        }

        private void tsmDeleteTL_Click(object sender, EventArgs e)
        {
            if (dgvTLPhim.SelectedRows.Count > 0)
            {
                string maTL = dgvTLPhim.SelectedRows[0].Cells["MaTheLoai"].Value.ToString();

                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa thể loại {maTL}?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (tlbll.XoaTheLoai(int.Parse(maTL)))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadDSTheloai();
                        SetMaTL();
                        txtTenTheLoai.Clear();
                    }
                    else
                        MessageBox.Show("Xóa thất bại!", "Thông báo");
                }
            }
        }
        //=========================================NHÂN VIÊN===================================================
        private void LoadDSNhanVien()
        {
            dgvNhanVien.DataSource = nvBLL.LayDanhSachNhanVien();
        }

        private void SetMaNhanVien()
        {
            var list = nvBLL.LayDanhSachNhanVien();
            int nextId = list.Count > 0 ? list.Max(x => x.MaNV) + 1 : 1;
            txtMaNV.Text = nextId.ToString();
            txtMaNV.ReadOnly = true;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenDN.Text = row.Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();

                bool isAdmin = Convert.ToBoolean(row.Cells["LaAdmin"].Value);
                cbQuyen.SelectedItem = isAdmin ? "Quản trị" : "Nhân viên";

                btnThemNV.Text = "Cập nhật";
                txtMaNV.ReadOnly = true;
            }
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (cbQuyen.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn quyền (Nhân viên/Quản trị).", "Thông báo");
                cbQuyen.DroppedDown = true;
                return;
            }

            bool laAdmin = string.Equals(cbQuyen.SelectedItem.ToString(), "Quản trị", StringComparison.OrdinalIgnoreCase);

            NhanVienDTO nv = new NhanVienDTO
            {
                TenDangNhap = txtTenDN.Text.Trim(),
                MatKhau = txtMatKhau.Text.Trim(),
                TenNV = txtTenNV.Text.Trim(),
                LaAdmin = laAdmin
            };

            if (btnThemNV.Text == "Thêm")
            {
                // Xác nhận khi tạo tài khoản Quản trị
                if (laAdmin)
                {
                    var cf = MessageBox.Show("Bạn đang tạo tài khoản QUẢN TRỊ. Tiếp tục?", "Xác nhận",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (cf != DialogResult.Yes) return;
                }

                if (nvBLL.ThemNhanVien(nv))
                    MessageBox.Show(laAdmin ? "Thêm quản trị thành công!" : "Thêm nhân viên thành công!", "Thông báo");
                else
                    MessageBox.Show("Thêm thất bại!", "Thông báo");
            }
            else
            {
                nv.MaNV = int.Parse(txtMaNV.Text);

                // Xác nhận khi cập nhật thành quyền Quản trị
                if (laAdmin)
                {
                    var cf = MessageBox.Show("Bạn đang cấp quyền QUẢN TRỊ cho tài khoản này. Tiếp tục?", "Xác nhận",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (cf != DialogResult.Yes) return;
                }

                if (nvBLL.SuaNhanVien(nv))
                    MessageBox.Show(laAdmin ? "Cập nhật quản trị thành công!" : "Cập nhật nhân viên thành công!", "Thông báo");
                else
                    MessageBox.Show("Cập nhật thất bại!", "Thông báo");

                btnThemNV.Text = "Thêm";
            }

            // Load lại grid & set mã nhân viên mới
            LoadDSNhanVien();
            SetMaNhanVien();

            // Reset nhập liệu
            txtTenDN.Clear();
            txtMatKhau.Clear();
            txtTenNV.Clear();
            cbQuyen.SelectedItem = "Nhân viên"; // mặc định
        }
        private void tsmDeleteNV_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                string ma = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {ma}?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (nvBLL.XoaNhanVien(int.Parse(ma)))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadDSNhanVien();
                        SetMaNhanVien();

                        txtTenDN.Clear();
                        txtMatKhau.Clear();
                        txtTenNV.Clear();
                        cbQuyen.SelectedIndex = 1;
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thông báo");
                    }
                }
            }
        }
        //============================================PHIM=====================================================
        private void LoadDSPhim()
        {
            dgvPhim.AutoGenerateColumns = false;
            dgvPhim.DataSource = phimBll.LayDanhSachPhim();

            // Cột hiển thị thể loại (đã tạo sẵn trong Designer, Name = TenTheLoai_Phim)
            if (dgvPhim.Columns.Contains("TenTheLoai_Phim"))
            {
                dgvPhim.Columns["TenTheLoai_Phim"].DataPropertyName = "TheLoaiHienThi";
                dgvPhim.Columns["TenTheLoai_Phim"].HeaderText = "Thể loại";
                dgvPhim.Columns["TenTheLoai_Phim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                // Nếu Designer chưa có cột, tạo mới
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "TenTheLoai_Phim",
                    HeaderText = "Thể loại",
                    DataPropertyName = "TheLoaiHienThi",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                };
                dgvPhim.Columns.Add(col);
            }

            // Ẩn cột tự sinh TheLoaiHienThi (nếu lỡ xuất hiện)
            if (dgvPhim.Columns.Contains("TheLoaiHienThi") && dgvPhim.Columns["TheLoaiHienThi"].Name != "TenTheLoai_Phim")
                dgvPhim.Columns["TheLoaiHienThi"].Visible = false;

            // Định dạng ngày
            if (dgvPhim.Columns.Contains("NgayKC"))
                dgvPhim.Columns["NgayKC"].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (dgvPhim.Columns.Contains("NgayKT"))
                dgvPhim.Columns["NgayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        private void SetMaPhim()
        {
            var list = phimBll.LayDanhSachPhim();
            int nextId = list.Count > 0 ? list.Max(x => x.MaPhim) + 1 : 1;
            txtMaPhim.Text = nextId.ToString();
            txtMaPhim.ReadOnly = true;
        }
        private void LoadTheLoaiToCheckedListBox()
        {
            var ds = tlbll.LayDanhSachTheLoai(); // lấy từ DB
            clbTheLoai.DataSource = null;
            clbTheLoai.DataSource = ds;          // bind danh sách
            clbTheLoai.DisplayMember = "TenTheLoai";
            // clbTheLoai.ValueMember không cần, vì CheckedItems bạn đang cast về TheLoaiPhimDTO để lấy MaTheLoai
        }

        private void dgvPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhim.Rows[e.RowIndex];
                txtMaPhim.Text = row.Cells["MaPhim"].Value.ToString();
                txtTenPhim.Text = row.Cells["TenPhim"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
                txtThoiLuong.Text = row.Cells["ThoiLuong"].Value.ToString();
                dtpKC.Value = Convert.ToDateTime(row.Cells["NgayKC"].Value);
                dtpKT.Value = Convert.ToDateTime(row.Cells["NgayKT"].Value);
                txtQuocGia.Text = row.Cells["QuocGia"].Value.ToString();
                txtGioiHanTuoi.Text = row.Cells["GioiHanTuoi"].Value.ToString();

                // Bỏ check hết trước
                for (int i = 0; i < clbTheLoai.Items.Count; i++)
                    clbTheLoai.SetItemChecked(i, false);

                // Lấy chuỗi thể loại hiển thị từ cột đã map
                string theLoaiHienThi = row.Cells["TenTheLoai_Phim"].Value?.ToString();
                if (!string.IsNullOrEmpty(theLoaiHienThi))
                {
                    string[] arr = theLoaiHienThi.Split(',');
                    foreach (string tl in arr)
                    {
                        string ten = tl.Trim();
                        for (int i = 0; i < clbTheLoai.Items.Count; i++)
                        {
                            var item = clbTheLoai.Items[i] as TheLoaiPhimDTO;
                            if (item != null && string.Equals(item.TenTheLoai.Trim(), ten, StringComparison.OrdinalIgnoreCase))
                                clbTheLoai.SetItemChecked(i, true);
                        }
                    }
                }

                btnThemPhim.Text = "Cập nhật";
            }
        }
        private void btnThemPhim_Click(object sender, EventArgs e)
        {
            PhimDTO p = new PhimDTO
            {
                TenPhim = txtTenPhim.Text,
                MoTa = txtMoTa.Text,
                ThoiLuong = int.Parse(txtThoiLuong.Text),
                NgayKC = dtpKC.Value,
                NgayKT = dtpKT.Value,
                QuocGia = txtQuocGia.Text,
                GioiHanTuoi = int.Parse(txtGioiHanTuoi.Text)
            };

            // Lấy danh sách thể loại được check
            List<int> dsMaTL = new List<int>();
            foreach (var item in clbTheLoai.CheckedItems)
            {
                if (item is TheLoaiPhimDTO tl)
                    dsMaTL.Add(tl.MaTheLoai);
            }

            if (btnThemPhim.Text == "Thêm")
            {
                if (phimBll.ThemPhim(p, dsMaTL))
                    MessageBox.Show("Thêm phim thành công!");
                else
                    MessageBox.Show("Thêm thất bại!");
            }
            else
            {
                p.MaPhim = int.Parse(txtMaPhim.Text);
                if (phimBll.SuaPhim(p, dsMaTL))
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Cập nhật thất bại!");

                btnThemPhim.Text = "Thêm";
            }

            LoadDSPhim();
            SetMaPhim();

            txtTenPhim.Clear();
            txtMoTa.Clear();
            txtThoiLuong.Clear();
            txtQuocGia.Clear();
            txtGioiHanTuoi.Clear();
            for (int i = 0; i < clbTheLoai.Items.Count; i++)
                clbTheLoai.SetItemChecked(i, false);
        }

        private void tsmDeletePhim_Click(object sender, EventArgs e)
        {
            if (dgvPhim.SelectedRows.Count > 0)
            {
                string ma = dgvPhim.SelectedRows[0].Cells["MaPhim"].Value.ToString();
                DialogResult dr = MessageBox.Show($"Xóa phim {ma}?", "Xác nhận", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    if (phimBll.XoaPhim(int.Parse(ma)))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadDSPhim();
                        SetMaPhim();
                    }
                    else
                        MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số hoặc phím điều khiển (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void txtSoCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        // Làm sạch khi dán/paste nội dung có ký tự không phả
        private void txtSoCN_TextChanged(object sender, EventArgs e)
        {
            var s = txtSoCN.Text;
            if (string.IsNullOrEmpty(s)) return;
            if (s.All(char.IsDigit)) return;

            int caret = txtSoCN.SelectionStart;
            txtSoCN.Text = new string(s.Where(char.IsDigit).ToArray());
            txtSoCN.SelectionStart = Math.Min(caret, txtSoCN.Text.Length);
        }
    }
}

