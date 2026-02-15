using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;

namespace AsyncSocketTCP
{
    
    public class AsyncSocketTCPServer
    {
        IPAddress mIP;
        int mPort;
        TcpListener mTCPListener;
        public List<TcpClient> mClients;
        //Lấy trạng thái chương trình có thực thi hay không?
        public bool KeepRunning;  // Để kiểm soát vòng lặp lắng nghe
        public EventHandler<ClientConnectedEventArgs> ClientConnectedEvent;
        public EventHandler<ClientDisconnectedEventArgs> ClientDisconnectedEvent;
        public event EventHandler<MessageReceivedEventArgs> MessageReceivedEvent;

        protected virtual void OnClientConnectedEvent(ClientConnectedEventArgs e)
        {
            EventHandler<ClientConnectedEventArgs> handler = ClientConnectedEvent;
            if(handler!=null)
            {
                handler(this, e);
            }    
        }
        protected virtual void OnClientDisconnected(ClientDisconnectedEventArgs e)
        {
            EventHandler<ClientDisconnectedEventArgs> handler = ClientDisconnectedEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        {
            EventHandler<MessageReceivedEventArgs> handler = MessageReceivedEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        //Phương thức khởi tạo
        public AsyncSocketTCPServer()
        {
            mClients = new List<TcpClient>();
        }
        //Phương thức lắng nghe, nhận kết nối từ Client, thêm vào danh sách
        public async void StartListeningForIncomingConnection(IPAddress ipaddr = null, int port = 9001)
        {
            if (ipaddr == null)
            {
                ipaddr = IPAddress.Any;
            }
            if (port <= 0)
            {
                port = 9001;
            }

            mIP = ipaddr;
            mPort = port;

            System.Diagnostics.Debug.WriteLine(string.Format("IP Address: {0} - Port: {1}", mIP.ToString(), mPort));

            mTCPListener = new TcpListener(mIP, mPort);

            try
            {
                mTCPListener.Start();

                KeepRunning = true;

                while (KeepRunning)
                {
                    var returnedByAccept = await mTCPListener.AcceptTcpClientAsync();

                    mClients.Add(returnedByAccept);
                    OnClientConnectedEvent(new ClientConnectedEventArgs(returnedByAccept.Client.RemoteEndPoint.ToString()));

                    Debug.WriteLine(string.Format("Client connected successfully, count: {0} - {1}", mClients.Count, returnedByAccept.Client.RemoteEndPoint));

                    TakeCareOfTCPClient(returnedByAccept);
                }
            }
            catch (Exception excp)
            {
                System.Diagnostics.Debug.WriteLine(excp.ToString());
            }          
        }
        //Phương thức quản lý các client, nhận tin nhắn từ client
        private async void TakeCareOfTCPClient(TcpClient paramClient)
        {
            NetworkStream stream = null;
            StreamReader reader = null;

            try
            {
                stream = paramClient.GetStream();
                reader = new StreamReader(stream);

                char[] buff = new char[64];

                while (KeepRunning)
                {
                    Debug.WriteLine("*** Ready to read");

                    int nRet = await reader.ReadAsync(buff, 0, buff.Length);

                    System.Diagnostics.Debug.WriteLine("Returned: " + nRet);

                    if (nRet == 0)
                    {
                        RemoveClient(paramClient);
                        System.Diagnostics.Debug.WriteLine("Socket disconnected");
                        //OnClientDisconnected(new ClientDisconnectedEventArgs(paramClient.Client.RemoteEndPoint.ToString()));
                        break;
                    }

                    string receivedText = new string(buff, 0, nRet);                   
                    System.Diagnostics.Debug.WriteLine("*** RECEIVED: " + receivedText);
                    OnMessageReceived(new MessageReceivedEventArgs(receivedText, paramClient.Client.RemoteEndPoint.ToString()));
                    // Gọi sự kiện hoặc xử lý tin nhắn nhận được ở đây (sẽ bổ sung ở form)

                    Array.Clear(buff, 0, buff.Length);
                }
            }
            catch (Exception excp)
            {
                RemoveClient(paramClient);
                System.Diagnostics.Debug.WriteLine(excp.ToString());
            }
        }
        //Phương thức xóa client
        private void RemoveClient(TcpClient paramClient)
        {
            if (mClients.Contains(paramClient))
            {
                mClients.Remove(paramClient);
                OnClientDisconnected(new ClientDisconnectedEventArgs(paramClient.Client.RemoteEndPoint.ToString()));
                Debug.WriteLine(string.Format("Client removed, count: {0}", mClients.Count));
            }
        }
        //Phương thức gửi tin nhắn đến tất cả các client
        public async void SendToAll(string leMessage)
        {
            if (string.IsNullOrEmpty(leMessage))
            {
                return;
            }

            try
            {                
                byte[] buffMessage = Encoding.ASCII.GetBytes(leMessage);

                foreach (TcpClient c in mClients)
                {
                    await c.GetStream().WriteAsync(buffMessage, 0, buffMessage.Length);
                }
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }
        }
        //Phương thức ngắt kết nối tất cả client và dừng server
        public void StopServer()
        {
            try
            {
                if (mTCPListener != null)
                {
                    mTCPListener.Stop();
                }

                foreach (TcpClient c in mClients)
                {
                    c.Close();
                }

                mClients.Clear();
            }
            catch (Exception excp)
            {
                Debug.WriteLine(excp.ToString());
            }
        }
    }
    
}
