using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace KTTHU
{
    public class TapChi:IAnPham
    {
        public string DiaChi;
        float giatien;
        string nhaxuatban;
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
        public TapChi() { }
        public TapChi(string nhaXuatBan,string ten,float giaTien,string diaChi)
        {
            nhaxuatban= nhaXuatBan;
            this.ten= ten;
            giatien= giaTien;
            DiaChi = diaChi;
        }
        public override string ToString()
        {
            return$"{Ten,-20} | {NhaXuatBan,-15} | {GiaTien,-5} | {DiaChi,-25} |";
        }
    }
}
