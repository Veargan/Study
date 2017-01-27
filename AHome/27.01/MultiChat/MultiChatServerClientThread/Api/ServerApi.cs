using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace MultiChatServerClientThread.Api
{
    public class ServerApi
    {
        private const int PORT = 11000;
        private IPAddress address;
        private TcpListener listener;
        private ConnectionMaster connects;

        // asynchronous threads
        private Thread threadConnect;

        public ServerApi()
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

            ThreadInit();
        }

        private void ThreadInit()
        {
            threadConnect = new Thread(new ThreadStart(Listen));
            threadConnect.Start();
        }

        private void Init()
        {
            connects = new ConnectionMaster();
            address = Dns.GetHostEntry("localhost").AddressList[0];
            listener = new TcpListener(address, PORT);
        }

        public void Listen()
        {
            listener.Start();
            while (true)
            {
                var client = listener.AcceptTcpClient();
                connects.AddSocket(client);
            }
        }


    }
}
