using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
namespace Bài_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Lấy tất cả network interface (card mạng)
            foreach(NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if(nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType!= NetworkInterfaceType.Loopback)
                {
                    Console.WriteLine("Tên card mạng: " + nic.Name);
                    IPInterfaceProperties ipProps = nic.GetIPProperties();

                    //Lấy địa chỉ IP và Subnet Mask
                    foreach(UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
                    {
                        if(ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)// chỉ IP V4
                        {
                            Console.WriteLine("Địa chỉ IP :" + ip.Address);
                            Console.WriteLine("Subnet Mask : " + ip.IPv4Mask);
                        }    
                    }  
                    foreach(GatewayIPAddressInformation gateway in ipProps.GatewayAddresses)
                    {
                        Console.WriteLine("Default Gateway : " + gateway.Address);
                    }
                    Console.WriteLine("----------------------------------------------");
                }
            }
            Console.ReadKey();
        }
    }
}
