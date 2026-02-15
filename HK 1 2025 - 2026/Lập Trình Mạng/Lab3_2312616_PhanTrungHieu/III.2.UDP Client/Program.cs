using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace III._2.UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            while (true)
            {
                Console.Write("Bạn: ");
                string msg = Console.ReadLine();

                byte[] buff = Encoding.UTF8.GetBytes(msg);
                clientSocket.SendTo(buff, serverEndPoint);

                if (msg.ToLower() == "exit")
                {
                    Console.WriteLine("⚠ Client thoát...");
                    break;
                }
                else if (msg.ToLower() == "exit all")
                {
                    Console.WriteLine("⚠ Client yêu cầu tắt cả server...");
                    break;
                }
            }

            clientSocket.Close();
            Console.ReadKey();
        }
    }
}
