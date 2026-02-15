using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De4_2312616_PhanTrungHieu
{
    public class Car : Vehicle
    {

        public Car(string loai, string ten, string hang, float tocDo, int nhienLieu) : base(loai, ten, hang, tocDo, nhienLieu)
        {
        }
        public override string ToString()
        {
            return $"{base.ToString()}";
        }

    }
}
