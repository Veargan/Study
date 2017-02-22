using Server.Authentication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerAPI
    {
        TcpListener serverListener;
        Thread threadConnection;
        ConnectionList connectionList;
        DataBase db;
        object locker;

        public ServerAPI()
        {
            locker = new object();
            connectionList = new ConnectionList(locker);
            serverListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
            serverListener.Start();
            threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            threadConnection.Start();
            Console.WriteLine("Server started!");
            db = new DataBase();
        }

        private void ConnectionLoop()
        {
            Thread ThreadListen = new Thread(new ThreadStart(Receive));
            ThreadListen.Start();

            while (true)
            {
                var connectedClient = serverListener.AcceptTcpClient();

                while (!connectedClient.GetStream().DataAvailable) ;
                Byte[] bytes = new Byte[connectedClient.Available];
                connectedClient.GetStream().Read(bytes, 0, bytes.Length);
                String ip = Encoding.UTF8.GetString(bytes);

                if (new Regex("^Get").IsMatch(ip))
                {
                    Byte[] response = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols" + Environment.NewLine
                                                            + "Connection: Upgrade" + Environment.NewLine
                                                            + "Upgrade: websocket" + Environment.NewLine
                                                            + "Sec-WebSocket-Accept: " + Convert.ToBase64String(
                                                                SHA1.Create().ComputeHash(
                                                                    Encoding.UTF8.GetBytes(
                                                                        new Regex("Sec-WebSocket-Key: (.*)").Match(ip).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
                                                                    )
                                                                )
                                                            ) + Environment.NewLine
                                                            + Environment.NewLine);
                
                connectedClient.GetStream().Write(response, 0, response.Length);
                while (!connectedClient.GetStream().DataAvailable) ;
                Byte[] bytes1 = new Byte[connectedClient.Available];
                connectedClient.GetStream().Read(bytes1, 0, bytes1.Length);
                String inp1 = DecodeMessage(bytes1);
                string[] input = inp1.Split(',');
                if (db.CreateNewLogin(input[0], input[1], input[3]))
                {
                    Client cl = connectionList.clientList.Find(c => c.name == input[0]);
                    if (cl == null)
                        connectionList.AddClient(new Client(input[0], connectedClient, input[2], 0));
                }
            }
                else
                {
                ip = ip.TrimEnd('\n');
                ip = ip.TrimEnd('\r');
                string[] input = ip.Split(',');
                if (db.CreateNewLogin(input[0], input[1], input[3]))
                {
                    Client cl = connectionList.clientList.Find(c => c.name == input[0]);
                    if (cl == null)
                        connectionList.AddClient(new Client(input[0], connectedClient, input[2], 1));
                }
            }

        }
    }
        private static String DecodeMessage(Byte[] bytes)
        {
            String incomingData = String.Empty;
            Byte secondByte = bytes[1];
            Int32 dataLength = secondByte & 127;
            Int32 indexFirstMask = 2;
            if (dataLength == 126)
                indexFirstMask = 4;
            else if (dataLength == 127)
                indexFirstMask = 10;

            IEnumerable<Byte> keys = bytes.Skip(indexFirstMask).Take(4);
            Int32 indexFirstDataByte = indexFirstMask + 4;

            Byte[] decoded = new Byte[bytes.Length - indexFirstDataByte];
            for (Int32 i = indexFirstDataByte, j = 0; i < bytes.Length; i++, j++)
            {
                decoded[j] = (Byte)(bytes[i] ^ keys.ElementAt(j % 4));
            }

            return incomingData = Encoding.UTF8.GetString(decoded, 0, decoded.Length);
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