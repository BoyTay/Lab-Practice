using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    public class Nguoi
    {
        public string DiaChi { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }

        public Nguoi(string diaChi, string ten, int tuoi)
        {
            DiaChi = diaChi;
            Ten = ten;
            Tuoi = tuoi;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"| {Ten,-15} | {Tuoi,-5} | {DiaChi,-10} |";
        }
    }
}
