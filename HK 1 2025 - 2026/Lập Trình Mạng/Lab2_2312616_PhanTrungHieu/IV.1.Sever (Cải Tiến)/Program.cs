using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IV._1.Sever__Cải_Tiến_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);

            Console.WriteLine("Server đang chạy và chờ client...");

            while (true) // Cho phép Accept lại nếu client thoát
            {
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("🔗 Client đã kết nối: " + clientSocket.RemoteEndPoint);

                try
                {
                    while (true)
                    {
                        byte[] buff = new byte[1024];
                        int byteReceive = clientSocket.Receive(buff);

                        // Nếu client đóng kết nối đúng cách
                        if (byteReceive == 0)
                        {
                            Console.WriteLine("⚠ Client đã ngắt kết nối!");
                            break;
                        }

                        string msg = Encoding.ASCII.GetString(buff, 0, byteReceive);
                        Console.WriteLine("Client: " + msg);

                        // Gửi ngược lại client (echo)
                        clientSocket.Send(buff, 0, byteReceive, SocketFlags.None);
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("⚠ Client mất kết nối bất thường!");
                }
                finally
                {
                    clientSocket.Close(); // Đóng client hiện tại
                }
            }
        }
    }
}
