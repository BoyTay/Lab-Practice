using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    internal class ChiNhanh
    {
        string MSCN { get; }
        string TenCN { get; }
        public ChiNhanh() { }
        public ChiNhanh(string mSCN, string tenCN)
        {
            MSCN = mSCN;
            TenCN = tenCN;
        }
        public ChiNhanh(string line)
        {
            string[] s = line.Split(',');
            MSCN = s[0];
            TenCN = s[1];
        }
    }

}
