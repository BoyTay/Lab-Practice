using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsyncSocketTCP;


namespace BT3.AsyncSocketClientForm
{
    public partial class Form1 : Form
    {
        AsyncSocketTCPClient client;
        public Form1()
        {
            InitializeComponent();
            client = new AsyncSocketTCPClient();
            client.MessageReceived += Client_MessageReceived;
        }
        private void Client_MessageReceived(object sender, string message)
        {
            // Dùng Invoke để cập nhật UI an toàn từ thread khác
            if (txtServer.InvokeRequired)
            {
                txtServer.Invoke(new Action(() =>
                    txtServer.AppendText("Server: " + message + "\r\n")));
            }
            else
            {
                txtServer.AppendText("Server: " + message + "\r\n");
            }
        }


        private async void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            string port = txtPort.Text.Trim();

            if (!client.SetServerIPAddress(ip) || !client.SetPortNumber(port))
            {
                MessageBox.Show("Invalid IP address or port number!", "Error");
                return;
            }

            try
            {
                await client.ConnectToServer();
                txtServer.AppendText($"Connected to {ip}:{port}\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect: " + ex.Message, "Error");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtClient.Text.Trim();
            if (string.IsNullOrEmpty(message))
                return;

            await client.SendToServer(message);
            txtServer.AppendText("You: " + message + "\r\n");
            txtClient.Clear();
        }
    }
}
