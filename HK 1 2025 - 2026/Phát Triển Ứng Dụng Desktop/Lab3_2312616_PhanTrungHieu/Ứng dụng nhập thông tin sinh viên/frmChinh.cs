using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ứng_dụng_nhập_thông_tin_sinh_viên
{
    public partial class frmChinh : Form
    {
        private StudentManager manager;
        private string mssvDangChon = null; // Biến lưu MSSV đang chọn
        public frmChinh()
        {
            InitializeComponent();
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            manager = new StudentManager("student.txt");
            DocDanhSachMonHoc();
            LoadListView();
        }
        private void LoadListView()
        {
            lvSinhVien.Items.Clear();
            foreach (var s in manager.GetAll())
            {
                var item = new ListViewItem(s.MSSV);
                item.SubItems.Add(s.HoLot);
                item.SubItems.Add(s.Ten);
                item.SubItems.Add(s.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(s.Lop);
                item.SubItems.Add(s.CMND);
                item.SubItems.Add(s.DienThoai);
                item.SubItems.Add(s.DiaChi);
                item.Tag = s; // Gán đối tượng Student vào Tag
                lvSinhVien.Items.Add(item);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void LuuDanhSachMonHoc()
        {
            var dsMonHoc = clbMonHoc.Items.Cast<string>().ToList();
            System.IO.File.WriteAllLines("monhoc.txt", dsMonHoc);
        }
        private void DocDanhSachMonHoc()
        {
            clbMonHoc.Items.Clear();
            if (System.IO.File.Exists("monhoc.txt"))
            {
                var dsMonHoc = System.IO.File.ReadAllLines("monhoc.txt");
                clbMonHoc.Items.AddRange(dsMonHoc);
            }
        }

        private void thêmMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string monMoi = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên môn học mới:", "Thêm môn học", "");
            if (!string.IsNullOrWhiteSpace(monMoi))
            {
                clbMonHoc.Items.Add(monMoi);
                LuuDanhSachMonHoc();
            }
        }

        private void xóaMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clbMonHoc.SelectedItem != null)
            {
                clbMonHoc.Items.Remove(clbMonHoc.SelectedItem);
                LuuDanhSachMonHoc();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa.");
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                var sv = (Student)lvSinhVien.SelectedItems[0].Tag;
                HienThiThongTinLenForm(sv);
                mssvDangChon = sv.MSSV; // Lưu MSSV đang chọn
            }
        }

        private void HienThiThongTinLenForm(Student sv)
        {
            mtbMSSV.Text = sv.MSSV;
            txtHoTen.Text = sv.HoLot;
            txtTen.Text = sv.Ten;
            dtpNgaySinh.Value = sv.NgaySinh;
            cboLop.Text = sv.Lop;
            mtbCMND.Text = sv.CMND;
            rdNam.Checked = sv.GioiTinh == "Nam";
            rdNu.Checked = sv.GioiTinh == "Nữ";
            mtbSoDT.Text = sv.DienThoai;
            txtDiaChi.Text = sv.DiaChi;

            // Bỏ check tất cả trước
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
                clbMonHoc.SetItemChecked(i, false);

            // Check lại các môn mà sv đã đăng ký
            if (sv.MonHoc != null)
            {
                foreach (var mh in sv.MonHoc)
                {
                    int index = clbMonHoc.Items.IndexOf(mh);
                    if (index >= 0) clbMonHoc.SetItemChecked(index, true);
                }
            }   
        }

        private bool KiemTraThongTin()
        {
            /// MSSV: 7 chữ số
            if (string.IsNullOrWhiteSpace(mtbMSSV.Text) ||
                mtbMSSV.Text.Length != 7 ||
                !mtbMSSV.Text.All(char.IsDigit))
                return false;

            string mssv = mtbMSSV.Text.Trim();
            string lop = cboLop.Text.Trim();
            if (string.IsNullOrWhiteSpace(lop) || lop.Length < 5) // ví dụ CTK23
                return false;

            // Lấy 2 số cuối trong tên lớp (CTK23 -> "23")
            string namLop = new string(lop.Where(char.IsDigit).ToArray());
            if (namLop.Length != 2)
                return false;

            // So sánh với 2 ký tự đầu MSSV
            if (mssv.Substring(0, 2) != namLop)
                return false;

            // BB = 10 (cố định)
            if (mssv.Substring(2, 2) != "10")
                return false;

            // Kiểm tra trùng MSSV (chỉ khi thêm mới, không kiểm tra khi cập nhật)
            var allStudents = manager.GetAll();
            if (allStudents.Any(sv => sv.MSSV == mssv && sv.MSSV != mssvDangChon))
                return false;

            // Họ lót và tên
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text))
                return false;

            // Ngày sinh (không được ở tương lai)
            if (dtpNgaySinh.Value.Date > DateTime.Now.Date)
                return false;

            // Giới tính
            if (!rdNam.Checked && !rdNu.Checked)
                return false;

            // CMND: 9 chữ số
            string cmnd = new string(mtbCMND.Text.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(cmnd) || cmnd.Length != 9)
                return false;

            // Số điện thoại: 10 chữ số
            string soDT = new string(mtbSoDT.Text.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(soDT) || soDT.Length != 10)
                return false;

            // Địa chỉ
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
                return false;

            // Môn học (ít nhất 1 môn được chọn)
            if (clbMonHoc.CheckedItems.Count == 0)
                return false;

            return true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var sv = new Student
            {
                MSSV = mtbMSSV.Text.Trim(),
                HoLot = txtHoTen.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                Lop = cboLop.Text.Trim(),
                GioiTinh = rdNam.Checked ? "Nam" : "Nữ",
                CMND = new string(mtbCMND.Text.Where(char.IsDigit).ToArray()),
                DienThoai = new string(mtbSoDT.Text.Where(char.IsDigit).ToArray()),
                DiaChi = txtDiaChi.Text.Trim(),
                MonHoc = clbMonHoc.CheckedItems.Cast<string>().ToList()
            };
        
            manager.AddOrUpdate(sv);

            MessageBox.Show("Thêm sinh viên thành công!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadListView(); 
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!KiemTraThongTin())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(mssvDangChon))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng Student mới từ dữ liệu trên form
            var sv = new Student
            {
                MSSV = mssvDangChon, // Giữ nguyên MSSV cũ
                HoLot = txtHoTen.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                Lop = cboLop.Text.Trim(),
                GioiTinh = rdNam.Checked ? "Nam" : "Nữ",
                CMND = new string(mtbCMND.Text.Where(char.IsDigit).ToArray()),
                DienThoai = new string(mtbSoDT.Text.Where(char.IsDigit).ToArray()),
                DiaChi = txtDiaChi.Text.Trim(),
                MonHoc = clbMonHoc.CheckedItems.Cast<string>().ToList()
            };

            manager.AddOrUpdate(sv); 

            MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadListView();
        }

        private void xóaSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Lấy danh sách MSSV của các sinh viên được check
            var listMSSV = new List<string>();
            foreach (ListViewItem item in lvSinhVien.Items)
            {
                if (item.Checked)
                {
                    listMSSV.Add(item.Text); // item.Text là MSSV
                }
            }

            if (listMSSV.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa các sinh viên đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                manager.Delete(listMSSV);
                LoadListView();
                MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var dsLop = manager.GetAll().Select(sv => sv.Lop).Distinct().ToList();
            using (var frm = new frmTimKiem(dsLop))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var ketQua = manager.GetAll().Where(sv =>
                        (!string.IsNullOrEmpty(frm.MSSV) && sv.MSSV.Contains(frm.MSSV)) ||
                        (!string.IsNullOrEmpty(frm.HoLot) && sv.HoLot.IndexOf(frm.HoLot, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(frm.Ten) && sv.Ten.IndexOf(frm.Ten, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(frm.Lop) && sv.Lop == frm.Lop) ||
                        (frm.TimTheoNgaySinh && sv.NgaySinh.Date == frm.NgaySinh) ||
                        (!string.IsNullOrEmpty(frm.GioiTinh) && sv.GioiTinh == frm.GioiTinh) ||
                        (!string.IsNullOrEmpty(frm.CMND) && sv.CMND.Contains(frm.CMND)) ||
                        (!string.IsNullOrEmpty(frm.DienThoai) && sv.DienThoai.Contains(frm.DienThoai)) ||
                        (!string.IsNullOrEmpty(frm.DiaChi) && sv.DiaChi.Contains(frm.DiaChi)) ||
                        (!string.IsNullOrEmpty(frm.MonHoc) && sv.MonHoc.Contains(frm.MonHoc))
                    ).ToList();

                    HienThiDanhSach(ketQua);
                }
                else
                {
                    LoadListView();
                }
            }
        }
        private void HienThiDanhSach(List<Student> ds)
        {
            lvSinhVien.Items.Clear();
            foreach (var s in ds)
            {
                var item = new ListViewItem(s.MSSV);
                item.SubItems.Add(s.HoLot);
                item.SubItems.Add(s.Ten);
                item.SubItems.Add(s.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(s.Lop);
                item.SubItems.Add(s.CMND);
                item.SubItems.Add(s.DienThoai);
                item.SubItems.Add(s.DiaChi);
                item.Tag = s;
                lvSinhVien.Items.Add(item);
            }
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text file (*.txt)|*.txt|XML file (*.xml)|*.xml|JSON file (*.json)|*.json";
                ofd.Title = "Chọn file để mở";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string path = ofd.FileName;

                    // Tạo manager mới theo định dạng file
                    if (path.EndsWith(".txt"))
                        manager = new StudentManager(path, FileType.Text);
                    else if (path.EndsWith(".xml"))
                        manager = new StudentManager(path, FileType.Xml);
                    else if (path.EndsWith(".json"))
                        manager = new StudentManager(path, FileType.Json);
                 
                    LoadListView();
                }
            }
        }      
        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text file (*.txt)|*.txt|XML file (*.xml)|*.xml|JSON file (*.json)|*.json";
                sfd.Title = "Chọn nơi lưu file";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = sfd.FileName;
                    if (path.EndsWith(".txt"))
                        DocFile.WriteToText(path, manager.GetAll());
                    else if (path.EndsWith(".xml"))
                        DocFile.WriteToXml(path, manager.GetAll());
                    else if (path.EndsWith(".json"))
                        DocFile.WriteToJson(path, manager.GetAll());
                }
            }
        }
        
    }
}
