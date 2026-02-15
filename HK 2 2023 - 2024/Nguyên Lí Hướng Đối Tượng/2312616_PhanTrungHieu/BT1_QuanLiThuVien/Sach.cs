using System;
using System.Collections.Generic;
using System.Text;

namespace BT1_QuanLiThuVien
{
    class Sach
    {
        private string _maSach;
        private string _tenSach;
        private string _nhaXuatBan;
        private string _tacGia;

        public Sach(string maSach, string tenSach, string nhaXuatBan, string tacGia)
        {
            _maSach = maSach;
            _tenSach = tenSach;
            _nhaXuatBan = nhaXuatBan;
            _tacGia = tacGia;
        }

        public string MaSach { get => _maSach; set => _maSach = value; }
        public string TenSach { get => _tenSach; set => _tenSach = value; }
        public string NhaXuatBan { get => _nhaXuatBan; set => _nhaXuatBan = value; }
        public string TacGia { get => _tacGia; set => _tacGia = value; }

        public override string ToString()
        {
            return $"Ma sach: {_maSach}\nTen sach: {_tenSach}\nNha xuat ban: {_nhaXuatBan}\nTac gia: {_tacGia}";
        }
    }
}

