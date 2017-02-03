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
        public ServerAPI()
        {
            locker = new object();
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
                connectionList.AddClient(GetClient(connectedClient, input));
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
                            
                            if (input[0] == "new") // new,roomname
                            {
                                connectionList.AddRoom(new Room(input[1]));
                            }
                            
                            if(input[0] == "connect") //connect,roomname
                            {
                                foreach (var room in connectionList.roomList)
                                {
                                    if (room.IsRoom(input[1]))
                                    {
                                        room.AddClient(connectionList.clientList[i]);
                                        break;
                                    }
                                }
                            }
                            if (input[0] == "logout") //logout
                            {
                                connectionList.clientList.Remove(connectionList.clientList[i]);         
                            }   

                            if (input[0] == "exit") //exit,roomname
                            {
                                foreach (var room in connectionList.roomList)
                                {
                                    if (room.IsRoom(input[1]))
                                    {
                                        room.ExitClient(connectionList.clientList[i]);
                                        break;
                                    }
                                }
                            }

                            if (input[0] == "message") //message,roomname,context
                            {
                                foreach (var room in connectionList.roomList)
                                {
                                    if (room.IsRoom(input[1]))
                                    {
                                        room.AddMessage(connectionList.clientList[i].name + ": " + input[2]);
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
