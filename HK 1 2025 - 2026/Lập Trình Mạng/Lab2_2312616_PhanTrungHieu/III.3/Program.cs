using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace III._3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- Client ---");
            // Tạo endpoint của server (localhost:5000)
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);

            // Tạo socket client
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Đang kết nối tới server...");

            try
            {
                // Kết nối tới server
                clientSocket.Connect(serverEndPoint);
                Console.WriteLine("Kết nối thành công với server!");

                // Nhận dữ liệu từ server
                byte[] buff = new byte[1024];
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);

                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine("Server gửi: " + str);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể kết nối tới server: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
    
}
