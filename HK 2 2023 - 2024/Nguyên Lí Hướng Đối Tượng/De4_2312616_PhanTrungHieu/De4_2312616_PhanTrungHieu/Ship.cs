using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De4_2312616_PhanTrungHieu
{
    public class Ship : Vehicle, IDriveable
    {
        public int Buom { get; set; }
        public Ship(string loai, string ten, string hang, float tocDo, int nhienLieu, int buom) : base(loai, ten, hang, tocDo, nhienLieu)
        {
            Buom = buom;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Buom,-10}";
        }
    }
}
