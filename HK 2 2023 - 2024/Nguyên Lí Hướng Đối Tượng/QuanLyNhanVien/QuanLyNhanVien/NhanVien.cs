using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    public class NhanVien : Nguoi
    {
        public decimal Luong { get; set; }
        public string MaNhanVien { get; set; }
        public string ViTri { get; set; }

        public NhanVien(decimal luong, string maNhanVien, string viTri, string diaChi, string ten, int tuoi)
            : base(diaChi, ten, tuoi)
        {
            Luong = luong;
            MaNhanVien = maNhanVien;
            ViTri = viTri;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Luong,-11} | {MaNhanVien,-10} | {ViTri,-25} |";
        }
    }
}
