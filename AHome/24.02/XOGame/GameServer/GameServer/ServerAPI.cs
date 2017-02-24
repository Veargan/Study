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

namespace GameServer
{
    class ServerAPI
    {
        TcpListener serverListener;
        ConnectionList connectionList;
        CommandManager commandManager;
        DataBaseManager dbmanager;
        public ServerAPI()
        {
            connectionList = new ConnectionList();
            int port = 8888;
            serverListener = new TcpListener(IPAddress.Any, port);
            Thread threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            threadConnection.Start();
            Console.WriteLine("Server started!");
            dbmanager = new DataBaseManager();
            commandManager = new CommandManager(connectionList, dbmanager);            
        }

        private void ConnectionLoop()
        {
            serverListener.Start();
            Thread ThreadListen = new Thread(new ThreadStart(Receive));
            ThreadListen.Start();
            while (true)
            {
                var connectedClient = serverListener.AcceptTcpClient();

                while (!connectedClient.GetStream().DataAvailable) ;

                Byte[] bytes = new Byte[connectedClient.Available];

                connectedClient.GetStream().Read(bytes, 0, bytes.Length);

                String inp = Encoding.UTF8.GetString(bytes);

                if (new Regex("^GET").IsMatch(inp))
                {
                    Byte[] response = Encoding.UTF8.GetBytes("HTTP/1.1 101 Switching Protocols" + Environment.NewLine
                        + "Connection: Upgrade" + Environment.NewLine
                        + "Upgrade: websocket" + Environment.NewLine
                        + "Sec-WebSocket-Accept: " + Convert.ToBase64String(
                            SHA1.Create().ComputeHash(
                                Encoding.UTF8.GetBytes(
                                    new Regex("Sec-WebSocket-Key: (.*)").Match(inp).Groups[1].Value.Trim() + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"
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
                    if (dbmanager.CreateNewLogin(input[0], input[1], input[3]))
                    {
                        Client cl = connectionList.clientList.Find(c => c.name == input[0]);
                        if (cl == null)
                            connectionList.AddList(new Client(input[0], connectedClient, input[2], 0));
                    }
                }
                else
                {
                    inp = inp.TrimEnd('\n');
                    inp = inp.TrimEnd('\r');
                    string[] input = inp.Split(',');
                    if (dbmanager.CreateNewLogin(input[0], input[1], input[3]))
                    {
                        Client cl = connectionList.clientList.Find(c => c.name == input[0]);
                        if (cl == null)
                            connectionList.AddList(new Client(input[0], connectedClient, input[2], 1));
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

        public void Receive()
        {
            while (true)
            {
                if (connectionList.clientList.Count == 0)
                    continue;
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