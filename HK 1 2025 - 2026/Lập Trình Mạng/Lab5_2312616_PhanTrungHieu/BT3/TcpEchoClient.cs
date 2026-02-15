using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    internal class TcpEchoClient
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                throw new ArgumentException("Parameter(s): <Server> <Port> <Word>");
            }

            string server = args[0];             // Địa chỉ server (vd: 127.0.0.1)
            int servPort = Int32.Parse(args[1]); // Cổng server (vd: 9001)
            string message = args[2];            // Nội dung gửi lên server

            // Chuyển nội dung sang mảng byte
            byte[] byteBuffer = Encoding.ASCII.GetBytes(message);

            // Tạo socket TCP
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Kết nối đến server
                client.Connect(new IPEndPoint(IPAddress.Parse(server), servPort));
                Console.WriteLine("Connected to server {0}:{1}", server, servPort);

                // Gửi dữ liệu
                client.Send(byteBuffer);
                Console.WriteLine("Sent {0} bytes to server.", byteBuffer.Length);

                // Nhận phản hồi (echo)
                int totalBytesRcvd = 0;  // Tổng số byte đã nhận
                int bytesRcvd;           // Số byte nhận trong mỗi lần
                byte[] recvBuffer = new byte[byteBuffer.Length];

                while (totalBytesRcvd < byteBuffer.Length)
                {
                    bytesRcvd = client.Receive(recvBuffer, totalBytesRcvd,
                                                byteBuffer.Length - totalBytesRcvd, SocketFlags.None);

                    if (bytesRcvd == 0)
                        break; // Server đóng kết nối

                    totalBytesRcvd += bytesRcvd;
                }

                // Hiển thị kết quả
                Console.WriteLine("Received {0} bytes from server: {1}",
                    totalBytesRcvd, Encoding.ASCII.GetString(recvBuffer, 0, totalBytesRcvd));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                client.Close();
            }
            Console.ReadKey();
        }
    }
}
