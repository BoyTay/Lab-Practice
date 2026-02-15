using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IV._3.Client__Cải_Tiến_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(serverEndPoint);
                Console.WriteLine("✅ Đã kết nối tới server tính toán!");
            }
            catch
            {
                Console.WriteLine("❌ Không thể kết nối tới server!");
                return;
            }

            while (true)
            {
                Console.Write("Nhập biểu thức (vd: 3+5, 10-2, 6*7, 8/2), hoặc gõ exit để thoát: ");
                string expr = Console.ReadLine();

                byte[] buff = Encoding.UTF8.GetBytes(expr);
                clientSocket.Send(buff);

                if (expr.ToLower() == "exit")
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }

                buff = new byte[1024];
                int received = clientSocket.Receive(buff);
                Console.WriteLine("👉 " + Encoding.UTF8.GetString(buff, 0, received));
            }
        }
    }
}
