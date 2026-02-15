using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsyncSocketTCP;

namespace AsyncSocketClient
{
    public partial class frmClient : Form
    {
        readonly AsyncSocketTCPClient client;
        private readonly string username;
        private readonly string password;
        private readonly string serverIp;
        private readonly string serverPort;
        private string currentUsername = "";
        private List<string> onlineUsers = new List<string>();
        private List<string> joinedGroups = new List<string>();

        public frmClient(string username, string password)
        {
            InitializeComponent();
            this.username = username ?? throw new ArgumentNullException(nameof(username));
            this.password = password ?? throw new ArgumentNullException(nameof(password));
            client = new AsyncSocketTCPClient();
            client.MessageReceived += Client_MessageReceived;
            serverIp = ConfigurationManager.AppSettings["ServerIP"] ?? "127.0.0.1";
            serverPort = ConfigurationManager.AppSettings["ServerPort"] ?? "9001";
            currentUsername = this.username;
            lblCurrentUser.Text = $"Đang đăng nhập: {this.username}";
            UpdateUIState(false);
        }

        private void UpdateUIState(bool connected)
        {
            btnDisconnect.Enabled = connected;
            btnSendBroadcast.Enabled = connected;
            btnSendDM.Enabled = connected;
            txtDMRecipient.Enabled = connected;
            txtDMMessage.Enabled = connected;
            txtServerMessage.Enabled = connected;
            btnSendServer.Enabled = connected;
            lstOnlineUsers.Enabled = connected;
            btnCreateGroup.Enabled = connected;
            btnJoinGroup.Enabled = connected;
            btnLeaveGroup.Enabled = connected;
            btnSendGroupMsg.Enabled = connected;
        }

        private void Client_MessageReceived(object sender, string message)
        {
            if (rtbMessages.InvokeRequired)
            {
                rtbMessages.Invoke(new Action(() => ProcessMessage(message)));
            }
            else
            {
                ProcessMessage(message);
            }
        }

