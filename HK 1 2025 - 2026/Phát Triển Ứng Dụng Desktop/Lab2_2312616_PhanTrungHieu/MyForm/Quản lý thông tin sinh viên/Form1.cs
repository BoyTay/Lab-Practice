using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_thông_tin_sinh_viên
{
    public partial class frmSinhVien : Form
    {
        QuanLySinhVien qlsv = new QuanLySinhVien();

        public frmSinhVien()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv=new QuanLySinhVien();
            qlsv.DocTuFile("DanhSachSV.txt");
            LoadListView();
            CapNhatTongSinhVien();
        }
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Lop);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            string cn = "";
            foreach (string s in sv.ChuyenNganh)
                cn = cn + s + ",";
            cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);
        }

        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach(SinhVien sv in qlsv.dsSinhVien )
            {
                ThemSV(sv);
            }
        }

        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.MaSo = this.mtxtMaSo.Text;
            sv.HoTen = this.txtHoTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Lop = this.cboLop.Text;
            sv.Hinh = this.txtHinh.Text;
            if (this.rdNu.Checked)
               gt = false;
            sv.GioiTinh = gt;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                if (clbChuyenNganh.GetItemChecked(i))
                    cn.Add(this.clbChuyenNganh.Items[i].ToString());
            sv.ChuyenNganh = cn;
            return sv;
        }

        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[2].Text);
            sv.DiaChi = lvitem.SubItems[3].Text;
            sv.Lop = lvitem.SubItems[4].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[5].Text == "Nam")
                sv.GioiTinh = true;
            List<string> cn = new List<string>();
            string[] s = lvitem.SubItems[6].Text.Split(',');
            foreach (string t in s)
                cn.Add(t);
            sv.ChuyenNganh = cn;
            sv.Hinh = lvitem.SubItems[7].Text;
            return sv;
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MaSo;
            this.txtHoTen.Text = sv.HoTen;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cboLop.Text = sv.Lop;
            this.txtHinh.Text = sv.Hinh;
            this.pbHinh.ImageLocation = sv.Hinh;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                this.clbChuyenNganh.SetItemChecked(i, false);
            foreach (string s in sv.ChuyenNganh)
                for (int i = 0; i < this.clbChuyenNganh.Items.Count; i++)
                    if (s.CompareTo(this.clbChuyenNganh.Items[i])==0)
                        this.clbChuyenNganh.SetItemChecked(i, true);
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cboLop.Text = this.cboLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;
            for (int i = 0; i < this.clbChuyenNganh.Items.Count - 1; i++)
            {
                this.clbChuyenNganh.SetItemChecked(i,false);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView();
            this.btnMacDinh.PerformClick();
        }
        private int SoSanhTheoMa(object sv1, object sv2)
        {
            SinhVien sv = sv2 as SinhVien;
            return sv.MaSo.CompareTo(sv1);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MaSo,SoSanhTheoMa);
            if(kqsua)
            {
                this.LoadListView();
            }    
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open File Image";
            dlg.Filter = "Image File|*.bmp;*.jpg;*.png|All File|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbHinh.Image = Image.FromFile(dlg.FileName);
            }
        }

        private void CapNhatTongSinhVien()
        {
            lblTongSV.Text = "Tổng Sinh Viên: " + qlsv.dsSinhVien.Count.ToString();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sắpXếpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuyChon frm = new frmTuyChon();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                switch (frm.Kieu)
                {
                    case KieuTuyChon.MaSV:
                        qlsv.dsSinhVien.Sort((a, b) => a.MaSo.CompareTo(b.MaSo));
                        break;
                    case KieuTuyChon.HoTen:
                        qlsv.dsSinhVien.Sort((a, b) => a.HoTen.CompareTo(b.HoTen));
                        break;
                    case KieuTuyChon.NgaySinh:
                        qlsv.dsSinhVien.Sort((a, b) => a.NgaySinh.CompareTo(b.NgaySinh));
                        break;
                }
                LoadListView(); // Cập nhật lại danh sách trên ListView
            }
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuyChon frm = new frmTuyChon();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string chuoiTim = frm.ChuoiTim;
                if (string.IsNullOrWhiteSpace(chuoiTim))
                {
                    MessageBox.Show("Hãy nhập thông tin tìm!", "Lỗi nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<SinhVien> ketQua = new List<SinhVien>();
                switch (frm.Kieu)
                {
                    case KieuTuyChon.MaSV:
                        ketQua = qlsv.dsSinhVien.Where(sv => sv.MaSo.Equals(chuoiTim, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case KieuTuyChon.HoTen:
                        ketQua = qlsv.dsSinhVien.Where(sv => sv.HoTen.IndexOf(chuoiTim, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                        break;
                    case KieuTuyChon.NgaySinh:
                        ketQua = qlsv.dsSinhVien.Where(sv => sv.NgaySinh.ToShortDateString().Equals(chuoiTim)).ToList();
                        break;
                }

                // Hiển thị kết quả trên ListView
                this.lvSinhVien.Items.Clear();
                foreach (SinhVien sv in ketQua)
                {
                    ThemSV(sv);
                }

                MessageBox.Show("Số sinh viên tìm thấy: " + ketQua.Count, "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
