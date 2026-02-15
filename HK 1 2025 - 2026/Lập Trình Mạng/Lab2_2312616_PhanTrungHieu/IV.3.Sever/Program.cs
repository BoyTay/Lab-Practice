using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IV._3.Sever
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 5000);
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);

            Console.WriteLine("✅ Server tính toán đang chạy...");

            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                Console.WriteLine("🔗 Client đã kết nối: " + clientSocket.RemoteEndPoint);

                try
                {
                    while (true)
                    {
                        byte[] buff = new byte[1024];
                        int byteReceive = clientSocket.Receive(buff);

                        if (byteReceive == 0) break;

                        string expr = Encoding.UTF8.GetString(buff, 0, byteReceive);
                        Console.WriteLine("Client yêu cầu: " + expr);

                        if (expr.ToLower() == "exit")
                        {
                            Console.WriteLine("⚠ Client đã thoát");
                            break;
                        }

                        string result = Calculate(expr);
                        byte[] sendBuff = Encoding.UTF8.GetBytes(result);
                        clientSocket.Send(sendBuff);
                    }
                }
                catch
                {
                    Console.WriteLine("⚠ Client mất kết nối bất thường!");
                }
                finally
                {
                    clientSocket.Close();
                }
            }
        }

        // Hàm xử lý phép toán đơn giản (chỉ hỗ trợ + - * /)
        static string Calculate(string expr)
        {
            try
            {
                char[] ops = { '+', '-', '*', '/' };
                foreach (char op in ops)
                {
                    string[] parts = expr.Split(op);
                    if (parts.Length == 2)
                    {
                        double a = double.Parse(parts[0].Trim());
                        double b = double.Parse(parts[1].Trim());
                        double res = 0;

                        switch (op)
                        {
                            case '+': res = a + b; break;
                            case '-': res = a - b; break;
                            case '*': res = a * b; break;
                            case '/': res = b != 0 ? a / b : double.NaN; break;
                        }

                        return $"Kết quả: {res}";
                    }
                }
                return "❌ Biểu thức không hợp lệ!";
            }
            catch
            {
                return "❌ Lỗi khi tính toán!";
            }
        }
    }
}
