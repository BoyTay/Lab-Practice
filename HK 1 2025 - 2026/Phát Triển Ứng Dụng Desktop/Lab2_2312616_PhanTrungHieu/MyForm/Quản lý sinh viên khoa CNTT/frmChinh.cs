using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Quản_lý_sinh_viên_khoa_CNTT
{
    public partial class frmChinh : Form
    {
        private ArrayList dsSinhVien=new ArrayList();
        private bool daThayDoi = false;
        public frmChinh()
        {
            InitializeComponent();
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Chọn hình sinh viên";
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtHinh.Text = dlg.FileName;
                picHinh.Image = Image.FromFile(dlg.FileName);
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            mtbMaSV.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtHinh.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            rdNam.Checked = true;
            cboLop.SelectedIndex = 0;
            mtbSoDT.Text = "";
            picHinh.Image = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien
            {
                MaSV = mtbMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                Phai = rdNam.Checked ? "Nam" : "Nữ",
                Lop = cboLop.Text,
                SoDT = mtbSoDT.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Hinh = txtHinh.Text.Trim()
            };

            // Tìm sinh viên theo mã
            int index = -1;
            for (int i = 0; i < dsSinhVien.Count; i++)
            {
                if (((SinhVien)dsSinhVien[i]).MaSV == sv.MaSV)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0)
            {
                dsSinhVien[index] = sv; // Cập nhật
            }
            else
            {
                dsSinhVien.Add(sv); // Thêm mới
            }
            HienThiLenListView();
            daThayDoi = true;
        }

        private void HienThiLenListView()
        {
            lvSinhVien.Items.Clear();
            foreach (SinhVien sv in dsSinhVien)
            {
                ListViewItem item = new ListViewItem(sv.MaSV);
                item.SubItems.Add(sv.HoTen);
                item.SubItems.Add(sv.Phai);
                item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(sv.Lop);
                item.SubItems.Add(sv.SoDT);
                item.SubItems.Add(sv.Email);
                item.SubItems.Add(sv.DiaChi);
                item.SubItems.Add(sv.Hinh);
                lvSinhVien.Items.Add(item);
            }
        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                ListViewItem item = lvSinhVien.SelectedItems[0];
                mtbMaSV.Text = item.SubItems[0].Text;
                txtHoTen.Text = item.SubItems[1].Text;
                rdNam.Checked = item.SubItems[2].Text == "Nam";
                rdNu.Checked = item.SubItems[2].Text == "Nữ";
                dtpNgaySinh.Value = DateTime.ParseExact(item.SubItems[3].Text, "dd/MM/yyyy", null);
                cboLop.Text = item.SubItems[4].Text;
                mtbSoDT.Text = item.SubItems[5].Text;
                txtEmail.Text = item.SubItems[6].Text;
                txtDiaChi.Text = item.SubItems[7].Text;
                txtHinh.Text = item.SubItems[8].Text;
                picHinh.ImageLocation = item.SubItems[8].Text;
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvSinhVien.SelectedItems)
            {
                // Xóa khỏi ArrayList
                for (int i = 0; i < dsSinhVien.Count; i++)
                {
                    if (((SinhVien)dsSinhVien[i]).MaSV == item.SubItems[0].Text)
                    {
                        dsSinhVien.RemoveAt(i);
                        break;
                    }
                }
                // Xóa khỏi ListView
                lvSinhVien.Items.Remove(item);
            }
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            dsSinhVien = DocDanhSachTuFile("DSSV.txt");
            HienThiLenListView();
        }

        private ArrayList DocDanhSachTuFile(string filePath)
        {
            ArrayList ds = new ArrayList();
            if (!System.IO.File.Exists(filePath))
                return ds;

            var lines = System.IO.File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                // Giả sử mỗi dòng có dạng: MaSV|HoTen|Phai|NgaySinh|Lop|SoDT|Email|DiaChi|Hinh
                var parts = line.Split('|');
                if (parts.Length < 9) continue;

                SinhVien sv = new SinhVien
                {
                    MaSV = parts[0],
                    HoTen = parts[1],
                    Phai = parts[2],
                    NgaySinh = DateTime.ParseExact(parts[3], "dd/MM/yyyy", null),
                    Lop = parts[4],
                    SoDT = parts[5],
                    Email = parts[6],
                    DiaChi = parts[7],
                    Hinh = parts[8]
                };
                ds.Add(sv);
            }
            return ds;
        }

        private void tảiLạiDSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dsSinhVien = DocDanhSachTuFile("DSSV.txt");
            HienThiLenListView();
        }

        private void frmChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (daThayDoi)
            {
                var result = MessageBox.Show("Bạn có muốn lưu danh sách đã thay đổi không?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    LuuDanhSachVaoFile("DSSV.txt");
                }
            }
        }

        private void LuuDanhSachVaoFile(string filePath)
        {
            using (var writer = new System.IO.StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (SinhVien sv in dsSinhVien)
                {
                    // Ghi theo định dạng: MaSV|HoTen|Phai|NgaySinh|Lop|SoDT|Email|DiaChi|Hinh
                    string line = string.Join("|",
                        sv.MaSV,
                        sv.HoTen,
                        sv.Phai,
                        sv.NgaySinh.ToString("dd/MM/yyyy"),
                        sv.Lop,
                        sv.SoDT,
                        sv.Email,
                        sv.DiaChi,
                        sv.Hinh
                    );
                    writer.WriteLine(line);
                }
            }
        }
    }
}
