using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace III._1.UDP_Sever
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Tạo EndPoint cho server
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Gắn socket với địa chỉ server
            serverSocket.Bind(serverEndPoint);
            Console.WriteLine("✅ UDP Server đang chạy...");

            byte[] buff = new byte[1024];
            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);

            int byteReceive = serverSocket.ReceiveFrom(buff, ref remote);
            string msg = Encoding.UTF8.GetString(buff, 0, byteReceive);
            Console.WriteLine($"📩 Nhận từ {remote}: {msg}");
            Console.ReadKey();
        }
    }
}
