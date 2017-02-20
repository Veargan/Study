using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer
{
    class ServerAPI
    {
        TcpListener serverListener;
        Thread threadConnection;
        ConnectionList connectionList;
        CommandManager commandManager;
        private object locker;
        List<InviteManager> rooms;
        public ServerAPI()
        {
            locker = new object();
            rooms = new List<InviteManager>();
            connectionList = new ConnectionList();
            serverListener = new TcpListener(IPAddress.Parse("192.168.1.69"), 1488);
            threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            threadConnection.Start();
            Console.WriteLine("Server started!");
            commandManager = new CommandManager(connectionList);
        }

        private void ConnectionLoop()
        {
            serverListener.Start();
            Thread ThreadListen = new Thread(new ThreadStart(Receive));
            ThreadListen.Start();
            while (true)
            {
                var connectedClient = serverListener.AcceptTcpClient();
                StreamReader sr = new StreamReader(connectedClient.GetStream());
                string input = sr.ReadLine();
                connectionList.AddList(new Client(input, connectedClient));
            }
        }

        public void Receive()
        {
            while (true)
            {
                if (connectionList.clientList.Count == 0)
                    continue;
                lock (locker)
                {
                    for (int i = 0; i < connectionList.clientList.Count; i++)
                    {
                        if (connectionList.clientList[i].user.GetStream().DataAvailable)
                        {
                            string message = connectionList.clientList[i].Read();
                            commandManager.Dispatcher(message);
                        }
                    }
                }
            }
        }
    }
}