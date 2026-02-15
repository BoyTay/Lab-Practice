using AsyncSocketTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncSocketServer
{
    public partial class frmServer : Form
    {
        AsyncSocketTCPServer mServer;
        private System.Windows.Forms.Timer refreshTimer;

        public frmServer()
        {
            InitializeComponent();

            var connectionString = ConfigurationManager.ConnectionStrings["AccountClient"]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageBox.Show("Không tìm thấy connection string 'AccountClient' trong App.config", "Cấu hình thiếu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new InvalidOperationException("Missing 'AccountClient' connection string.");
            }

            mServer = new AsyncSocketTCPServer(connectionString);
            mServer.ClientConnectedEvent += HandleClientConnected;
            mServer.ClientDisconnectedEvent += HandleClientDisconnected;
            mServer.MessageReceivedEvent += HandleMessageReceived;

            // Timer để cập nhật danh sách client mỗi giây
            refreshTimer = new System.Windows.Forms.Timer();
            refreshTimer.Interval = 1000;
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();

            UpdateClientList();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateClientList();
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshTimer?.Stop();
            mServer.StopServer();
        }

        // Helper cập nhật UI thread-safe
        private void AppendSafe(TextBoxBase tb, string text, Color? color = null)
        {
            if (tb.InvokeRequired)
            {
                tb.BeginInvoke(new Action(() =>
                {
                    if (tb is RichTextBox rtb && color.HasValue)
                    {
                        rtb.SelectionStart = rtb.TextLength;
                        rtb.SelectionLength = 0;
                        rtb.SelectionColor = color.Value;
                        rtb.AppendText(text);
                        rtb.SelectionColor = rtb.ForeColor;
                        rtb.ScrollToCaret();
                    }
                    else
                    {
                        tb.AppendText(text);
                    }
                }));
            }
            else
            {
                if (tb is RichTextBox rtb && color.HasValue)
                {
                    rtb.SelectionStart = rtb.TextLength;
                    rtb.SelectionLength = 0;
                    rtb.SelectionColor = color.Value;
                    rtb.AppendText(text);
                    rtb.SelectionColor = rtb.ForeColor;
                    rtb.ScrollToCaret();
                }
                else
                {
                    tb.AppendText(text);
                }
            }
        }

        void HandleClientConnected(object sender, ClientConnectedEventArgs e)
        {
            AppendSafe(rtbLog, $"[{DateTime.Now:HH:mm:ss}] ✅ Client mới kết nối: {e.NewClient}\r\n", Color.Green);
            UpdateClientList();
        }

        void HandleClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            AppendSafe(rtbLog, $"[{DateTime.Now:HH:mm:ss}] ❌ Client ngắt kết nối: {e.RemovedClient}\r\n", Color.Red);
            UpdateClientList();
        }

        void HandleMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string cleanMessage = e.Message.Trim();
            if (cleanMessage.StartsWith("SERVER_MSG:", StringComparison.OrdinalIgnoreCase))
            {
                string text = cleanMessage.Substring("SERVER_MSG:".Length).Trim();
                string senderName = ResolveClientDisplay(e.FromClient);
                AppendSafe(rtbLog, $"[{DateTime.Now:HH:mm:ss}] 📥 Tin riêng từ {senderName}: {text}\r\n", Color.MediumVioletRed);
                return;
            }

            AppendSafe(rtbLog, $"[{DateTime.Now:HH:mm:ss}] 📨 Từ {e.FromClient}: {cleanMessage}\r\n", Color.Blue);
        }

        private string ResolveClientDisplay(string endPoint)
        {
            if (string.IsNullOrEmpty(endPoint)) return "Không rõ";

            lock (mServer.ConnectedClients)
            {
                var client = mServer.ConnectedClients.FirstOrDefault(c => string.Equals(c.EndPoint, endPoint, StringComparison.OrdinalIgnoreCase));
                if (client != null)
                {
                    return client.IsLoggedIn ? $"{client.Username} ({endPoint})" : endPoint;
                }
            }

            return endPoint;
        }

        private void UpdateClientList()
        {
            if (lstClients.InvokeRequired)
            {
                lstClients.Invoke(new Action(() => UpdateClientList()));
                return;
            }

            lstClients.Items.Clear();
            int onlineCount = 0;

            lock (mServer.ConnectedClients)
            {
                foreach (var client in mServer.ConnectedClients)
                {
                    string status = client.IsLoggedIn ? "✅ Đã đăng nhập" : "⏳ Chưa đăng nhập";
                    string display = $"{client.Username} | {status} | {client.EndPoint}";
                    lstClients.Items.Add(display);
                    if (client.IsLoggedIn) onlineCount++;
                }
            }

            int totalAccounts = GetTotalAccountCountSafe();
            lblClientCount.Text = $"Tổng số tài khoản: {totalAccounts} | Đã đăng nhập: {onlineCount}";
        }

        private int GetTotalAccountCountSafe()
        {
            try
            {
                return mServer.GetTotalAccountCountAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Không thể lấy tổng số tài khoản: {ex.Message}");
                return 0;
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                mServer.StartListeningForIncomingConnection();
                AppendSafe(rtbLog, $"[{DateTime.Now:HH:mm:ss}] 🚀 Server đã khởi động và đang lắng nghe kết nối...\r\n", Color.Green);
                btnStartServer.Enabled = false;
                btnStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            try
            {
                mServer.StopServer();
                AppendSafe(rtbLog, $"[{DateTime.Now:HH:mm:ss}] 🛑 Server đã dừng\r\n", Color.Red);
                btnStartServer.Enabled = true;
                btnStopServer.Enabled = false;
                UpdateClientList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi dừng server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string selectedClientUsername = "";

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClients.SelectedItem == null)
            {
                selectedClientUsername = "";
                lblSelectedClient.Text = "Chưa chọn client";
                lblSelectedClient.ForeColor = Color.DarkGray;
                return;
            }

            string selected = lstClients.SelectedItem.ToString();
            // Parse username từ format: "Username | Status | EndPoint"
            var parts = selected.Split(new[] { " | " }, StringSplitOptions.None);
            if (parts.Length > 0)
            {
                selectedClientUsername = parts[0].Trim();
                lblSelectedClient.Text = $"Đã chọn: {selectedClientUsername}";
                lblSelectedClient.ForeColor = Color.DarkGreen;
            }
        }

        private async void btnSendToClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedClientUsername))
            {
                MessageBox.Show("Vui lòng chọn client từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = txtClientMessage.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bool success = await mServer.SendToClient(selectedClientUsername, message);
                if (success)
                {
                    AppendSafe(rtbLog, $"[{DateTime.Now:HH:mm:ss}] 💬 Đã gửi tới {selectedClientUsername}: {message}\r\n", Color.DarkGreen);
                    txtClientMessage.Clear();
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy client '{selectedClientUsername}' hoặc client đã ngắt kết nối!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UpdateClientList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            string message = txtBroadcast.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                mServer.SendToAll(message);
                AppendSafe(rtbLog, $"[{DateTime.Now:HH:mm:ss}] 📢 Đã gửi broadcast: {message}\r\n", Color.DarkBlue);
                txtBroadcast.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private bool isDragging = false;
        private Point dragStartPoint = Point.Empty;

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = new Point(e.X, e.Y);
            }
        }

        private void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newPoint = this.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(-dragStartPoint.X, -dragStartPoint.Y);
                this.Location = newPoint;
            }
        }

        private void panelTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
