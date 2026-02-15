using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadNetworkInfo();
        }
        private void LoadNetworkInfo()
        {
            txtResult.Clear();
            txtResult.AppendText("===== THÔNG TIN GIAO THỨC IP =====\r\n\r\n");

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                     ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                {
                    txtResult.AppendText("Tên card mạng: " + ni.Name + "\r\n");

                    var ipProps = ni.GetIPProperties();

                    // Địa chỉ IP
                    foreach (var addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                            txtResult.AppendText("  IPv4 Address : " + addr.Address + "\r\n");

                        if (addr.Address.AddressFamily == AddressFamily.InterNetworkV6)
                            txtResult.AppendText("  IPv6 Address : " + addr.Address + "\r\n");
                    }

                    // Subnet Mask
                    var ipv4 = ipProps.UnicastAddresses
                        .FirstOrDefault(a => a.Address.AddressFamily == AddressFamily.InterNetwork);

                    if (ipv4 != null)
                        txtResult.AppendText("  Subnet Mask  : " + ipv4.IPv4Mask + "\r\n");

                    // Default Gateway
                    foreach (var gw in ipProps.GatewayAddresses)
                    {
                        txtResult.AppendText("  Default Gateway : " + gw.Address + "\r\n");
                    }

                    txtResult.AppendText("\r\n---------------------------------------------\r\n\r\n");
                }
            }
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text.Trim();
            txtResult.Clear();

            if (string.IsNullOrEmpty(host))
            {
                MessageBox.Show("Vui lòng nhập tên miền!");
                return;
            }

            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);

                txtResult.AppendText("Tên miền: " + hostInfo.HostName + Environment.NewLine);

                txtResult.AppendText("Địa chỉ IPv4:\n");
                foreach (IPAddress ip in hostInfo.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        txtResult.AppendText("→ " + ip.ToString() + "\r\n");
                }

                txtResult.AppendText("Địa chỉ IPv6:\n");
                foreach (IPAddress ip in hostInfo.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetworkV6)
                        txtResult.AppendText("→ " + ip.ToString() + "\r\n");
                }
            }
            catch (Exception)
            {
                txtResult.AppendText("Không phân giải được tên miền: " + host + Environment.NewLine);
            }
        }
    }
}
