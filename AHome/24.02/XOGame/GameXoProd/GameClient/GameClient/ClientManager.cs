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
        IGame game;
        
      

        public ClientManager(){}

        public void Connect(string name,string password, PlayersList pl,string status)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);   
            client = new TcpClient();
            client.Connect(ipe);
            netStream = client.GetStream();
            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Start();
           
            SendLogin(name,password,status);
           
            this.playersList = pl;
            playersList.name = name;
            playersList.stream = netStream;
        }

        void SendLogin(string name,string password,string status)
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine(name+","+password+ ","+"0"+","+status);
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
                switch(msg[0])
                {
                    case "name":
                      
                        playersList.lb_name.Text = msg[1];
                        break;
                    case "list":
                        playersList.AddList(msg);
                        break;
                    case "invite":
                        
                        
                            AskRequest ar = new AskRequest(msg[1], msg[2], msg[3], netStream, playersList);
                            Thread tr = new Thread(new ThreadStart(ar.ShowForm));
                            tr.Start();
                           
                       
                        
                      
                        break;
                    case "ask":
                        if (msg[1] == "XO")
                        {
                            game = new GameXO(netStream, playersList.name);
                            
                            Thread tr1 = new Thread(new ThreadStart(game.ShowForm));
                            tr1.Start();
                        }
                        break;
                    case "gamexo":
                        game.ReceiveGameData(output);
                   
                        break;
                    

                }               
            }
        }
    }
}
