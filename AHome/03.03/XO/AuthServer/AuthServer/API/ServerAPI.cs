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

namespace AuthServer
{
    public class ServerAPI
    {
        private TcpListener _serverListener;
        private Thread _threadConnection;
        private DBmanager _db;
        private object _locker;

        public ServerAPI()
        {
            _locker = new object();
            _serverListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            _serverListener.Start();
            _threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            _threadConnection.Start();
            Console.WriteLine("Server started");
            _db = new DBmanager();
        }

        private void ConnectionLoop()
        {
            try
            {
                while (true)
                {
                    var connectedClient = _serverListener.AcceptTcpClient();

                    while (!connectedClient.GetStream().DataAvailable) ;
                    Byte[] bytes = new Byte[connectedClient.Available];
                    connectedClient.GetStream().Read(bytes, 0, bytes.Length);
                    String ip = Encoding.UTF8.GetString(bytes);
                    string header = ip.ToLower();

                    if (new Regex("^get").IsMatch(header))
                    {

                        #region trashWEB
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
                        String ip1 = DecodeMessage(bytes1);


                        string[] input = ip1.Split('^');
                        Logging.LogToFile(input);
                        if (input[0] == "restore")
                        {
                            if (_db.SendPassword(input[1], input[2]))
                            {
                                Write("restoresuccess", 0, connectedClient);
                            }
                            else
                            {
                                Write("restorefail", 0, connectedClient);
                            }
                        }
                        else if (input[0] == "changepass")
                        {
                            if (_db.ChangePassword(input[1], input[2], input[3]))
                            {
                                Write("changepasssuccess", 0, connectedClient);
                            }
                            else
                            {
                                Write("changepassfail", 0, connectedClient);
                            }
                            break;
                        }
                        else if (_db.CreateNewLogin(input[0], input[1], input[3]))
                        {
                            Write("authsucc ^ " + input[0], 0, connectedClient);
                        }
                        else if (input[3] == "auth")
                        {
                            Write("authfail", 0, connectedClient);
                        }
                        else
                        {
                            Write("regfail", 0, connectedClient);
                        }
                    }
                    #endregion
                    else
                    {
                        ip = ip.TrimEnd('\n');
                        ip = ip.TrimEnd('\r');
                        string[] input = ip.Split('^');
                        Logging.LogToFile(ip);
                        if (input[0] == "restore")
                        {
                            if (_db.SendPassword(input[1], input[2]))
                            {
                                Write("restoresuccess", 1, connectedClient);
                            }
                            else
                            {
                                Write("restorefail", 1, connectedClient);
                            }
                        }
                        else if (input[0] == "changepass")
                        {
                            if (_db.ChangePassword(input[1], input[2], input[3]))
                            {
                                Write("changepasssuccess", 1, connectedClient);
                            }
                            else
                            {
                                Write("changepassfail", 1, connectedClient);
                            }
                            break;
                        }
                        else if (_db.CreateNewLogin(input[0], input[1], input[3]))
                        {
                            Write("authsucc^" + input[0], 1, connectedClient);
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

        private void Write(string message, int type, TcpClient user)
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

        private string DecodeMessage(byte[] bytes)
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
    }
}
