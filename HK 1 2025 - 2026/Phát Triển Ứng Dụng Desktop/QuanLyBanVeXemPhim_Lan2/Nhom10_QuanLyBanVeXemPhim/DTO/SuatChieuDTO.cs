using System;

namespace Nhom10_QuanLyBanVeXemPhim.DTO
{
    public class SuatChieuDTO
    {
        public int MaSC { get; set; }
        public int MaPhong { get; set; }
        public int MaPhim { get; set; }
        public DateTime ThoiGianChieu { get; set; }
        public decimal GiaVe { get; set; }

        // Mới thêm để hiển thị
        public string TenPhong { get; set; }
        public string TenPhim { get; set; }

        public SuatChieuDTO() { }

        public SuatChieuDTO(int maSC, int maPhong, int maPhim, DateTime thoiGianChieu, decimal giaVe,
                            string tenPhong = null, string tenPhim = null)
        {
            MaSC = maSC;
            MaPhong = maPhong;
            MaPhim = maPhim;
            ThoiGianChieu = thoiGianChieu;
            GiaVe = giaVe;
            TenPhong = tenPhong;
            TenPhim = tenPhim;
        }
    }
}
