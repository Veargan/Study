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
        PlayersList playersList;
        GameXO gxo;

        public ClientManager()
        {
            
        }

        public void Connect(string name, PlayersList pl)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            client = new TcpClient();
            client.Connect(ipe);
            netStream = client.GetStream();
            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Start();
            SendLogin(name);
            this.playersList = pl;
            playersList.name = name;
            playersList.stream = netStream;
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
                    playersList.AddList(msg);
                }

                if (msg[0] == "invite")
                {
                    AskRequest ar = new AskRequest(msg[1], msg[2], msg[3], netStream);
                    Thread tr = new Thread(new ThreadStart(ar.ShowForm));
                    tr.Start();
                }

                if (msg[0] == "ask")
                {
                    if (msg[1] == "XO")
                    {
                        gxo = new GameXO(netStream, playersList.name);
                        Thread tr = new Thread(new ThreadStart(gxo.ShowForm));
                        tr.Start();
                    }
                }

                if (msg[0] == "gamexo")
                {
                    gxo.ReceiveGameData(output);
                }
            }
        }
    }
}
