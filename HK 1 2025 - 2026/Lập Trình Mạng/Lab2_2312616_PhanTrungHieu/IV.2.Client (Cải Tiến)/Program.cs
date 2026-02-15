using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IV._2.Client__Cải_Tiến_
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
                Console.WriteLine("✅ Đã kết nối tới server!");
            }
            catch
            {
                Console.WriteLine("❌ Không thể kết nối tới server!");
                return;
            }

            while (true)
            {
                Console.Write("Bạn: ");
                string msg = Console.ReadLine();

                byte[] buff = Encoding.ASCII.GetBytes(msg);
                clientSocket.Send(buff);

                if (msg.ToLower() == "exit")
                {
                    Console.WriteLine("⚠ Đang thoát...");
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }

                buff = new byte[1024];
                int received = clientSocket.Receive(buff);
                Console.WriteLine("Server: " + Encoding.ASCII.GetString(buff, 0, received));
            }
        }
    }
}
