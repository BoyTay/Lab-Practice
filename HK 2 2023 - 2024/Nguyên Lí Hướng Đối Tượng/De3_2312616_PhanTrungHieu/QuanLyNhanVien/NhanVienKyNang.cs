using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class NhanVienKyNang
    {
        public string MaNV { get; set; }
        public Dictionary<string, int> KiNang = new Dictionary<string, int>();

        public NhanVienKyNang() { }
        public NhanVienKyNang(string maNV, string mSKN, int mucDo)
        {
            MaNV = maNV;
            KiNang[mSKN] = mucDo;

        }
        public NhanVienKyNang(string line)
        {
            string[] s = line.Split(',');
            MaNV = s[0];
            KiNang[s[1]] = int.Parse(s[2]);
        }
        public void ThemKiNang(string line)
        {
            string[] s = line.Split(',');
            KiNang[s[1]] = int.Parse(s[2]);
        }
    }
}
