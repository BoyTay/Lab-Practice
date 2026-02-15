using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsyncSocketTCP;  // Namespace của library

namespace AsyncSocketServer
{
    public partial class Form1 : Form
    {
        AsyncSocketTCPServer mServer;
        public Form1()
        {
            InitializeComponent();
            mServer = new AsyncSocketTCPServer();
            mServer.ClientConnectedEvent += HandleClientConnected;
            mServer.ClientDisconnectedEvent += HandleClientDisconnected;
            mServer.MessageReceivedEvent += HandleMessageReceived;
        }

        private void btnAcceptIncoming_Click(object sender, EventArgs e)
        {
            mServer.StartListeningForIncomingConnection();
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            mServer.SendToAll(txtBroadcast.Text.Trim());

        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            mServer.StopServer();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mServer.StopServer();
        }

        void HandleClientConnected(object sender, ClientConnectedEventArgs e)
        {
            // Dùng Invoke để cập nhật UI an toàn từ thread khác
            if (txtClientInfo.InvokeRequired)
            {
                txtClientInfo.Invoke(new Action(() =>
                    txtClientInfo.AppendText(string.Format("{0} - New client connected - {1}\r\n", DateTime.Now, e.NewClient))));
            }
            else
            {
                txtClientInfo.AppendText(string.Format("{0} - New client connected - {1}\r\n", DateTime.Now, e.NewClient));
            }
        }
        void HandleClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            // Dùng Invoke để cập nhật UI an toàn từ thread khác
            if (txtClientInfo.InvokeRequired)
            {
                txtClientInfo.Invoke(new Action(() =>
                    txtClientInfo.AppendText(string.Format("{0} - Client disconnected - {1}. Remaining clients: {2}\r\n", DateTime.Now, e.RemovedClient, mServer.mClients.Count))));
            }
            else
            {
                txtClientInfo.AppendText(string.Format("{0} - Client disconnected - {1}. Remaining clients: {2}\r\n", DateTime.Now, e.RemovedClient, mServer.mClients.Count));  // Bổ sung số client còn lại
            }
        }
        void HandleMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            // Xóa ký tự trắng hoặc xuống dòng dư thừa ở cuối tin nhắn
            string cleanMessage = e.Message.Trim();

            // Dùng Invoke để cập nhật UI an toàn từ thread khác
            if (txtMessage.InvokeRequired)
            {
                txtMessage.Invoke(new Action(() =>
                    txtMessage.AppendText(string.Format("{0} - From {1}: {2}\r\n", DateTime.Now.ToString("HH:mm:ss"), e.FromClient, cleanMessage))));
            }
            else
            {
                // Hiển thị rõ ràng, mỗi tin nhắn một dòng
                txtMessage.AppendText(string.Format("{0} - From {1}: {2}\r\n", DateTime.Now.ToString("HH:mm:ss"), e.FromClient, cleanMessage));
            }
        }
    }
}
