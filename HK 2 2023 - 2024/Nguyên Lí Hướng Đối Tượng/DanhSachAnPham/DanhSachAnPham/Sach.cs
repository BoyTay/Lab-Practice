using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachAnPham
{
    public class Sach:IAnPham
    {
        public float GiaTien {  get; set; }
        public string NhaXuatBan { get; set; }
        public string Ten { get; set; }
        public int SoTrang { get; set; }
        public Sach(float giaTien, string nhaXuatBan, string ten, int soTrang)
        {
            GiaTien = giaTien;
            NhaXuatBan = nhaXuatBan;
            Ten = ten;
            SoTrang = soTrang;
        }
        public override string ToString()
        {
            return $"| {Ten,-20} | {NhaXuatBan,-20} | {GiaTien,-5} | {SoTrang,-30} |";
        }
    }
}
