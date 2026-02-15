using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace III._5.UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            for (int i = 1; i <= 5; i++)
            {
                string msg = $"Thông điệp số {i}";
                byte[] buff = Encoding.UTF8.GetBytes(msg);

                clientSocket.SendTo(buff, serverEndPoint);
                Console.WriteLine("📤 Đã gửi: " + msg);
            }

            Console.WriteLine("✅ Đã gửi đủ 5 thông điệp. Client kết thúc!");
            clientSocket.Close();
            Console.ReadKey();
        }
    }
}
