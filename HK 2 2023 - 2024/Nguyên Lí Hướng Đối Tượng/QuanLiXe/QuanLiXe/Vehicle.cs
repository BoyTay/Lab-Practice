using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiXe
{
    public class Vehicle:IVehicle
    {
        public string Ten {  get; set; }
        public int TocDo {  get; set; }
        public string Loai {  get; set; }
        public void Chay()
        {
            Console.WriteLine("Dang khoi dong");
        }
        public void Dung()
        {
            Console.WriteLine("Dang dung lai");        
        }
    }
}
