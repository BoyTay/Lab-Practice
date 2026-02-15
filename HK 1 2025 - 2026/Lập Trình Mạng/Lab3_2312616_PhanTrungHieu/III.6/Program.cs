using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace III._6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Bind(serverEndPoint);
            Console.WriteLine("✅ UDP Server đang chạy...");

            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            while (true)
            {
                byte[] buff = new byte[1024];
                int recv = serverSocket.ReceiveFrom(buff, ref remote);

                string msg = Encoding.UTF8.GetString(buff, 0, recv);
                Console.WriteLine($"📩 Nhận từ {remote}: {msg}");

                if (msg.ToLower() == "exit all")
                {
                    Console.WriteLine("⚠ Server tắt!");
                    break;
                }

                // Gửi echo lại cho client
                serverSocket.SendTo(Encoding.UTF8.GetBytes("Server nhận: " + msg), remote);
            }

            serverSocket.Close();
            Console.ReadKey();
        }
    }
}
