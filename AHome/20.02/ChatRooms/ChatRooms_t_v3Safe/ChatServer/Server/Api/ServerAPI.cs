using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerAPI
    {
        private TcpListener serverListener;
        private Thread threadConnection;
        private ConnectionList connectionList;
        private object locker;

        public ServerAPI()
        {
            locker = new object();
            connectionList = new ConnectionList(locker);
            serverListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
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
                        client.Write("fail");
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

                            switch (input[0])
                            {
                                case "new": // new^roomname
                                    if (connectionList.clientList[i].isBanned)
                                    {
                                        connectionList.clientList[i].Write("banstill");
                                        break;
                                    }
                                    connectionList.AddRoom(new Room(input[1]));
                                    break;

                                case "connect": //connect^roomname
                                    foreach (var room in connectionList.roomList)
                                    {
                                        if (room.IsRoom(input[1]))
                                        {
                                            room.AddClient(connectionList.clientList[i]);
                                            break;
                                        }
                                    }
                                    break;

                                case "logout": //logout
                                    connectionList.clientList.Remove(connectionList.clientList[i]);
                                    connectionList.BroadcastSend();
                                    break;

                                case "exit": //exit^roomname
                                    foreach (var room in connectionList.roomList)
                                    {
                                        if (room.IsRoom(input[1]))
                                        {
                                            room.ExitClient(connectionList.clientList[i]);
                                            break;
                                        }
                                    }
                                    break;

                                case "unsubscribe": //unsubscribe^roomname
                                    foreach (var room in connectionList.roomList)
                                    {
                                        if (room.IsRoom(input[1]))
                                        {
                                            room.UnsubscribeClient(connectionList.clientList[i]);
                                            break;
                                        }
                                    }
                                    break;

                                case "message": //message^roomname^context
                                    if (connectionList.clientList[i].isBanned)
                                    {
                                        connectionList.clientList[i].Write("banstill");
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
                                    break;

                                case "ban": //ban^ban time^name
                                    foreach (var client in connectionList.clientList)
                                    {
                                        if (client.name == input[2])
                                        {
                                            if (input[1] == "")
                                            {
                                                client.isBanned = true;
                                                client.Write("ban^" + "");
                                                break;
                                            }
                                            client.Write("ban^" + "for " + input[1] + " minutes");
                                            client.SetBan(Convert.ToInt32(input[1]));
                                            break;
                                        }
                                    }
                                    break;

                                case "unban": //unban^name
                                    foreach (var client in connectionList.clientList)
                                    {
                                        if (client.name == input[1])
                                        {
                                            client.isBanned = false;
                                            client.Write("unban");
                                            break;
                                        }
                                    }
                                    break;

                                case "pmessage": //pmessage^whom^context
                                    foreach (var client in connectionList.clientList)
                                    {
                                        if (client.name == input[1])
                                        {
                                            client.Write("pmessage^" + client.name + "^" + connectionList.clientList[i].name + ": " + input[2]);
                                            break;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}