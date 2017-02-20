using System;
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
        public NetworkStream netStream;
        private RoomsList roomsList;

        public ClientManager() { }

        public void Connect(string name)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("100.67.0.17"), 1488);
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


                if (msg[0] == "list")
                {
                    roomsList.AddList(msg);
                }

                if (msg[0] == "message")
                {
                    roomsList.rm.NewMessage(msg[1], msg[2]);
                }

                if (msg[0] == "notification")
                {
                    roomsList.rm.NewNotification(msg[1]);
                    roomsList.NewNotification(msg[1]);
                }

                if (msg[0] == "history")
                {
                    roomsList.rm.SetHistory(msg[1], msg[2]);   
                }

                if (msg[0] == "clientlist")
                {
                    roomsList.AddClient(msg);
                }

                if (msg[0] == "pmessage")
                {
                    string[] mes = msg[2].Split(':');
                    MessageBox.Show(mes[1], "New private message from " + mes[0]);

                    string path = @"C:\Debug\Files\" + msg[1] + "." + mes[0] + ".txt";

                    using (StreamWriter file = File.AppendText(path))
                    {
                        file.Write(msg[2] + "~");
                        file.Flush();
                        file.Close();
                    }
                }

                if (msg[0] == "success")
                {
                    //roomsList = new RoomsList(msg[1], netStream);
                    //roomsList.Invoke(new Action(() => { roomsList.Show(); }));
                }

                if (msg[0] == "fail")
                {
                    roomsList.Invoke(new Action(() => { roomsList.Close(); }));
                    //roomsList.Hide();
                    //client.Close();
                    //netStream.Close();
                    MessageBox.Show("This username already exists. Choose another name!");
                    //LoginForm lf = new LoginForm();
                    //break;
                   
                }

                if (msg[0] == "banstill")
                {                    
                    MessageBox.Show("You have been banned! Action is not allowed!");
                }

                if (msg[0] == "banover")
                {
                    MessageBox.Show("Your ban time is over!");
                }

                if (msg[0] == "ban")
                {
                    MessageBox.Show("You have been banned " + msg[1]);
                }

                if (msg[0] == "unban")
                {
                    MessageBox.Show("You have been unbanned!");
                }
                Thread.Sleep(100);
            }
        }
    }
}
