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
    public class ServerAPI
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
            serverListener.Start();
            threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            threadConnection.Start();
            Console.WriteLine("Server started!");
        }

        private void ConnectionLoop()
        {
            Thread ThreadListen = new Thread(new ThreadStart(Receive));
            ThreadListen.Start();

            while (true)
            {
                var connectedClient = serverListener.AcceptTcpClient();
                StreamReader sr = new StreamReader(connectedClient.GetStream());
                string input = sr.ReadLine();
                foreach (var client in connectionList.clientList)
                {
                    if (input == client.name)
                    {
                        client.Write("login");
                        break;
                    }
                }
                connectionList.AddClient(new Client(input, connectedClient));
                Thread.Sleep(1000);
            }
        }

        private void Receive()
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
                            string[] input = message.Split('^');

                            if (input[0] == "new") // new^roomname
                            {
                                if (connectionList.clientList[i].isBanned)
                                {
                                    connectionList.clientList[i].Write("banned");
                                    break;
                                }

                                connectionList.AddRoom(new Room(input[1]));
                            }

                            if (input[0] == "connect") //connect^roomname
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
                                break;
                            }

                            if (input[0] == "exit") //exit^roomname
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

                            if (input[0] == "unsubscribe") //unsubscribe^roomname
                            {
                                foreach (var room in connectionList.roomList)
                                {
                                    if (room.IsRoom(input[1]))
                                    {
                                        room.UnsubscribeClient(connectionList.clientList[i]);
                                        break;
                                    }
                                }
                            }

                            if (input[0] == "message") //message^roomname^context
                            {
                                if (connectionList.clientList[i].isBanned)
                                {
                                    connectionList.clientList[i].Write("banned");
                                    break;
                                }

                                foreach (var room in connectionList.roomList)
                                {
                                    if (room.IsRoom(input[1]))
                                    {
                                        room.AddMessage(connectionList.clientList[i].name + ": " + input[2]);
                                        break;
                                    }
                                }
                            }

                            if (input[0] == "ban") //ban^ban time^name
                            {
                                foreach (var client in connectionList.clientList)
                                {
                                    if (client.name == (input[2]))
                                    {
                                        if (input[1] == "")
                                        {
                                            client.isBanned = true;
                                            break;
                                        }

                                        client.SetBan(Convert.ToInt32(input[1]));
                                        break;
                                    }
                                }

                            }

                            if (input[0] == "unban") //unban^name
                            {
                                foreach (var client in connectionList.clientList)
                                {
                                    if (client.name == (input[1]))
                                    {
                                        client.isBanned = false;
                                        break;
                                    }
                                }
                            }

                            if (input[0] == "pmessage") //pmessage^whom^context
                            {
                                foreach (var client in connectionList.clientList)
                                {
                                    if (input[1] == client.name)
                                    {
                                        client.Write("pmessage^" + client.name + "^" + connectionList.clientList[i].name + ": " + input[2]);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}