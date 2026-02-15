using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongXe
{
   public  class Motorcycle:Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Xe may dang chay");
        }
        public override void Stop()
        {
            Console.WriteLine("Xe may dang dung");
        }
    }
}
