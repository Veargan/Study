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

namespace GameClient
{
    public class ClientManager
    {
        TcpClient client;
        public NetworkStream netStream;
        RoomsList roomsList;

        public ClientManager(){}

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
                string[] msg = output.Split(',');

                if (msg[0] == "list")
                {
                    roomsList.AddList(msg);
                    //roomsList.rm.AddAdmin(msg);
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

                    string path = @"D:\" + msg[1] + "." + mes[0] + ".txt";

                    using (StreamWriter file = File.AppendText(path))
                    {
                        file.Write(msg[2] + "~");
                        file.Flush();
                        file.Close();
                    }
                }

                if (msg[0] == "banned")
                {                    
                    MessageBox.Show("You have been banned! Action is not allowed!");
                }

                if (msg[0] == "bannot")
                {
                    MessageBox.Show("Your ban time is over!");
                }

            }
        }
    }
}
