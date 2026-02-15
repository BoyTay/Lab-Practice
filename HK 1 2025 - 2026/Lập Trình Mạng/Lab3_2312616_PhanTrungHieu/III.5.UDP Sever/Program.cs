using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace III._5.UDP_Sever
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Bind(serverEndPoint);
            Console.WriteLine("✅ UDP Server đang chạy, chờ nhận 5 thông điệp...");

            EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
            byte[] buff;

            for (int i = 1; i <= 5; i++)
            {
                buff = new byte[1024];
                int byteReceive = serverSocket.ReceiveFrom(buff, ref remote);
                string msg = Encoding.UTF8.GetString(buff, 0, byteReceive);

                Console.WriteLine($"📩 Thông điệp {i} từ {remote}: {msg}");
            }

            Console.WriteLine("✅ Đã nhận đủ 5 thông điệp. Server kết thúc!");
            serverSocket.Close();
            Console.ReadKey();
        }
    }
}
