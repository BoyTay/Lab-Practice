using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiAnPham
{
    public class AnPham
    {
        public int Nam {  get; set; }
        public string NhaXuatBan { get; set; }
        public string TuaDe {  get; set; }
        public AnPham(int nam,string nhaXuatBan,string tuaDe)
        {
            Nam = nam;
            NhaXuatBan = nhaXuatBan;
            TuaDe = tuaDe;
        
        }
        public void HienThiThongTin()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return $"{Nam,-5} | {NhaXuatBan,-15} | {TuaDe,-20} ";
        }
    }
}
