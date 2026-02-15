using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class KiNang
    {
        public string MSKN { get; set; }
        public string TenKN { get; set; }
        public KiNang() { }
        public KiNang(string mSKN, string tenKN)
        {
            MSKN = mSKN;
            TenKN = tenKN;
        }
        public KiNang(string line)
        {
            string[] s = line.Split(',');
            MSKN = s[0];
            TenKN = s[1];
        }

    }

}
