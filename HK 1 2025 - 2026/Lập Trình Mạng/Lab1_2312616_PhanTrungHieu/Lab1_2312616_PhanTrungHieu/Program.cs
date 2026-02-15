using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;//Cung cấp dns,IPHostEntry,IPAddress

namespace Lab1_2312616_PhanTrungHieu
{
    class Program
    {
        static void GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);

                // Hiển thị tên miền
                Console.WriteLine("Tên miền: " + hostInfo.HostName);

                // Hiển thị danh sách địa chỉ IP
                Console.Write("Địa chỉ IP: ");
                foreach (IPAddress ipaddr in hostInfo.AddressList)
                {
                    Console.Write(ipaddr.ToString() + " ");
                }
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Không phân giải được tên miền: " + host + "\n");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            foreach (string arg in args)
            {
                Console.WriteLine("Phân giải tên miền: " + arg);
                GetHostInfo(arg);
                //Console.WriteLine("");
            }
            Console.ReadKey();

        }
    }
}
