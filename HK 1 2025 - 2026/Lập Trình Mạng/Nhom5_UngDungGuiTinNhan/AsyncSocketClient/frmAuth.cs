using AsyncSocketTCP;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncSocketClient
{
    public partial class frmAuth : Form
    {
        private readonly AsyncSocketTCPClient _client = new AsyncSocketTCPClient();
        private readonly string _serverIp;
        private readonly string _serverPort;
        private bool _connected;
        private readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(5);

        public string AuthenticatedUsername { get; private set; }
        public string AuthenticatedPassword { get; private set; }

        public frmAuth()
        {
            InitializeComponent();
            _serverIp = ConfigurationManager.AppSettings["ServerIP"] ?? "127.0.0.1";
            _serverPort = ConfigurationManager.AppSettings["ServerPort"] ?? "9001";
            lblLoginStatus.Text = string.Empty;
            lblRegisterStatus.Text = string.Empty;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await HandleLoginAsync();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            await HandleRegisterAsync();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async Task HandleLoginAsync()
        {
            string username = txtLoginUsername.Text.Trim();
            string password = txtLoginPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                SetStatus(lblLoginStatus, "Vui lòng nhập đầy đủ thông tin.", Color.DarkRed);
                return;
            }

            try
            {
                ToggleLoginInputs(false);
                SetStatus(lblLoginStatus, "Đang xác thực...", Color.DimGray);

                await EnsureConnectedAsync();
                var responseTask = WaitForMessageAsync(msg => msg.StartsWith("INFO:LOGIN_OK") || msg.StartsWith("ERROR:"), _defaultTimeout);
                await _client.SendToServer($"LOGIN_CHECK:{username}:{password}");
                string response = await responseTask;

                if (response.StartsWith("INFO:LOGIN_OK"))
                {
                    AuthenticatedUsername = username;
                    AuthenticatedPassword = password;
                    _client.CloseAndDisconnect();
                    _connected = false;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    SetStatus(lblLoginStatus, MapServerError(response), Color.DarkRed);
                }
            }
            catch (Exception ex)
            {
                SetStatus(lblLoginStatus, ex.Message, Color.DarkRed);
                _connected = false;
            }
            finally
            {
                ToggleLoginInputs(true);
            }
        }

        private async Task HandleRegisterAsync()
        {
            string username = txtRegisterUsername.Text.Trim();
            string password = txtRegisterPassword.Text;
            string confirm = txtRegisterConfirm.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                SetStatus(lblRegisterStatus, "Vui lòng nhập đầy đủ thông tin.", Color.DarkRed);
                return;
            }

            if (!string.Equals(password, confirm, StringComparison.Ordinal))
            {
                SetStatus(lblRegisterStatus, "Mật khẩu xác nhận không khớp.", Color.DarkRed);
                return;
            }

            try
            {
                ToggleRegisterInputs(false);
                SetStatus(lblRegisterStatus, "Đang tạo tài khoản...", Color.DimGray);

                await EnsureConnectedAsync();
                var responseTask = WaitForMessageAsync(msg => msg.StartsWith("INFO:REGISTER_OK") || msg.StartsWith("ERROR:"), _defaultTimeout);
                await _client.SendToServer($"REGISTER:{username}:{password}");
                string response = await responseTask;

                if (response.StartsWith("INFO:REGISTER_OK"))
                {
                    SetStatus(lblRegisterStatus, "Đăng ký thành công! Vui lòng đăng nhập.", Color.DarkGreen);
                    txtLoginUsername.Text = username;
                    tabAuth.SelectedTab = tabLogin;
                }
                else
                {
                    SetStatus(lblRegisterStatus, MapServerError(response), Color.DarkRed);
                }
            }
            catch (Exception ex)
            {
                SetStatus(lblRegisterStatus, ex.Message, Color.DarkRed);
                _connected = false;
            }
            finally
            {
                ToggleRegisterInputs(true);
            }
        }

        private async Task EnsureConnectedAsync()
        {
            if (_connected)
            {
                return;
            }

            if (!_client.SetServerIPAddress(_serverIp) || !_client.SetPortNumber(_serverPort))
            {
                throw new InvalidOperationException("Không thể thiết lập địa chỉ máy chủ hoặc cổng.");
            }

            await _client.ConnectToServer();
            _connected = true;
        }

        private Task<string> WaitForMessageAsync(Func<string, bool> predicate, TimeSpan timeout)
        {
            var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
            EventHandler<string> handler = null;
            var cts = new CancellationTokenSource(timeout);
            CancellationTokenRegistration registration = default;

            handler = (s, message) =>
            {
                if (predicate(message))
                {
                    _client.MessageReceived -= handler;
                    registration.Dispose();
                    cts.Dispose();
                    tcs.TrySetResult(message);
                }
            };

            registration = cts.Token.Register(() =>
            {
                _client.MessageReceived -= handler;
                tcs.TrySetException(new TimeoutException("Server không phản hồi kịp thời."));
                cts.Dispose();
            });

            _client.MessageReceived += handler;
            return tcs.Task;
        }

        private void ToggleLoginInputs(bool enabled)
        {
            txtLoginUsername.Enabled = enabled;
            txtLoginPassword.Enabled = enabled;
            btnLogin.Enabled = enabled;
        }

        private void ToggleRegisterInputs(bool enabled)
        {
            txtRegisterUsername.Enabled = enabled;
            txtRegisterPassword.Enabled = enabled;
            txtRegisterConfirm.Enabled = enabled;
            btnRegister.Enabled = enabled;
        }

        private void SetStatus(Label label, string text, Color color)
        {
            label.ForeColor = color;
            label.Text = text;
        }

        private string MapServerError(string raw)
        {
            if (raw.StartsWith("ERROR:INVALID_CREDENTIALS")) return "Sai tên đăng nhập hoặc mật khẩu.";
            if (raw.StartsWith("ERROR:USERNAME_TAKEN")) return "Tên đăng nhập đã được sử dụng.";
            if (raw.StartsWith("ERROR:REGISTER_FAILED")) return "Không thể đăng ký tài khoản.";
            if (raw.StartsWith("ERROR:REGISTER_FORMAT")) return "Định dạng yêu cầu không hợp lệ.";
            if (raw.StartsWith("ERROR:LOGIN_FORMAT")) return "Định dạng đăng nhập không hợp lệ.";
            return raw;
        }

        private void frmAuth_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _client.CloseAndDisconnect();
            }
            catch { }
        }
    }
}
