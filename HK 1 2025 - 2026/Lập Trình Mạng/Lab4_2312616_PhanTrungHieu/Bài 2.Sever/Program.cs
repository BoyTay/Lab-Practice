using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bài_2.Client;
using System.IO;

namespace Bài_2.Sever
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            TcpListener server = new TcpListener(IPAddress.Any, 9050);
            server.Start();

            TcpClient client = server.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            // Mở file ghi thông tin nhân viên
            using (StreamWriter writer = new StreamWriter("NhanVien.txt", true)) // true = ghi nối tiếp
            {
                while (true)
                {
                    byte[] size = new byte[2];
                    int recv = ns.Read(size, 0, 2);
                    if (recv == 0) break; // client đóng kết nối
                    int packsize = BitConverter.ToInt16(size, 0);

                    Console.WriteLine("Kich thuoc goi tin = {0}", packsize);

                    recv = ns.Read(data, 0, packsize);

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
                    writer.Flush(); // đảm bảo dữ liệu được ghi ngay
                }
            }    

            ns.Close();
            client.Close();
            server.Stop();
            Console.ReadKey();
        }
    }
}
