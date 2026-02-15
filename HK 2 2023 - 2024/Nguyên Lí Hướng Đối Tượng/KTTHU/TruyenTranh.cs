using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTTHU
{
    public class TruyenTranh:IAnPham
    {
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
        public TruyenTranh()
        {

        }
        public TruyenTranh(float giatien, string nhaxuatban, string ten)
        {
            this.giatien = giatien;
            this.nhaxuatban = nhaxuatban;
            this.ten = ten;
        }
        public override string ToString()
        {
            return $"{Ten,-20} | {NhaXuatBan,-15} | {GiaTien,-5} |";
        }
    }
}
