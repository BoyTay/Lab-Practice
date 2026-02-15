using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace III._6.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            EndPoint tmpRemote = (EndPoint)serverEndPoint;

            // Số lượng thông điệp sẽ gửi
            int i = 1;
            while (i <= 5)
            {
                string input = $"Thông điệp số {i}";
                byte[] sendData = Encoding.UTF8.GetBytes(input);

                clientSocket.SendTo(sendData, tmpRemote);

                byte[] data = new byte[1024];
                try
                {
                    int recv = clientSocket.ReceiveFrom(data, ref tmpRemote);
                    string stringData = Encoding.UTF8.GetString(data, 0, recv);
                    Console.WriteLine("📩 Nhận từ server: " + stringData);
                }
                catch (SocketException)
                {
                    Console.WriteLine("⚠ Cảnh báo: dữ liệu bị mất, hãy thử lại!");
                }

                i++;
            }

            Console.WriteLine("✅ Hoàn tất gửi 5 thông điệp.");
            clientSocket.Close();
            Console.ReadKey();
        }
    }
}
