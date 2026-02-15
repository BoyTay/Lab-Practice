using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;

namespace AsyncSocketTCP
{
    public class ClientInfo
    {
        public string Username { get; set; }
        public TcpClient Client { get; set; }
        public string EndPoint { get; set; }

        // Cờ xác nhận đã LOGIN hợp lệ
        public bool IsLoggedIn { get; set; }
    }

    internal class OfflineMessage
    {
        public string Type { get; set; } // "DM" | "GROUP"
        public string From { get; set; }
        public string Group { get; set; } // only for GROUP
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }

    public class AsyncSocketTCPServer
    {
        IPAddress mIP;
        int mPort;
        TcpListener mTCPListener;
        volatile bool KeepRunning;

        private readonly object _clientsLock = new object();
        public List<ClientInfo> ConnectedClients = new List<ClientInfo>();

        // Groups and offline store
        private readonly object _stateLock = new object();
        private readonly Dictionary<string, HashSet<string>> _groups = new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, List<OfflineMessage>> _offline = new Dictionary<string, List<OfflineMessage>>(StringComparer.OrdinalIgnoreCase);

        private readonly AccountRepository _accountRepository;
        private readonly SemaphoreSlim _accountInitLock = new SemaphoreSlim(1, 1);
        private bool _accountStoreReady;

        public event EventHandler<ClientConnectedEventArgs> ClientConnectedEvent;
        public event EventHandler<ClientDisconnectedEventArgs> ClientDisconnectedEvent;
        public event EventHandler<MessageReceivedEventArgs> MessageReceivedEvent;

        public AsyncSocketTCPServer(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("A SQL connection string is required to start the chat server.", nameof(connectionString));
            }

            _accountRepository = new AccountRepository(connectionString);
        }

        protected virtual void OnClientConnected(ClientConnectedEventArgs e)
            => ClientConnectedEvent?.Invoke(this, e);
        protected virtual void OnClientDisconnected(ClientDisconnectedEventArgs e)
            => ClientDisconnectedEvent?.Invoke(this, e);
        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
            => MessageReceivedEvent?.Invoke(this, e);

