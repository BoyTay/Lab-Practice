using System;
using System.Threading.Tasks;
using AsyncSocketTCP;

namespace AsyncSocketClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AsyncSocketTCPClient client = new AsyncSocketTCPClient();

            Console.WriteLine("*** Welcome to Async Socket Client ***");
            Console.Write("Enter Server IP Address (default: 127.0.0.1): ");
            string strIPAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(strIPAddress))
                strIPAddress = "127.0.0.1";  // IP mặc định

            Console.Write("Enter Port Number (default: 9001): ");
            string strPortInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(strPortInput))
                strPortInput = "9001";  // Port mặc định

            // Kiểm tra IP và Port hợp lệ
            if (!client.SetServerIPAddress(strIPAddress) || !client.SetPortNumber(strPortInput))
            {
                Console.WriteLine($"❌ Invalid IP Address or Port Number ({strIPAddress}:{strPortInput}). Press any key to exit.");
                Console.ReadKey();
                return;
            }

            try
            {
                // Kết nối tới Server
                await client.ConnectToServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Cannot connect to server: " + ex.Message);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            string strInputUser = null;

            try
            {
                do
                {
                    //Console.Write("Enter message: ");
                    strInputUser = Console.ReadLine();
                    if (strInputUser.Trim() != "<EXIT>")
                    {
                         client.SendToServer(strInputUser);
                    }
                    else if (strInputUser.Equals("<EXIT>", StringComparison.OrdinalIgnoreCase))
                    {
                        client.CloseAndDisconnect();
                    }

                } while (strInputUser != "<EXIT>");
            }
            catch (Exception ex)
            {
                Console.WriteLine("⚠️ Error during communication: " + ex.Message);
                client.CloseAndDisconnect();
            }
        }
    }
}
