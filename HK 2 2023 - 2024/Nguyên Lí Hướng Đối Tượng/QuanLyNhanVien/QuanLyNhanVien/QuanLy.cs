using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    public class QuanLy : NhanVien
    {
        public string Phong { get; set; }

        public QuanLy(string phong, decimal luong, string maNhanVien, string viTri, string diaChi, string ten, int tuoi) : base(luong, maNhanVien, viTri, diaChi, ten, tuoi)
        {
            Phong = phong;
        }

        public override string ToString()
        {
            return $"{base.ToString()}  {Phong} ";
        }
    }
}
