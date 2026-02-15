using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace AsyncSocketTCP
{
    public class AsyncSocketTCPClient
    {
        IPAddress mServerIPAddress;
        int mServerPort;
        TcpClient mClient;
        public IPAddress ServerIPAddress
        {
            get
            {
                return mServerIPAddress;
            }
        }
        public int SeverPort
        {
            get
            {
                return mServerPort;
            }
        }
        public AsyncSocketTCPClient()
        {
            mClient = null;
            mServerPort = -1;
            mServerIPAddress = null;
        }
        public bool SetServerIPAddress(string _IPAddressServer)
        {
            IPAddress ipaddr = null;
            if (!IPAddress.TryParse(_IPAddressServer, out ipaddr))
            {
                Console.WriteLine("Invalid IP Address.");
                return false;
            }

            mServerIPAddress = ipaddr;
            return true;
        }

        public bool SetPortNumber(string _ServerPort)
        {
            int portNumber = 0;

            if (!int.TryParse(_ServerPort.Trim(), out portNumber))
            {
                Console.WriteLine("Invalid port number.");
                return false;
            }

            if (portNumber <= 0 || portNumber > 65535)
            {
                Console.WriteLine("Port number must be between 0 and 65535.");
                return false;
            }

            mServerPort = portNumber;
            return true;
        }
        public void CloseAndDisconnect()
        {
            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    mClient.Close();
                }
            }
        }

        public async Task ConnectToServer()
        {
            if (mClient == null)
            {
                mClient = new TcpClient();
            }

            try
            {
                await mClient.ConnectAsync(mServerIPAddress, mServerPort);

                Console.WriteLine(string.Format("Connected to server IP/Port: {0} / {1}", mServerIPAddress, mServerPort));

                ReadDataAsync(mClient);
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
                throw;
            }
        }
        public async Task SendToServer(string strInputUser)
        {
            if (string.IsNullOrEmpty(strInputUser))
            {
                Console.WriteLine("Empty message, no data sent.");
                return;
            }

            if (mClient != null)
            {
                if (mClient.Connected)
                {
                    StreamWriter clientStreamWriter = new StreamWriter(mClient.GetStream());
                    clientStreamWriter.AutoFlush = true;

                    await clientStreamWriter.WriteLineAsync(strInputUser);
                    Console.WriteLine("Data sent...");
                }
            }
        }
        public event EventHandler<string> MessageReceived;

        private async Task ReadDataAsync(TcpClient mClient)
        {
            try
            {
                using (var clientStreamReader = new StreamReader(mClient.GetStream(), Encoding.UTF8, false, 1024, leaveOpen: true))
                {
                    while (true)
                    {
                        string line = await clientStreamReader.ReadLineAsync().ConfigureAwait(false);
                        if (line == null)
                        {
                            Console.WriteLine("Disconnected from server.");
                            mClient.Close();
                            break;
                        }

                        string message = line.Trim();
                        if (message.Length == 0) continue;

                        MessageReceived?.Invoke(this, message);
                        Console.WriteLine("Received line: " + message);
                    }
                }
            }
            catch (Exception excp)
            {
                Console.WriteLine(excp.ToString());
                throw;
            }
        }
    }
}
