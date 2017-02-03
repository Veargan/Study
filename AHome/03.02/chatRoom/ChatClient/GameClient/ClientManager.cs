using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            }
        }
    }
}
