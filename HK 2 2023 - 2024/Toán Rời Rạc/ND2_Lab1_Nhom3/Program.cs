using System;
using System.IO;
using System.Collections.Generic;

namespace TapConNhom3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] S = { 1, 2, 3, 4 };
            int n = S.Length;
            Console.WriteLine("Cac tap con cua tap S: ");
            TapCon(S, n);


        }
        static void TapCon(int[] S, int n)
        {
            using (StreamWriter writer = new StreamWriter("b.txt"))
            {

                for (int x = 0; x < (1 << n); x++)
                {
                    string Binary = Convert.ToString(x, 2).PadLeft(n, '0');
                    var DanhSach = new HashSet<int>();
                    for (int i = 0; i < n; i++)
                    {
                        if (Binary[i] == '1')
                        {
                            DanhSach.Add(S[i]);
                        }
                    }
                    Console.Write("[");
                    foreach (int element in DanhSach)
                    {
                        Console.Write($"{element} ");
                    }
                    Console.WriteLine("]");
                    XuatRaFile(writer, DanhSach);
                }
            }
        }
        static void XuatRaFile(StreamWriter writer, HashSet<int> DanhSach)
        {
            writer.Write("[");


            foreach (int element in DanhSach)
            {
                writer.Write($"{element} ");
            }
            writer.WriteLine("]");
        }

    }

}