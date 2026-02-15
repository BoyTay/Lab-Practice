using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace III._4.UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // Kết nối ảo tới server
            clientSocket.Connect(serverEndPoint);

            while (true)
            {
                Console.Write("Bạn: ");
                string msg = Console.ReadLine();

                byte[] buff = Encoding.UTF8.GetBytes(msg);
                clientSocket.Send(buff); // không cần SendTo nữa

                if (msg.ToLower() == "exit" || msg.ToLower() == "exit all")
                {
                    Console.WriteLine("⚠ Client thoát...");
                    break;
                }

                // Nhận phản hồi từ server
                buff = new byte[1024];
                int byteReceive = clientSocket.Receive(buff); // không cần ReceiveFrom
                string reply = Encoding.UTF8.GetString(buff, 0, byteReceive);
                Console.WriteLine("👉 Server: " + reply);
            }
        }
    }
}
