using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4
{
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPham { get; set; }
        public DateTime NgaySanXuat { get; set; }

        public SanPham() { }

        public int NamHetHan()
        {
            return NgaySanXuat.AddYears(3).Year;
        }

        public string HienThi()
        {
            return $"Mã sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham}, Loại sản phẩm: {LoaiSanPham}, Ngày sản xuất: {NgaySanXuat:dd/MM/yyyy}, Năm hết hạn: {NamHetHan()}";
        }
    }
}
