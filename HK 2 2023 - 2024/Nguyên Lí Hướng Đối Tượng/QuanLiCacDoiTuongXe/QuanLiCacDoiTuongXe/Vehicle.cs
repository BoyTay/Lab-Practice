using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongXe
{
    public class Vehicle
    {
        public string Name { get; set; }
        public int Speed {  get; set; }
        public virtual void Move()
        {
        }
        public virtual void Stop() 
        {
            Console.WriteLine("Xe hoi dang dung....");
        }
    }
}
