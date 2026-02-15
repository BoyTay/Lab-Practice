using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class Sach
    {     
            public string MaSach { get; set; }
            public string TenSach { get; set; }
            public string NhaXuatBan { get; set; }
            public string TacGia { get; set; }

            public Sach(string maSach, string tenSach, string nhaXuatBan, string tacGia)
            {
                MaSach = maSach;
                TenSach = tenSach;
                NhaXuatBan = nhaXuatBan;
                TacGia = tacGia;
            }

            public override string ToString()
            {
                return $"Ma sach: {MaSach}\nTen sach: {TenSach}\nNha xuat ban: {NhaXuatBan}\nTac gia: {TacGia}";
            }      
    }
}
