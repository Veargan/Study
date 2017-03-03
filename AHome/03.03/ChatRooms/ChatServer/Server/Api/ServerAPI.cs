using Server.Api;
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
        private TcpListener serverListener;
        private Thread threadConnection;
        private ConnectionList connectionList;
        private DBManager db;
        private object locker;

        public ServerAPI()
        {
            locker = new object();
            connectionList = new ConnectionList(locker);
            serverListener = new TcpListener(IPAddress.Parse(/*"127.0.0.1"*//*"80.91.166.75"*/"127.0.0.1"), 1488);
            serverListener.Start();
            threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            threadConnection.Start();
            Console.WriteLine("Server started!");
            db = new DBManager();
        }

        private void ConnectionLoop()
        {
            Thread ThreadListen = new Thread(new ThreadStart(Receive));
            ThreadListen.Start();

            try
            {
                while (true)
                {
                    var connectedClient = serverListener.AcceptTcpClient();

                    while (!connectedClient.GetStream().DataAvailable) ;
                    Byte[] bytes = new Byte[connectedClient.Available];
                    connectedClient.GetStream().Read(bytes, 0, bytes.Length);
                    String ip = Encoding.UTF8.GetString(bytes);
                    string header = ip.ToLower();

                    if (new Regex("^get").IsMatch(header))
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
                        string[] input = inp1.Split('^');
                        Logging.LogToFile(input);
                        if (input[0] == "restore")
                        {
                            if (CheckEmail(input[2]) && db.SendPassword(input[1], input[2]))
                            {
                                Write("restoresuccess", 0, connectedClient);
                            }
                            else
                            {
                                Write("restorefail", 0, connectedClient);
                            }
                        }
                        else if (db.CreateNewLogin(input[0], input[1], input[3]))
                        {
                            Client cl = connectionList.clientList.Find(c => c.name == input[0]);
                            if (cl == null)
                                connectionList.AddClient(new Client(input[0], connectedClient, input[2], 0));
                            else
                                Write("alreadyinside", 0, connectedClient);
                        }
                        else if (input[3] == "auth")
                        {
                            Write("authfail", 0, connectedClient);
                        }
                        else if (input[3] == "reg")
                        {
                            Write("regfail", 0, connectedClient);
                        }
                        else if (input[3] == "authfb")
                        {
                            Write("authfailfb", 0, connectedClient);
                        }
                        else if (input[3] == "regfb")
                        {
                            Write("regfailfb", 0, connectedClient);
                        }
                        else if (input[3] == "authgl")
                        {
                            Write("authfailgl", 0, connectedClient);
                        }
                        else if (input[3] == "reggl")
                        {
                            Write("regfailgl", 0, connectedClient);
                        }
                    }
                    else
                    {
                        ip = ip.TrimEnd('\n');
                        ip = ip.TrimEnd('\r');
                        string[] input = ip.Split('^');
                        Logging.LogToFile(ip);
                        if (input[0] == "restore")
                        {
                            if (CheckEmail(input[2]) && db.SendPassword(input[1], input[2]))
                            {
                                Write("restoresuccess", 1, connectedClient);
                            }
                            else
                            {
                                Write("restorefail", 1, connectedClient);
                            }
                        }
                        else if (db.CreateNewLogin(input[0], input[1], input[3]))
                        {
                            Client cl = connectionList.clientList.Find(c => c.name == input[0]);
                            if (cl == null)
                                connectionList.AddClient(new Client(input[0], connectedClient, input[2], 1));
                            else
                                Write("alreadyinside", 1, connectedClient);
                        }
                        else if (input[3] == "auth")
                        {
                            Write("authfail", 1, connectedClient);
                        }
                        else
                        {
                            Write("regfail", 1, connectedClient);
                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                CrashReport.CrashReportToFile(ex.StackTrace + ex.Message, ex.InnerException?.ToString());
            }
        }

        private static String DecodeMessage(Byte[] bytes)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("METHOD: DecodeMessage" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        private void Receive()
        {
            try
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

                                Logging.LogToFile(message);

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

                                    case "changepass":
                                        if (db.ChangePassword(connectionList.clientList[i].name, input[1], input[2]))
                                        {
                                            connectionList.clientList[i].Write("changepasssuccess");
                                        }
                                        else
                                        {
                                            connectionList.clientList[i].Write("changepassfail");
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception ex)
            {
                CrashReport.CrashReportToFile(ex.StackTrace + ex.Message, ex.InnerException?.ToString());
            }
        }
        public void Write(string message, int type, TcpClient user)
        {
            try
            {
                if (type == 1)
                {
                    StreamWriter sw = new StreamWriter(user.GetStream());
                    sw.WriteLine(message);
                    sw.Flush();
                }
                else
                {
                    Byte[] response = Encoding.UTF8.GetBytes("  " + message);
                    response[0] = 0x81; // denotes this is the final message and it is in text
                    response[1] = Convert.ToByte(response.Length - 2); // payload size = message - header size
                    user.GetStream().Write(response, 0, response.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: Write" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        private bool CheckEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}