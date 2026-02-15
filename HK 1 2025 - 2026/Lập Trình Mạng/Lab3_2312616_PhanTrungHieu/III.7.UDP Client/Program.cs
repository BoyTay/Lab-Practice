using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace III._7.UDP_Client
{
    internal class Program
    {
        static byte[] data;

        // Hàm gửi – nhận có retry 
        private static int SndRcvData(Socket s, byte[] message, EndPoint remote)
        {
            int recv;
            int retry = 0;

            while (true)
            {
                Console.WriteLine("📤 Truyền lần thứ: #{0}", retry + 1);
                try
                {
                    s.SendTo(message, message.Length, SocketFlags.None, remote);

                    data = new byte[1024];
                    recv = s.ReceiveFrom(data, ref remote); // chờ nhận phản hồi
                }
                catch (SocketException)
                {
                    recv = 0;
                }

                if (recv > 0)
                {
                    return recv; // nhận thành công
                }
                else
                {
                    retry++;
                    if (retry > 4)
                    {
                        // quá số lần retry
                        return 0;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string input, stringData;
            int recv;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // Lấy và hiển thị timeout mặc định
            int sockopt = (int)server.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            Console.WriteLine("⏱ Giá trị timeout mặc định: {0} ms", sockopt);

            // Đặt timeout mới (3 giây)
            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
            sockopt = (int)server.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout);
            Console.WriteLine("⏱ Giá trị timeout mới: {0} ms", sockopt);

            // Gửi câu chào ban đầu
            string welcome = "Xin chào Server";
            data = Encoding.UTF8.GetBytes(welcome);
            recv = SndRcvData(server, data, ipep);

            if (recv > 0)
            {
                stringData = Encoding.UTF8.GetString(data, 0, recv);
                Console.WriteLine("📩 Phản hồi: " + stringData);
            }
            else
            {
                Console.WriteLine("⚠ Không thể liên lạc với server!");
                return;
            }

            // Gửi dữ liệu liên tục
            while (true)
            {
                Console.Write("Bạn: ");
                input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                recv = SndRcvData(server, Encoding.UTF8.GetBytes(input), ipep);

                if (recv > 0)
                {
                    stringData = Encoding.UTF8.GetString(data, 0, recv);
                    Console.WriteLine("👉 Server: " + stringData);
                }
                else
                {
                    Console.WriteLine("⚠ Không nhận được câu trả lời sau khi retry!");
                }
            }

            Console.WriteLine("🚪 Đang đóng client...");
            server.Close();
        }
    }    
}
