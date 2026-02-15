using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De3_2312616_PhanTrungHieu
{
    public class Lich_TourDL : Tour
    {
        public DateTime NgayKH { get; set; }
        public string TenHDV { get; set; }
        public int SoNguoi { get; set; }
        public string TenKH { get; set; }

        public Lich_TourDL(string maTour, DateTime ngayKH, string tenHDV, int soNguoi, string tenKH, int tongSoNgay) : base(maTour, tongSoNgay)
        {
            MaTour = maTour;
            NgayKH = ngayKH;
            TenHDV = tenHDV;
            SoNguoi = soNguoi;
            TenKH = tenKH;
            TongSoNgay = tongSoNgay;
        }
        public override string ToString()
        {
            return $"MaTour: {MaTour}, NgayKH: {NgayKH}, TenHDV: {TenHDV}, SoNguoi: {SoNguoi}, TenKH: {TenKH}";
        }
    }

}
