using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTTHU
{
    public class Sach:IAnPham
    {
        float giatien;
        string nhaxuatban;
        public int SoTrang;
        string ten;
        public float GiaTien
        {
            get
            {
                return giatien;
            }
        }
        public string NhaXuatBan
        {
            get
            {
                return nhaxuatban;
            }
        }
        public string Ten
        {
            get 
            {
                return ten;
            
            }
            set
            {
                ten = value;
            }
        }
        public Sach()
        {

        }
        public Sach(float giatien,string nhaxuatban,string ten,int soTrang)
        {
            this.giatien = giatien;
            this.nhaxuatban = nhaxuatban;
            this.ten = ten;
            SoTrang = soTrang;
        }
        public override string ToString()
        {
            return $" {Ten,-20} | {NhaXuatBan,-15} | {GiaTien,-5}  | { SoTrang,-25} |";
        }
    }
}
