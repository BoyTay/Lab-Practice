using System;
using System.Collections.Generic;
using System.Text;

namespace BT1_QuanLiThuVien
{
    class ThongTinMuon
    {
        private string _soThe;
        private string _maSach;
        private DateTime _ngayMuon;
        private DateTime _ngayTra;

        public ThongTinMuon(string soThe, string maSach, DateTime ngayMuon, DateTime ngayTra)
        {
            _soThe = soThe;
            _maSach = maSach;
            _ngayMuon = ngayMuon;
            _ngayTra = ngayTra;
        }

        public string SoThe { get => _soThe; set => _soThe = value; }
        public string MaSach { get => _maSach; set => _maSach = value; }
        public DateTime NgayMuon { get => _ngayMuon; set => _ngayMuon = value; }
        public DateTime NgayTra { get => _ngayTra; set => _ngayTra = value; }

        public override string ToString()
        {
            return $"So the: {_soThe}\nMa sach: {_maSach}\nNgay muon: {_ngayMuon.ToString("dd/MM/yyyy")}\nNgay tra: {_ngayTra.ToString("dd/MM/yyyy")}";
        }
    }
}
