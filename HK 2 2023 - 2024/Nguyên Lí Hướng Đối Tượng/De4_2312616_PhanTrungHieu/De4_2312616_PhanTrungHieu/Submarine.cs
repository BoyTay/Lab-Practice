using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De4_2312616_PhanTrungHieu
{
    public class Submarine : Vehicle, IFloatable, IDiveable
    {
        public int Buom { get; set; }
        public float DoSau { get; set; }
        public Submarine(string loai, string ten, string hang, float tocDo, int nhienLieu, int buom, float doSau) : base(loai, ten, hang, tocDo, nhienLieu)
        {
            Buom = buom;
            DoSau = doSau;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Buom,-10} {DoSau,-10}";
        }

    }
}