        private void ProcessMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            // Xử lý các loại message từ server
            if (message.StartsWith("ONLINE_LIST:"))
            {
                var content = message.Substring("ONLINE_LIST:".Length);
                var match = System.Text.RegularExpressions.Regex.Match(content, @"^(.+?)\s*\(Total:\s*(\d+)\)");
                if (match.Success)
                {
                    var usersStr = match.Groups[1].Value;
                    var total = match.Groups[2].Value;
                    
                    onlineUsers.Clear();
                    if (!string.IsNullOrWhiteSpace(usersStr))
                    {
                        onlineUsers = usersStr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(u => u.Trim())
                            .Where(u => !string.IsNullOrEmpty(u))
                            .ToList();
                    }

                    UpdateOnlineList();
                    AppendMessage($"📋 Danh sách người online đã cập nhật (Tổng: {total})", Color.Blue);
                }
            }
            else if (message.StartsWith("INFO:WELCOME"))
            {
                var username = message.Substring("INFO:WELCOME ".Length).Trim();
                currentUsername = username;
                lblCurrentUser.Text = $"Đang đăng nhập: {username}";
                AppendMessage($"✅ Đăng nhập thành công! Chào mừng {username}", Color.Green);
                UpdateUIState(true);
            }
            else if (message.StartsWith("ERROR:"))
            {
                AppendMessage($"❌ Lỗi: {message.Substring(6)}", Color.Red);
                if (message.StartsWith("ERROR:INVALID_CREDENTIALS") || message.StartsWith("ERROR:USERNAME_TAKEN"))
                {
                    MessageBox.Show("Đăng nhập thất bại. Ứng dụng sẽ thoát.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else if (message.StartsWith("DM_FROM:"))
            {
                var rest = message.Substring("DM_FROM:".Length);
                var parts = rest.Split(new[] { ':' }, 2);
                if (parts.Length >= 2)
                {
                    var from = parts[0];
                    var text = parts[1];
                    AppendMessage($"💬 [{from}]: {text}", Color.Purple);
                }
            }
            else if (message.StartsWith("BROADCAST_FROM:"))
            {
                var rest = message.Substring("BROADCAST_FROM:".Length);
                var parts = rest.Split(new[] { ':' }, 2);
                if (parts.Length >= 2)
                {
                    var from = parts[0];
                    var text = parts[1];
                    AppendMessage($"📢 [{from}]: {text}", Color.DarkBlue);
                }
            }
            else if (message.StartsWith("GROUP_FROM:"))
            {
                var rest = message.Substring("GROUP_FROM:".Length);
                var parts = rest.Split(new[] { ':' }, 3);
                if (parts.Length >= 3)
                {
                    var group = parts[0];
                    var from = parts[1];
                    var text = parts[2];
                    AppendMessage($"👥 [{group}] [{from}]: {text}", Color.DarkGreen);
                }
            }
            else if (message.StartsWith("OFFLINE_FROM:"))
            {
                var rest = message.Substring("OFFLINE_FROM:".Length);
                var parts = rest.Split(new[] { ':' }, 2);
                if (parts.Length >= 2)
                {
                    var from = parts[0];
                    var text = parts[1];
                    AppendMessage($"📬 [Tin nhắn offline từ {from}]: {text}", Color.Orange);
                }
            }
            else if (message.StartsWith("OFFLINE_GROUP_FROM:"))
            {
                var rest = message.Substring("OFFLINE_GROUP_FROM:".Length);
                var parts = rest.Split(new[] { ':' }, 3);
                if (parts.Length >= 3)
                {
                    var group = parts[0];
                    var from = parts[1];
                    var text = parts[2];
                    AppendMessage($"📬 [Nhóm {group}] [Tin nhắn offline từ {from}]: {text}", Color.Orange);
                }
            }
            else if (message.StartsWith("GROUP_OK:"))
            {
                var rest = message.Substring("GROUP_OK:".Length);
                var parts = rest.Split(new[] { ':' }, 2);
                if (parts.Length >= 2)
                {
                    var action = parts[0];
                    var groupName = parts[1];
                    
                    if (action == "CREATED" || action == "JOINED")
                    {
                        if (!joinedGroups.Contains(groupName, StringComparer.OrdinalIgnoreCase))
                        {
                            joinedGroups.Add(groupName);
                            UpdateGroupList();
                        }
                        AppendMessage($"✅ Đã {GetActionText(action)} nhóm '{groupName}'", Color.Green);
                    }
                    else if (action == "LEFT")
                    {
                        joinedGroups.RemoveAll(g => g.Equals(groupName, StringComparison.OrdinalIgnoreCase));
                        UpdateGroupList();
                        AppendMessage($"✅ Đã rời nhóm '{groupName}'", Color.Green);
                    }
                }
            }
            else if (message.StartsWith("SERVER_MSG:"))
            {
                var text = message.Substring("SERVER_MSG:".Length);
                AppendMessage($"🔔 [Server]: {text}", Color.DarkMagenta);
            }
            else if (message.StartsWith("INFO:"))
            {
                AppendMessage($"ℹ️ {message.Substring(5)}", Color.DarkGray);
            }
            else
            {
                AppendMessage($"📨 {message}", Color.Black);
            }
        }

        private string GetActionText(string action)
        {
            switch (action)
            {
                case "CREATED": return "tạo";
                case "JOINED": return "tham gia";
                case "LEFT": return "rời";
                default: return action;
            }
        }

        private void AppendMessage(string text, Color color)
        {
            rtbMessages.SelectionStart = rtbMessages.TextLength;
            rtbMessages.SelectionLength = 0;
            rtbMessages.SelectionColor = color;
            rtbMessages.AppendText($"[{DateTime.Now:HH:mm:ss}] {text}\r\n");
            rtbMessages.SelectionColor = rtbMessages.ForeColor;
            rtbMessages.ScrollToCaret();
        }

        private void UpdateOnlineList()
        {
            if (lstOnlineUsers.InvokeRequired)
            {
                lstOnlineUsers.Invoke(new Action(() => UpdateOnlineList()));
                return;
            }

            lstOnlineUsers.Items.Clear();
            string currentRecipient = txtDMRecipient.Text.Trim();
            int indexToSelect = -1;
            int currentIndex = 0;
            foreach (var user in onlineUsers)
            {
                if (!user.Equals(currentUsername, StringComparison.OrdinalIgnoreCase))
                {
                    lstOnlineUsers.Items.Add(user);
                    if (indexToSelect == -1 &&
                        !string.IsNullOrEmpty(currentRecipient) &&
                        user.Equals(currentRecipient, StringComparison.OrdinalIgnoreCase))
                    {
                        indexToSelect = currentIndex;
                    }
                    currentIndex++;
                }
            }

            if (indexToSelect >= 0 && indexToSelect < lstOnlineUsers.Items.Count)
            {
                lstOnlineUsers.SelectedIndex = indexToSelect;
            }
        }

        private void UpdateGroupList()
        {
            if (lstGroups.InvokeRequired)
            {
                lstGroups.Invoke(new Action(() => UpdateGroupList()));
                return;
            }

            lstGroups.Items.Clear();
            foreach (var group in joinedGroups)
            {
                lstGroups.Items.Add(group);
            }
        }

        private async void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (client != null)
                {
                    await client.SendToServer("LOGOUT");
                    client.CloseAndDisconnect();
                }
            }
            catch { }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void frmClient_Load(object sender, EventArgs e)
        {
            await ConnectAndLoginAsync();
        }

        private async Task ConnectAndLoginAsync()
        {
            try
            {
                if (!client.SetServerIPAddress(serverIp) || !client.SetPortNumber(serverPort))
                {
                    MessageBox.Show("Cấu hình máy chủ không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                await client.ConnectToServer();
                AppendMessage($"🔌 Đã kết nối tới {serverIp}:{serverPort}", Color.Blue);
                await client.SendToServer($"LOGIN:{username}:{password}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void btnSendBroadcast_Click(object sender, EventArgs e)
        {
            string message = txtBroadcastMessage.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await client.SendToServer(message);
                AppendMessage($"Bạn (Broadcast): {message}", Color.DarkBlue);
                txtBroadcastMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSendDM_Click(object sender, EventArgs e)
        {
            string target = txtDMRecipient.Text.Trim();
            if (string.IsNullOrEmpty(target) && lstOnlineUsers.SelectedItem != null)
            {
                target = lstOnlineUsers.SelectedItem.ToString();
            }

            if (string.IsNullOrEmpty(target))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tên người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = txtDMMessage.Text.Trim();

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await client.SendToServer($"DM:{target}:{message}");
                AppendMessage($"Bạn → [{target}]: {message}", Color.Purple);
                txtDMMessage.Clear();
                txtDMRecipient.Text = target;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreateGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text.Trim();
            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await client.SendToServer($"GROUP_CREATE:{groupName}");
                txtGroupName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnJoinGroup_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text.Trim();
            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await client.SendToServer($"GROUP_JOIN:{groupName}");
                txtGroupName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tham gia nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLeaveGroup_Click(object sender, EventArgs e)
        {
            if (lstGroups.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string groupName = lstGroups.SelectedItem.ToString();
            try
            {
                await client.SendToServer($"GROUP_LEAVE:{groupName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi rời nhóm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSendGroupMsg_Click(object sender, EventArgs e)
        {
            if (lstGroups.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string groupName = lstGroups.SelectedItem.ToString();
            string message = txtGroupMessage.Text.Trim();

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await client.SendToServer($"GROUP_MSG:{groupName}:{message}");
                AppendMessage($"Bạn → [{groupName}]: {message}", Color.DarkGreen);
                txtGroupMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBroadcastMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSendBroadcast_Click(sender, e);
            }
        }

        private void txtDMMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSendDM_Click(sender, e);
            }
        }

        private void txtGroupMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSendGroupMsg_Click(sender, e);
            }
        }

        private async void btnSendServer_Click(object sender, EventArgs e)
        {
            string message = txtServerMessage.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Vui lòng nhập tin nhắn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                await client.SendToServer($"SERVER_MSG:{message}");
                AppendMessage($"Bạn → [Server]: {message}", Color.MediumVioletRed);
                txtServerMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin nhắn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtServerMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                btnSendServer_Click(sender, e);
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

        private void lstOnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOnlineUsers.SelectedItem != null)
            {
                txtDMRecipient.Text = lstOnlineUsers.SelectedItem.ToString();
            }
        }
    }
}
