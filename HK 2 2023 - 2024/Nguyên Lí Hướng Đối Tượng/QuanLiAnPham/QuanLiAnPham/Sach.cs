using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiAnPham
{
    public class Sach:AnPham
    {
        public string ISBN {  get; set; }   
        public string TacGia { get; set; }
        public Sach (int nam, string nhaXuatBan, string tuaDe,string isbn,string tacGia):
            base(nam,nhaXuatBan,tuaDe)
        {
            ISBN = isbn;
            TacGia = tacGia;
        }
        public void HienThiThongTin()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return $"{base.ToString()} |  {ISBN,-10} | {TacGia,-10} | ";
        }

    }
}
