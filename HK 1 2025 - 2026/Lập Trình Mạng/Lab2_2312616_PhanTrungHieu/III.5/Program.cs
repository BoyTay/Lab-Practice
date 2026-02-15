using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace III._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(serverEndPoint);
                Console.WriteLine("Đã kết nối tới server!");
            }
            catch (SocketException)
            {
                Console.WriteLine("Không thể kết nối tới server!");
                return;
            }

            while (true)
            {
                Console.Write("Bạn: ");
                string msg = Console.ReadLine();

                // Chuyển string thành byte và gửi lên server
                byte[] buff = Encoding.ASCII.GetBytes(msg);
                clientSocket.Send(buff, 0, buff.Length, SocketFlags.None);

                // Nhận phản hồi từ server
                buff = new byte[1024];
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);
                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);

                Console.WriteLine("Server: " + str);
            }
        }
    }
}
