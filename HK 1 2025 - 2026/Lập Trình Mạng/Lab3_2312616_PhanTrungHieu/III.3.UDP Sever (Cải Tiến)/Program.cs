using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace III._3.UDP_Sever__Cải_Tiến_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
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

                // Gửi phản hồi ngược lại client
                string reply = "Server nhận: " + msg;
                byte[] sendBuff = Encoding.UTF8.GetBytes(reply);
                serverSocket.SendTo(sendBuff, remote);
            }

            serverSocket.Close();
        }
    }
}
