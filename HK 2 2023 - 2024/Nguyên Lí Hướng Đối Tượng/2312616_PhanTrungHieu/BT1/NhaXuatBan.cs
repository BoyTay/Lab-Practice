using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class NhaXuatBan
    {
        public string TenNhaXuatBan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public NhaXuatBan(string tenNhaXuatBan, string diaChi, string soDienThoai)
        {
            TenNhaXuatBan = tenNhaXuatBan;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
        }

        public override string ToString()
        {
            return $"Ten nha xuat ban: {TenNhaXuatBan}\nDia chi: {DiaChi}\nSo dien thoai: {SoDienThoai}";
        }
    }
}
