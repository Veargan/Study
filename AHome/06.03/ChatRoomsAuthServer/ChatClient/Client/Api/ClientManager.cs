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
        private NetworkStream netStreamAuth;
        private NetworkStream netStream;
        public RoomsList roomsList;
        public LoginForm lf;

        public ClientManager() {}


        internal void ConnectAuth(string name, string pass, LoginForm lf, string cmd)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            client = new TcpClient();
            client.Connect(ipe);
            netStreamAuth = client.GetStream();
            SendLoginInfo(name, pass, cmd);
            Thread.Sleep(1000);
            this.lf = lf;
            Thread receiveThread = new Thread(new ThreadStart(ReceiveAuthData));
            receiveThread.Start();
        }
        private void SendLoginInfo(string name, string pass, string cmd)
        {
            StreamWriter sw = new StreamWriter(netStreamAuth);
            sw.WriteLine(name + "^" + pass + "^0^" + cmd);
            sw.Flush();
        }

        public void SendChangePass(string message)
        {
            StreamWriter sw = new StreamWriter(netStreamAuth);
            sw.WriteLine(message);
            sw.Flush();
        }

        private void ReceiveAuthData()
        {
            while (true)
            {
                string output = "";

                StreamReader sr = new StreamReader(netStreamAuth);
                output = sr.ReadLine();
                string[] msg = output.Split('^');

                switch (msg[0])
                {
                    case "authsucc":
                        Connect(msg[1]);
                        break;
                    case "authfail":
                        MessageBox.Show("Invalid login or password");
                        lf.rl.Hide();
                        break;

                    case "regfail":
                        MessageBox.Show("This username already exists. Choose another name!");
                        lf.rl.Hide();
                        break;

                    case "changepasssuccess":
                        MessageBox.Show("With God help. Password has been successfully changed");
                        break;

                    case "changepassfail":
                        MessageBox.Show("Unfortunately. You are dumb ass shit");
                        break;
                }
                Thread.Sleep(100);
            }
        }



        public void SendRestore(string message)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            client = new TcpClient();
            client.Connect(ipe);
            netStreamAuth = client.GetStream();
            StreamWriter sw = new StreamWriter(netStreamAuth);
            sw.WriteLine(message);
            sw.Flush();
            Thread receiveThread = new Thread(new ThreadStart(ReceiveRestorePass));
            receiveThread.Start();
        }
        private void ReceiveRestorePass()
        {
            while (true)
            {
                string output = "";

                StreamReader sr = new StreamReader(netStreamAuth);
                output = sr.ReadLine();
                string[] msg = output.Split('^');

                switch (msg[0])
                {
                    case "restoresuccess":
                        MessageBox.Show("Password was sent to your email");
                        return;

                    case "restorefail":
                        MessageBox.Show("Invalid data");
                        return;
                }
                Thread.Sleep(100);
            }
        }


        public void Connect(string name)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            client = new TcpClient();
            client.Connect(ipe);
            netStream = client.GetStream();

            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine(name);
            sw.Flush();

            //this.lf = lf;
            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Start();
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
                        Thread thread = new Thread(lf.rl.Show);
                        thread.Start();
                        lf.Hide();
                        break;

                    case "alreadyinside":
                        MessageBox.Show("This user already in the chat. Don't distract him!");
                        lf.rl.Hide();
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



        public NetworkStream get_netStream()
        {
            return netStream;
        }

    }
}