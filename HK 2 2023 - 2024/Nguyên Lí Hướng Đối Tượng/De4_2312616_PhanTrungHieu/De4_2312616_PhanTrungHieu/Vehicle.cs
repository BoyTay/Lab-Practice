using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De4_2312616_PhanTrungHieu
{
    public class Vehicle : IVehicle, IDriveable
    {
        public string Loai { get; set; }
        public string Ten { get; set; }
        public string Hang { get; set; }
        public float TocDo { get; set; }
        public int NhienLieu { get; set; }
        public Vehicle(string loai, string ten, string hang, float tocDo, int nhienLieu)
        {
            Loai = loai;
            Ten = ten;
            Hang = hang;
            TocDo = tocDo;
            NhienLieu = nhienLieu;
        }
        public override string ToString()
        {
            return $"{Loai,-16}{Ten,-15} {Hang,-20} {TocDo,-7} {NhienLieu + "L",-10}";
        }
    }
}
