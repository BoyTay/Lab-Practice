using De3_2312616_PhanTrungHieu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De3_2312616_PhanTrungHieu
{
    public class Tour_TP : ITour, IThanhPho
    {

        public int SoNgay { get; set; }
        public string MaTP { get; set; }
        public string MaTour { get; set; }
        public int TongSoNgay { get; set; }
        public string TenTP { get; set; }

        public Tour_TP(string maTP, int soNgay, string maTour)
        {
            MaTour = maTour;
            MaTP = maTP;
            SoNgay = soNgay;

        }
        public override string ToString()
        {
            return $"MaTour: {MaTour}  MaTP: {MaTP}, SoNgay: {SoNgay}";
        }
    }
}
