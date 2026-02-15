using System;
using System.Collections.Generic;
using System.Text;

namespace BT1_QuanLiThuVien
{
    class NhaXuatBan
    {

        private string _tenNhaXuatBan;
        private string _diaChi;
        private string _soDienThoai;

        public NhaXuatBan(string tenNhaXuatBan, string diaChi, string soDienThoai)
        {
            _tenNhaXuatBan = tenNhaXuatBan;
            _diaChi = diaChi;
            _soDienThoai = soDienThoai;
        }

        public string TenNhaXuatBan { get => _tenNhaXuatBan; set => _tenNhaXuatBan = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }

        public override string ToString()
        {
            return $"TEn nha xuat ban: {_tenNhaXuatBan}\nĐia chi: {_diaChi}\nSo đien thoai: {_soDienThoai}";
        }
    }
}
