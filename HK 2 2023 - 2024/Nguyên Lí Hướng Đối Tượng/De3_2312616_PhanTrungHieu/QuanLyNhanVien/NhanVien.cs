using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class NhanVien
    {
        public string MANV { get; }
        public string Ho { get; }
        public string Ten { get; }
        public string NgaySinh { get; }
        public string NgayVaoLam { get; }
        public string MSCN { get; }
        public NhanVien() { }
        public NhanVien(string nANV, string ho, string ten, string ngaySinh, string ngayVaoLam, string mSCN)
        {
            MANV = nANV;
            Ho = ho;
            Ten = ten;
            NgaySinh = ngaySinh;
            NgayVaoLam = ngayVaoLam;
            MSCN = mSCN;
        }
        public NhanVien(string line)
        {
            string[] s = line.Split(',');
            MANV = s[0];
            Ho = s[1];
            Ten = s[2];
            NgaySinh = s[3];
            NgayVaoLam = s[4];
            MSCN = s[5];
        }
    }

}
