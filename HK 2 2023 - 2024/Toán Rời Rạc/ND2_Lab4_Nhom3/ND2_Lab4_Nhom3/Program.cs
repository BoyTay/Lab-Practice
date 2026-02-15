using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiaiDeQui
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao gia tri cho n: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Ket qua:" + HeThucDeQui(n));
            Console.ReadLine();
        }

        static int HeThucDeQui(int n)
        {
            if (n == 0) return 1;
            else if (n == 1) return 3;
            else return (5 * HeThucDeQui(n - 1) - 6 * HeThucDeQui(n - 2));

        }

    }
}
