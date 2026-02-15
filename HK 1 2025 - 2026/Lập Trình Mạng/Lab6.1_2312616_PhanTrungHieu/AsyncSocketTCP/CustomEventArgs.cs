using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSocketTCP
{
    public class ClientConnectedEventArgs:EventArgs
    {
        public string NewClient { get; set; }
        public ClientConnectedEventArgs(string _newClient)
        {
            NewClient = _newClient;
        }
    }
    public class ClientDisconnectedEventArgs : EventArgs
    {
        public string RemovedClient { get; set; }

        public ClientDisconnectedEventArgs(string _removedClient)
        {
            RemovedClient = _removedClient;
        }
    }

    public class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string FromClient { get; set; }

        public MessageReceivedEventArgs(string _message, string _fromClient)
        {
            Message = _message;
            FromClient = _fromClient;
        }
    }
}
