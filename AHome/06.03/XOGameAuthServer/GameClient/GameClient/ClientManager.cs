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
        PlayersList playersList;
        IGame game;     
      

        public ClientManager(){}

        public void Connect(PlayersList pl)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            client = new TcpClient();
            client.Connect(ipe);
            netStream = client.GetStream();
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("connect"); //просто нужно написать какую-то хуйню, чтоб он приконектился
            sw.Flush();
            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Start();
            this.playersList = pl;            
        }

        //void SendLogin(string name,string password,string status)
        //{
        //    StreamWriter sw = new StreamWriter(netStream);
        //    sw.WriteLine(name+","+password+ ","+"0"+","+status);
        //    sw.Flush();
        //}
        public void SendLogin(string name, string password, string status)
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine(status + "," + name + "," + password);
            sw.Flush();
            playersList.name = name;
            playersList.stream = netStream;
        }

        void ReceiveData()
        {
            while (true)
            {
                try
                {
                    string output = "";

                    StreamReader sr = new StreamReader(netStream);
                    output = sr.ReadLine();
                    string[] msg = output.Split(',');
                    switch (msg[0])
                    {
                        case "login":
                            if (msg[1] == "Y")
                            {
                                playersList.lb_name.Text = msg[2];
                            }
                            else
                            {                                
                                if (msg[3] == "1")
                                    MessageBox.Show("User with name \"" + msg[2] + "\" isn't registed yet!");

                                else
                                    MessageBox.Show("User with name \"" + msg[2] + "\" is already in the game!");
                            }
                            break;

                        case "reg":
                            if (msg[1] == "Y")
                            {
                                playersList.lb_name.Text = msg[2];
                            }
                            else
                            {
                                if (msg[3] == "1")
                                    MessageBox.Show(msg[2] + ",you are successfully registed!");                                
                                else
                                    MessageBox.Show("User with name \"" + msg[2] + "\" already excists!");                               
                            }
                            break;

                        case "list":
                            playersList.AddList(msg);
                            break;

                        case "invite":
                            AskRequest ar = new AskRequest(msg[2], msg[3], msg[1], netStream, playersList);
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

                        case "change":
                            if (msg[1] == "Y")
                                MessageBox.Show("Your password was successfully changed!");
                            else
                                MessageBox.Show("Failed to change your password. \n\rCheck whether login and old password are correct!");
                            break;
                        case "send":
                            if (msg[1] == "Y")
                                MessageBox.Show("Password was sent to your email.");
                            else
                                MessageBox.Show("Failed to send your password. \n\rCheck whether login is correct!");
                            break;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection to server is lost.");
                    Application.Restart();
                    break;
                }            
            }
        }

        internal void Restore(string login, string mail)
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("forgot," + login + "," + mail);
            sw.Flush();
        }

        internal void ChangePas(string login, string oldPas, string newPas)
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("change," + login + "," + oldPas + "," + newPas);
            sw.Flush();
        }

        internal void Logout()
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("logout");
            sw.Flush();
            client.Close();
        }
    }
}
