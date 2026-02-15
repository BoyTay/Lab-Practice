using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongXe
{
    public class Car:Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Xe hoi dang di chuyen");
        }
        public override void Stop()
        {
            Console.WriteLine("Xe hoi dang dung");
        }
    }
}
