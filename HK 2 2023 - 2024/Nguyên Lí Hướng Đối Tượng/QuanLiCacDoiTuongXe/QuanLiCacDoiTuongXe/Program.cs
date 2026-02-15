using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiCacDoiTuongXe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Class Car!!");
            Vehicle car1 = new Car();
            car1.Move();
            car1.Stop();
            Console.WriteLine("\nClass Motorcycle!!");
            Vehicle v1 = new Motorcycle();
            v1.Move();
            v1.Stop();
            Console.ReadKey();
        }
    }
}