        public async void StartListeningForIncomingConnection(IPAddress ipaddr = null, int port = 9001)
        {
            if (ipaddr == null) ipaddr = IPAddress.Any;
            if (port <= 0) port = 9001;

            mIP = ipaddr;
            mPort = port;

            mTCPListener = new TcpListener(mIP, mPort);
            mTCPListener.Start();
            KeepRunning = true;

            Debug.WriteLine($"Server started on {mIP}:{mPort}");

            await EnsureAccountStoreAsync().ConfigureAwait(false);

            while (KeepRunning)
            {
                TcpClient newClient = null;
                try
                {
                    newClient = await mTCPListener.AcceptTcpClientAsync().ConfigureAwait(false);
                }
                catch (ObjectDisposedException) { break; }
                catch (InvalidOperationException) { break; }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Accept error: {ex.Message}");
                    if (!KeepRunning) break;
                    continue;
                }

                if (newClient == null) continue;

                string endPoint = "unknown";
                try { endPoint = newClient.Client?.RemoteEndPoint?.ToString() ?? "unknown"; } catch { }

                var info = new ClientInfo
                {
                    Client = newClient,
                    Username = $"Client_{GetClientCountSafe() + 1}",
                    EndPoint = endPoint,
                    IsLoggedIn = false
                };

                AddClientSafe(info);
                OnClientConnected(new ClientConnectedEventArgs(info.EndPoint));

                // Xử lý mỗi client ở task riêng
                Task.Run(() => HandleClientAsync(info));
            }
        }

        private async Task HandleClientAsync(ClientInfo clientInfo)
        {
            var client = clientInfo.Client;

            try
            {
                using (var reader = new StreamReader(client.GetStream(), Encoding.UTF8, false, 1024, leaveOpen: false))
                using (var writer = new StreamWriter(client.GetStream(), Encoding.UTF8, 1024, leaveOpen: true) { AutoFlush = true })
                {
                    while (KeepRunning)
                    {
                        string line;
                        try
                        {
                            line = await reader.ReadLineAsync().ConfigureAwait(false);
                        }
                        catch (IOException)
                        {
                            Debug.WriteLine($"Client {clientInfo.Username} ({clientInfo.EndPoint}) disconnected unexpectedly.");
                            RemoveClient(clientInfo);
                            break;
                        }
                        catch (ObjectDisposedException)
                        {
                            RemoveClient(clientInfo);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"Read error from {clientInfo.EndPoint}: {ex.Message}");
                            RemoveClient(clientInfo);
                            break;
                        }

                        if (line == null)
                        {
                            // EOF
                            Debug.WriteLine($"Client {clientInfo.Username} ({clientInfo.EndPoint}) disconnected (socket closed).");
                            RemoveClient(clientInfo);
                            break;
                        }

                        var msg = line.Trim();
                        if (msg.Length == 0) continue;

                        // For logging on server UI (mask sensitive payloads)
                        var logMessage = SanitizeMessageForLog(msg);
                        OnMessageReceived(new MessageReceivedEventArgs(logMessage, clientInfo.EndPoint));

                        // BẮT BUỘC LOGIN trước
                        if (!clientInfo.IsLoggedIn)
                        {
                            if (msg.StartsWith("REGISTER:", StringComparison.OrdinalIgnoreCase))
                            {
                                await HandleRegisterCommand(msg, writer).ConfigureAwait(false);
                            }
                            else if (msg.StartsWith("LOGIN_CHECK:", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!TryParseCredentials(msg, "LOGIN_CHECK:", out var desired, out var password))
                                {
                                    await writer.WriteLineAsync("ERROR:LOGIN_FORMAT LOGIN:username:password").ConfigureAwait(false);
                                    continue;
                                }

                                bool valid = await _accountRepository.ValidateCredentialsAsync(desired, password).ConfigureAwait(false);
                                if (!valid)
                                {
                                    await writer.WriteLineAsync("ERROR:INVALID_CREDENTIALS").ConfigureAwait(false);
                                }
                                else
                                {
                                    await writer.WriteLineAsync("INFO:LOGIN_OK").ConfigureAwait(false);
                                }
                            }
                            else if (msg.StartsWith("LOGIN:", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!TryParseCredentials(msg, "LOGIN:", out var desired, out var password))
                                {
                                    await writer.WriteLineAsync("ERROR:LOGIN_FORMAT LOGIN:username:password").ConfigureAwait(false);
                                    continue;
                                }

                                bool valid = await _accountRepository.ValidateCredentialsAsync(desired, password).ConfigureAwait(false);
                                if (!valid)
                                {
                                    await writer.WriteLineAsync("ERROR:INVALID_CREDENTIALS").ConfigureAwait(false);
                                    continue;
                                }

                                if (IsUsernameTaken(desired))
                                {
                                    await writer.WriteLineAsync("ERROR:USERNAME_TAKEN").ConfigureAwait(false);
                                    continue;
                                }

                                clientInfo.Username = desired;
                                clientInfo.IsLoggedIn = true;

                                await writer.WriteLineAsync($"INFO:WELCOME {clientInfo.Username}").ConfigureAwait(false);
                                BroadcastOnlineList();
                                await FlushOfflineFor(clientInfo).ConfigureAwait(false);
                            }
                            else
                            {
                                await writer.WriteLineAsync("Please login with 'LOGIN:username:password'").ConfigureAwait(false);
                            }
                            continue;
                        }

                        if (string.Equals(msg, "LOGOUT", StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.WriteLine($"Client {clientInfo.Username} logged out.");
                            RemoveClient(clientInfo);
                            break;
                        }

                        // Command routing
                        if (msg.StartsWith("DM:", StringComparison.OrdinalIgnoreCase))
                        {
                            await HandleDirectMessage(clientInfo, msg, writer).ConfigureAwait(false);
                        }
                        else if (msg.StartsWith("SERVER_MSG:", StringComparison.OrdinalIgnoreCase))
                        {
                            await HandleServerPrivateMessage(clientInfo, msg, writer).ConfigureAwait(false);
                        }
                        else if (msg.StartsWith("GROUP_CREATE:", StringComparison.OrdinalIgnoreCase))
                        {
                            await HandleGroupCreate(clientInfo, msg, writer).ConfigureAwait(false);
                        }
                        else if (msg.StartsWith("GROUP_JOIN:", StringComparison.OrdinalIgnoreCase))
                        {
                            await HandleGroupJoin(clientInfo, msg, writer).ConfigureAwait(false);
                        }
                        else if (msg.StartsWith("GROUP_LEAVE:", StringComparison.OrdinalIgnoreCase))
                        {
                            await HandleGroupLeave(clientInfo, msg, writer).ConfigureAwait(false);
                        }
                        else if (msg.StartsWith("GROUP_MSG:", StringComparison.OrdinalIgnoreCase))
                        {
                            await HandleGroupMessage(clientInfo, msg, writer).ConfigureAwait(false);
                        }
                        else
                        {
                            // Default: broadcast to all logged-in clients (except sender)
                            await BroadcastFromAsync(clientInfo, msg).ConfigureAwait(false);
                        }
                    }
                }
            }
            catch (IOException)
            {
                RemoveClient(clientInfo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
                RemoveClient(clientInfo);
            }
        }

        private bool IsUsernameTaken(string username)
        {
            lock (_clientsLock)
            {
                return ConnectedClients.Any(c => c.IsLoggedIn && string.Equals(c.Username, username, StringComparison.OrdinalIgnoreCase));
            }
        }

        private ClientInfo FindOnlineByUsername(string username)
        {
            lock (_clientsLock)
            {
                return ConnectedClients.FirstOrDefault(c => c.IsLoggedIn && string.Equals(c.Username, username, StringComparison.OrdinalIgnoreCase));
            }
        }

        private async Task SendLineAsync(ClientInfo client, string line)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(line + "\r\n");
                await client.Client.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
            }
            catch
            {
                RemoveClient(client);
            }
        }

        private async Task HandleDirectMessage(ClientInfo from, string msg, StreamWriter writer)
        {
            // DM:target:message
            var rest = msg.Substring(3);
            var parts = rest.Split(new[] { ':' }, 2);
            if (parts.Length < 2)
            {
                await writer.WriteLineAsync("ERROR:DM_FORMAT DM:targetUsername:message").ConfigureAwait(false);
                return;
            }
            var target = parts[0].Trim();
            var text = parts[1];

            var to = FindOnlineByUsername(target);
            if (to != null)
            {
                await SendLineAsync(to, $"DM_FROM:{from.Username}:{text}").ConfigureAwait(false);
                await writer.WriteLineAsync("INFO:DM_SENT").ConfigureAwait(false);
            }
            else
            {
                // queue offline
                EnqueueOffline(target, new OfflineMessage
                {
                    Type = "DM",
                    From = from.Username,
                    Text = text,
                    Time = DateTime.UtcNow
                });
                await writer.WriteLineAsync("INFO:USER_OFFLINE_MESSAGE_STORED").ConfigureAwait(false);
            }
        }

        private bool TryParseCredentials(string message, string prefix, out string username, out string password)
        {
            username = string.Empty;
            password = string.Empty;

            var payload = message.Substring(prefix.Length);
            var parts = payload.Split(new[] { ':' }, 2);
            if (parts.Length < 2)
            {
                return false;
            }

            username = parts[0].Trim();
            password = parts[1];
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrEmpty(password);
        }

        private static string SanitizeMessageForLog(string message)
        {
            if (message.StartsWith("LOGIN:", StringComparison.OrdinalIgnoreCase) ||
                message.StartsWith("LOGIN_CHECK:", StringComparison.OrdinalIgnoreCase) ||
                message.StartsWith("REGISTER:", StringComparison.OrdinalIgnoreCase))
            {
                var firstColon = message.IndexOf(':');
                if (firstColon >= 0)
                {
                    var secondColon = message.IndexOf(':', firstColon + 1);
                    if (secondColon > firstColon)
                    {
                        return message.Substring(0, secondColon);
                    }
                }
            }

            return message;
        }

        private async Task HandleRegisterCommand(string msg, StreamWriter writer)
        {
            if (!TryParseCredentials(msg, "REGISTER:", out var username, out var password))
            {
                await writer.WriteLineAsync("ERROR:REGISTER_FORMAT REGISTER:username:password").ConfigureAwait(false);
                return;
            }

            bool created = await _accountRepository.RegisterAsync(username, password).ConfigureAwait(false);
            if (created)
            {
                await writer.WriteLineAsync("INFO:REGISTER_OK").ConfigureAwait(false);
            }
            else
            {
                await writer.WriteLineAsync("ERROR:REGISTER_FAILED").ConfigureAwait(false);
            }
        }

        private async Task HandleServerPrivateMessage(ClientInfo from, string msg, StreamWriter writer)
        {
            var text = msg.Substring("SERVER_MSG:".Length).Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                await writer.WriteLineAsync("ERROR:SERVER_MSG_REQUIRED").ConfigureAwait(false);
                return;
            }

            Debug.WriteLine($"[SERVER_DM] {from.Username}: {text}");
            await writer.WriteLineAsync("INFO:SERVER_MSG_DELIVERED").ConfigureAwait(false);
        }

        private async Task HandleGroupCreate(ClientInfo from, string msg, StreamWriter writer)
        {
            var name = msg.Substring("GROUP_CREATE:".Length).Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                await writer.WriteLineAsync("ERROR:GROUP_NAME_REQUIRED").ConfigureAwait(false);
                return;
            }

            lock (_stateLock)
            {
                if (_groups.ContainsKey(name))
                {
                    name = null;
                }
                else
                {
                    _groups[name] = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { from.Username };
                }
            }

            if (name == null)
                await writer.WriteLineAsync("ERROR:GROUP_EXISTS").ConfigureAwait(false);
            else
                await writer.WriteLineAsync($"GROUP_OK:CREATED:{name}").ConfigureAwait(false);
        }

        private async Task HandleGroupJoin(ClientInfo from, string msg, StreamWriter writer)
        {
            var name = msg.Substring("GROUP_JOIN:".Length).Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                await writer.WriteLineAsync("ERROR:GROUP_NAME_REQUIRED").ConfigureAwait(false);
                return;
            }

            bool ok = false;
            lock (_stateLock)
            {
                if (_groups.TryGetValue(name, out var members))
                {
                    members.Add(from.Username);
                    ok = true;
                }
            }

            await writer.WriteLineAsync(ok ? $"GROUP_OK:JOINED:{name}" : "ERROR:GROUP_NOT_FOUND").ConfigureAwait(false);
        }

        private async Task HandleGroupLeave(ClientInfo from, string msg, StreamWriter writer)
        {
            var name = msg.Substring("GROUP_LEAVE:".Length).Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                await writer.WriteLineAsync("ERROR:GROUP_NAME_REQUIRED").ConfigureAwait(false);
                return;
            }

            bool ok = false;
            lock (_stateLock)
            {
                if (_groups.TryGetValue(name, out var members))
                {
                    if (members.Remove(from.Username))
                        ok = true;
                }
            }

            await writer.WriteLineAsync(ok ? $"GROUP_OK:LEFT:{name}" : "ERROR:GROUP_NOT_FOUND_OR_NOT_MEMBER").ConfigureAwait(false);
        }

        private async Task HandleGroupMessage(ClientInfo from, string msg, StreamWriter writer)
        {
            // GROUP_MSG:groupName:message
            var rest = msg.Substring("GROUP_MSG:".Length);
            var parts = rest.Split(new[] { ':' }, 2);
            if (parts.Length < 2)
            {
                await writer.WriteLineAsync("ERROR:GROUP_MSG_FORMAT GROUP_MSG:groupName:message").ConfigureAwait(false);
                return;
            }
            var group = parts[0].Trim();
            var text = parts[1];

            List<string> members;
            lock (_stateLock)
            {
                if (!_groups.TryGetValue(group, out var set))
                {
                    members = null;
                }
                else
                {
                    members = set.ToList();
                }
            }

            if (members == null)
            {
                await writer.WriteLineAsync("ERROR:GROUP_NOT_FOUND").ConfigureAwait(false);
                return;
            }

            if (!members.Contains(from.Username, StringComparer.OrdinalIgnoreCase))
            {
                await writer.WriteLineAsync("ERROR:NOT_A_MEMBER").ConfigureAwait(false);
                return;
            }

            // Deliver to online members, queue for offline
            foreach (var member in members)
            {
                if (member.Equals(from.Username, StringComparison.OrdinalIgnoreCase))
                    continue;

                var target = FindOnlineByUsername(member);
                if (target != null)
                {
                    await SendLineAsync(target, $"GROUP_FROM:{group}:{from.Username}:{text}").ConfigureAwait(false);
                }
                else
                {
                    EnqueueOffline(member, new OfflineMessage
                    {
                        Type = "GROUP",
                        Group = group,
                        From = from.Username,
                        Text = text,
                        Time = DateTime.UtcNow
                    });
                }
            }

            await writer.WriteLineAsync("INFO:GROUP_MSG_SENT").ConfigureAwait(false);
        }

        private void EnqueueOffline(string targetUser, OfflineMessage msg)
        {
            lock (_stateLock)
            {
                if (!_offline.TryGetValue(targetUser, out var list))
                {
                    list = new List<OfflineMessage>();
                    _offline[targetUser] = list;
                }
                list.Add(msg);
            }
        }

        private async Task FlushOfflineFor(ClientInfo clientInfo)
        {
            List<OfflineMessage> list = null;
            lock (_stateLock)
            {
                if (_offline.TryGetValue(clientInfo.Username, out var l) && l.Count > 0)
                {
                    list = new List<OfflineMessage>(l);
                    _offline.Remove(clientInfo.Username);
                }
            }

            if (list == null || list.Count == 0) return;

            foreach (var m in list.OrderBy(x => x.Time))
            {
                if (m.Type == "DM")
                {
                    await SendLineAsync(clientInfo, $"OFFLINE_FROM:{m.From}:{m.Text}").ConfigureAwait(false);
                }
                else if (m.Type == "GROUP")
                {
                    await SendLineAsync(clientInfo, $"OFFLINE_GROUP_FROM:{m.Group}:{m.From}:{m.Text}").ConfigureAwait(false);
                }
            }
        }

        private async Task BroadcastFromAsync(ClientInfo from, string text)
        {
            string line = $"BROADCAST_FROM:{from.Username}:{text}";
            byte[] data = Encoding.UTF8.GetBytes(line + "\r\n");

            List<ClientInfo> clientsSnapshot;
            lock (_clientsLock)
            {
                clientsSnapshot = ConnectedClients.Where(c => c.IsLoggedIn).ToList();
            }

            foreach (var client in clientsSnapshot)
            {
                if (ReferenceEquals(client, from)) continue;

                try
                {
                    await client.Client.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
                }
                catch
                {
                    RemoveClient(client);
                }
            }
        }

        private async Task EnsureAccountStoreAsync()
        {
            if (_accountStoreReady)
            {
                return;
            }

            await _accountInitLock.WaitAsync().ConfigureAwait(false);
            try
            {
                if (_accountStoreReady)
                {
                    return;
                }

                await _accountRepository.InitializeAsync().ConfigureAwait(false);
                _accountStoreReady = true;
            }
            finally
            {
                _accountInitLock.Release();
            }
        }

        private void RemoveClient(ClientInfo clientInfo)
        {
            bool removed = false;
            string endpoint = clientInfo.EndPoint;

            lock (_clientsLock)
            {
                if (ConnectedClients.Contains(clientInfo))
                {
                    ConnectedClients.Remove(clientInfo);
                    removed = true;
                }
            }

            if (removed)
            {
                try { clientInfo.Client.Close(); } catch { }
                OnClientDisconnected(new ClientDisconnectedEventArgs(endpoint));
                BroadcastOnlineList();
            }
        }

        private void AddClientSafe(ClientInfo clientInfo)
        {
            lock (_clientsLock)
            {
                ConnectedClients.Add(clientInfo);
            }
        }

        private int GetClientCountSafe()
        {
            lock (_clientsLock)
            {
                return ConnectedClients.Count;
            }
        }

        private async void BroadcastOnlineList()
        {
            string[] names;
            List<ClientInfo> clientsSnapshot;

            lock (_clientsLock)
            {
                names = ConnectedClients.Where(c => c.IsLoggedIn).Select(c => c.Username).ToArray();
                clientsSnapshot = ConnectedClients.ToList();
            }

            string message = $"ONLINE_LIST:{string.Join(", ", names)} (Total: {names.Length})";
            byte[] data = Encoding.UTF8.GetBytes(message + "\r\n");

            foreach (var client in clientsSnapshot)
            {
                try
                {
                    await client.Client.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
                }
                catch
                {
                    RemoveClient(client);
                }
            }
        }

        public async void SendToAll(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg)) return;

            string line = msg.TrimEnd() + "\r\n";
            byte[] data = Encoding.UTF8.GetBytes(line);

            List<ClientInfo> clientsSnapshot;
            lock (_clientsLock)
            {
                clientsSnapshot = ConnectedClients.ToList();
            }

            foreach (var client in clientsSnapshot)
            {
                try
                {
                    await client.Client.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
                }
                catch
                {
                    RemoveClient(client);
                }
            }
        }

        public async Task<bool> SendToClient(string username, string msg)
        {
            if (string.IsNullOrWhiteSpace(msg) || string.IsNullOrWhiteSpace(username))
                return false;

            ClientInfo target = null;
            lock (_clientsLock)
            {
                target = ConnectedClients.FirstOrDefault(c => 
                    c.IsLoggedIn && string.Equals(c.Username, username, StringComparison.OrdinalIgnoreCase));
            }

            if (target == null)
                return false;

            try
            {
                await SendLineAsync(target, $"SERVER_MSG:{msg}").ConfigureAwait(false);
                return true;
            }
            catch
            {
                RemoveClient(target);
                return false;
            }
        }

        public async Task<int> GetTotalAccountCountAsync()
        {
            await EnsureAccountStoreAsync().ConfigureAwait(false);
            return await _accountRepository.GetTotalAccountCountAsync().ConfigureAwait(false);
        }

        public void StopServer()
        {
            try
            {
                KeepRunning = false;
                try { mTCPListener?.Stop(); } catch { }

                List<ClientInfo> clientsSnapshot;
                lock (_clientsLock)
                {
                    clientsSnapshot = ConnectedClients.ToList();
                    ConnectedClients.Clear();
                }

                foreach (var client in clientsSnapshot)
                {
                    try { client.Client.Close(); } catch { }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error stopping server: " + ex.Message);
            }
        }
    }
}
