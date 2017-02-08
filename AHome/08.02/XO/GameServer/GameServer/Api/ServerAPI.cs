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
        int port;
        Thread threadConnection;
        ConnectionList connectionList;
        private object locker;
        List<Room> rooms;
        public ServerAPI()
        {
            locker = new object();
            rooms = new List<Room>();
            connectionList = new ConnectionList(locker);
            port = 8888;
            serverListener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            threadConnection.Start();
            Console.WriteLine("Server started!");
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
                connectionList.AddList(GetClient(connectedClient, input));
            }
        }

        private Client GetClient(TcpClient clientSocket, string name)
        {
            return new Client(name, clientSocket);
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
                            string[] input = message.Split(',');
                            
                            if (input[0] == "invite")
                            {
                                Room room = new Room(this.connectionList, input[1], input[2], input[3]);
                                rooms.Add(room);
                                room.SendInvite();
                            }
                            
                            if(input[0] == "ask")
                            {
                                Room room = null;
                                foreach (var item in rooms)
                                {
                                    if (item.IsRoom(input[3]))
                                    {
                                        room = item;
                                        room.AskRequest(input[1]);
                                        break;
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }
        }

    }
}
