﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class ClientManager
    {
        private TcpClient client;
        private NetworkStream netStream;
        private RoomsList roomsList;

        public ClientManager() { }

        public void Connect(string name)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            client = new TcpClient();
            client.Connect(ipe);
            netStream = client.GetStream();
            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Start();
            roomsList = new RoomsList(name, netStream);
            SendLogin(name);
        }

        void SendLogin(string name)
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine(name);
            sw.Flush();
        }

        void ReceiveData()
        {
            while (true)
            {
                string output = "";

                StreamReader sr = new StreamReader(netStream);
                output = sr.ReadLine();
                string[] msg = output.Split('^');

                switch (msg[0])
                {
                    case "list":
                        roomsList.AddList(msg);
                        break;

                    case "clientlist":
                        roomsList.AddClient(msg);
                        break;

                    case "message":
                        roomsList.rm.NewMessage(msg[1], msg[2]);
                        break;

                    case "pmessage":
                        string[] mes = msg[2].Split(':');
                        MessageBox.Show(mes[1], "New private message from " + mes[0]);

                        string path = @"C:\Debug\Files\" + msg[1] + "." + mes[0] + ".txt";

                        using (StreamWriter file = File.AppendText(path))
                        {
                            file.Write(msg[2] + "~");
                            file.Flush();
                            file.Close();
                        }
                        break;

                    case "notification":
                        roomsList.rm.NewNotification(msg[1]);
                        roomsList.NewNotification(msg[1]);
                        break;

                    case "history":
                        roomsList.rm.SetHistory(msg[1], msg[2]);
                        break;

                    case "success":
                        break;

                    case "fail":
                        var close = new Action(() => { roomsList.Close(); });
                        if (roomsList.InvokeRequired)
                        {
                            roomsList.Invoke(close);
                        } 
                        else
                        {
                            close();
                        }
                        MessageBox.Show("This username already exists. Choose another name!");
                        break;

                    case "banstill":
                        MessageBox.Show("You have been banned! Action is not allowed!");
                        break;

                    case "banover":
                        MessageBox.Show("Your ban time is over!");
                        break;

                    case "ban":
                        MessageBox.Show("You have been banned " + msg[1]);
                        break;

                    case "unban":
                        MessageBox.Show("You have been unbanned!");
                        break;
                }
                Thread.Sleep(100);
            }
        }
    }
}