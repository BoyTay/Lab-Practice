using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Share;

namespace UDPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(9050);
            IPEndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("UDP Server dang cho nhan du lieu...");

            using (StreamWriter writer = new StreamWriter("NhanVien_UDP.txt", true))
            {
                while (true)
                {
                    byte[] data = server.Receive(ref clientEP);
                    Employee emp = new Employee(data);

                    Console.WriteLine("\nNhan duoc thong tin nhan vien:");
                    Console.WriteLine("ID = {0}", emp.EmployeeID);
                    Console.WriteLine("Ho = {0}", emp.LastName);
                    Console.WriteLine("Ten = {0}", emp.FirstName);
                    Console.WriteLine("So nam lam viec = {0}", emp.YearsService);
                    Console.WriteLine("Luong = {0}\n", emp.Salary);

                    // Ghi ra file
                    writer.WriteLine("ID = {0}", emp.EmployeeID);
                    writer.WriteLine("Ho = {0}", emp.LastName);
                    writer.WriteLine("Ten = {0}", emp.FirstName);
                    writer.WriteLine("So nam lam viec = {0}", emp.YearsService);
                    writer.WriteLine("Luong = {0}", emp.Salary);
                    writer.WriteLine("-------------------------");
                    writer.Flush();
                }
            }
        }
    }
}
