using System;
using System.Collections.Generic;
using System.Text;

namespace BT1_QuanLiThuVien
{
    class NguoiMuon
    {
        private string _soThe;
        private string _hoTen;
        private string _diaChi;
        private string _soDienThoai;

        public NguoiMuon(string soThe, string hoTen, string diaChi, string soDienThoai)
        {
            _soThe = soThe;
            _hoTen = hoTen;
            _diaChi = diaChi;
            _soDienThoai = soDienThoai;
        }

        public string SoThe { get => _soThe; set => _soThe = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }

        public override string ToString()
        {
            return $"So the: {_soThe}\nHo ten: {_hoTen}\nĐia chi: {_diaChi}\nSo đien thoai: {_soDienThoai}";
        }
    }
}

