using System;
using System.Collections.Generic;
using System.Text;

namespace BT1_QuanLiThuVien
{
    class BanSaoSach
    {
        private string _maSach;
        private int _soBanSao;

        public BanSaoSach(string maSach, int soBanSao)
        {
            _maSach = maSach;
            _soBanSao = soBanSao;
        }

        public string MaSach { get => _maSach; set => _maSach = value; }
        public int SoBanSao { get => _soBanSao; set => _soBanSao = value; }

        public override string ToString()
        {
            return $"Ma sach: {_maSach}\nSo ban sao: {_soBanSao}";
        }
    }
}
