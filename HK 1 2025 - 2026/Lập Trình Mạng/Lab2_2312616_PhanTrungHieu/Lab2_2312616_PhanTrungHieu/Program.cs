using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Lab2_2312616_PhanTrungHieu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Tạo Endpoint cho server (IP bất kỳ, port 5000)
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);

            // Tạo socket
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Gán endpoint và bắt đầu lắng nghe
            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);

            Console.WriteLine("Server đang chạy và chờ kết nối...");

            // Chấp nhận kết nối từ client
            Socket clientSocket = serverSocket.Accept();
            EndPoint clientEndPoint = clientSocket.RemoteEndPoint;
            Console.WriteLine("Client đã kết nối từ: " + clientEndPoint.ToString());

            // Gửi câu chào        
            string hello = "Hello Client";
            byte[] buff = Encoding.ASCII.GetBytes(hello);
            clientSocket.Send(buff);

            Console.WriteLine("Đã gửi lời chào đến client.");

            Console.ReadLine();
        }
    }
}
