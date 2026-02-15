using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bài_2.Client;

namespace Bài_3.UDP_Client
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

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

                // Gửi sang server
                client.Send(data, emp.size, serverEP);

                Console.Write("Ban co muon tiep tuc khong? (Khong/Co): ");
                string tiepTuc = Console.ReadLine();
                if (tiepTuc.Equals("Khong", StringComparison.OrdinalIgnoreCase))
                    break;
            }

            client.Close();
        }
        
    }
}
