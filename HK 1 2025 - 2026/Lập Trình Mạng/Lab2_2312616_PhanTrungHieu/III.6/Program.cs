using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace III._6
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

            Console.WriteLine("Server đang chờ kết nối...");

            Socket clientSocket = serverSocket.Accept();
            Console.WriteLine("Client đã kết nối: " + clientSocket.RemoteEndPoint);

            while (true)
            {
                byte[] buff = new byte[1024];
                int byteReceive = clientSocket.Receive(buff, 0, buff.Length, SocketFlags.None);

                string str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine("Client: " + str);

                // Gửi trả lại client (echo)
                clientSocket.Send(buff, 0, byteReceive, SocketFlags.None);
            }
            Console.ReadKey();
        }
    }
}
