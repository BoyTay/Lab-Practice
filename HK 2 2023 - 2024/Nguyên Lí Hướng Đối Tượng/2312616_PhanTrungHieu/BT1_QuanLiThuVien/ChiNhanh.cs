using System;
using System.Collections.Generic;
using System.Text;

namespace BT1_QuanLiThuVien
{
    class ChiNhanh
    {
        private string _maChiNhanh;
        private string _tenChiNhanh;
        private string _diaChi;

        public ChiNhanh(string maChiNhanh, string tenChiNhanh, string diaChi)
        {
            _maChiNhanh = maChiNhanh;
            _tenChiNhanh = tenChiNhanh;
            _diaChi = diaChi;
        }

        public string MaChiNhanh { get => _maChiNhanh; set => _maChiNhanh = value; }
        public string TenChiNhanh { get => _tenChiNhanh; set => _tenChiNhanh = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }

        public override string ToString()
        {
            return $"Ma chi nhanh: {_maChiNhanh}\nTen chi nhanh: {_tenChiNhanh}\nĐia chi: {_diaChi}";
        }
    }
}
