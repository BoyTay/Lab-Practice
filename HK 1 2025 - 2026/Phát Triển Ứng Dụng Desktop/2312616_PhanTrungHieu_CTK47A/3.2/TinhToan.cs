using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2
{
    internal class TinhToan
    {
        public static void CongHaiSo(int a, int b, ref int s)
        {
            s = a + b;
        }
       
        public static void TruHaiSo(int a, int b, ref int h)
        {
            h = a - b;
        }

        public static void NhanHaiSo(int a, int b, ref int t)
        {
            t = a * b;
        }

        public static void ChiaHaiSo(int a, int b, ref float c)
        {
            c = (float)a / b;
        }
    }
}
