using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachAnPham
{
    public class TapChi:IAnPham
    {
        
        public float GiaTien {  get; set; }
        public string NhaXuatBan {  get; set; }
        public string Ten {  get; set; }
        public string DiaChi { get; set; }
        public TapChi(float giaTien,string nhaXuatBan,string ten,string diaChi)
        { 
            GiaTien = giaTien;
            NhaXuatBan = nhaXuatBan;
            Ten = ten;
            DiaChi = diaChi;
        
        }
        public override string ToString()
        {
            return $"| {Ten,-20} | {NhaXuatBan,-20} | {GiaTien,-5} | {DiaChi,-30} |";
        }
    }
}
