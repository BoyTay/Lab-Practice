using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De3_2312616_PhanTrungHieu 
{
    public class Tour : ITour
    {
        public string MaTour { get; set; }
        public int TongSoNgay { get; set; }

        public Tour(string maTour, int tongSoNgay)
        {
            MaTour = maTour;
            TongSoNgay = tongSoNgay;
        }

        public override string ToString()
        {
            return $"MaTour: {MaTour}, TongSoNgay: {TongSoNgay}";
        }
    }
}
