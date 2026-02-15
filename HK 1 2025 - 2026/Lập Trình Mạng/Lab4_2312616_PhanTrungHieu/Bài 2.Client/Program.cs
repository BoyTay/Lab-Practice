using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bài_2.Client
{
    internal class Program
    {
        public static void Main(string[] args)
        {        

            TcpClient client;
            try
            {
                client = new TcpClient("127.0.0.1", 9050);
            }
            catch (SocketException)
            {
                Console.WriteLine("Khong ket noi duoc voi server");
                return;
            }

            NetworkStream ns = client.GetStream();
            while (true)
            {
                Employee emp = new Employee();

                Console.Write("Nhap EmployeeID: ");
                emp.EmployeeID = int.Parse(Console.ReadLine());

                Console.Write("Nhap Ho (LastName): ");
                emp.LastName = Console.ReadLine();

                Console.Write("Nhap Ten (FirstName): ");
                emp.FirstName = Console.ReadLine();

                Console.Write("Nhap So nam lam viec: ");
                emp.YearsService = int.Parse(Console.ReadLine());

                Console.Write("Nhap Luong: ");
                emp.Salary = double.Parse(Console.ReadLine());

                byte[] data = emp.GetBytes();
                int size = emp.size;

                byte[] packsize = BitConverter.GetBytes(size);
                ns.Write(packsize, 0, 2);
                ns.Write(data, 0, size);
                ns.Flush();

                Console.Write("Ban co muon tiep tuc khong? (Khong/Co): ");
                string tiepTuc = Console.ReadLine();
                if (tiepTuc.Equals("Khong", StringComparison.OrdinalIgnoreCase))
                    break;
            }                    
            ns.Close();
            client.Close();
            Console.ReadKey();
        }
    }
}
