using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace III._1.UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string hello = "Xin chào Server!";
            byte[] buff = Encoding.UTF8.GetBytes(hello);

            clientSocket.SendTo(buff, serverEndPoint);
            Console.WriteLine("📤 Đã gửi: " + hello);
            Console.ReadKey();
        }
    }
}
