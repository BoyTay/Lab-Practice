using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace III._2.UDP_Sever
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Bind(serverEndPoint);
            Console.WriteLine("✅ UDP Server đang chạy...");

            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            byte[] buff;

            while (true)
            {
                buff = new byte[1024];
                int byteReceive = serverSocket.ReceiveFrom(buff, ref remote);
                string msg = Encoding.UTF8.GetString(buff, 0, byteReceive);

                Console.WriteLine($"📩 Nhận từ {remote}: {msg}");

                if (msg.ToLower() == "exit all")
                {
                    Console.WriteLine("⚠ Server sẽ tắt theo yêu cầu từ client!");
                    break;
                }
            }

            serverSocket.Close();
            Console.ReadKey();
        }
    }
}
