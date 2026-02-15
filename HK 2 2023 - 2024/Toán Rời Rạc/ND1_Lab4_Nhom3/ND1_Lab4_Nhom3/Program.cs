using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ND1_Lab4_Nhom3
{
    internal class Program
    {
        static int[] T;

        static void Main(string[] args)
        {
            int n, k;
            do
            {
                Console.Write("Nhap vào gia tri cho n (n>k): ");
                n = int.Parse(Console.ReadLine());
                Console.Write("Nhap vào gia tri cho k (n>k): ");
                k = int.Parse(Console.ReadLine());
            } while (n < k);
            T = new int[n + 1]; 
            ToHopKN(k, n);
            Console.ReadKey();
        }

        static void XuatMang(int[] A, int n)
        {
            for (int i = 1; i <= n; i++)
                Console.Write(A[i].ToString() + " ");
            Console.WriteLine();
        }

        static void ToHopKN(int k, int n)
        {
            int i, p;
            int dem = 0;
            for (i = 1; i <= k; i++) T[i] = i;
            p = k;
            while (p >= 1)
            {
                dem++;
                Console.Write("\n Tap con thu " + dem.ToString() + " : ");
                XuatMang(T, k);
                // 2 IF SAU DE TANG DAN THEO Y TUONG CUA THUAT TOAN
                if (T[k] == n) p--; else p = k;
                if (p >= 1) for (i = k; i >= p; i--) T[i] = T[p] + i - p + 1; //
            }
        }
    }
}
