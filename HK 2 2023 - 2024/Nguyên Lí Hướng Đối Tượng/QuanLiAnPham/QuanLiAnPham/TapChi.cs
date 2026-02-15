using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiAnPham
{
    public class TapChi:AnPham
    {
        public int So {  get; set; }
        public int Tap { get; set; }

        public TapChi(int nam, string nhaXuatBan, string tuaDe, int so, int tap)
            : base(nam, nhaXuatBan, tuaDe)
        {
            So=so;
            Tap=tap;
        }
        public void HienThiThongTin()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return $"{base.ToString()} | {So,-15} | {Tap,-12} | ";
        }
    }
}
