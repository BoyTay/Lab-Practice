using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace III._3.UDP_Client__Cải_Tiến_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            EndPoint remote = serverEndPoint;

            while (true)
            {
                Console.Write("Bạn: ");
                string msg = Console.ReadLine();

                byte[] buff = Encoding.UTF8.GetBytes(msg);
                clientSocket.SendTo(buff, serverEndPoint);

                if (msg.ToLower() == "exit" || msg.ToLower() == "exit all")
                {
                    Console.WriteLine("⚠ Client thoát...");
                    break;
                }

                // Nhận phản hồi từ server
                buff = new byte[1024];
                int byteReceive = clientSocket.ReceiveFrom(buff, ref remote);
                string reply = Encoding.UTF8.GetString(buff, 0, byteReceive);
                Console.WriteLine("👉 Server: " + reply);
            }

            clientSocket.Close();
        }
    }
}
