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
        private NetworkStream netStream;
        public RoomsList roomsList;
        public LoginForm lf;

        public ClientManager() {}

        public void Connect(string name, string pass, LoginForm lf, string cmd)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1488);
            client = new TcpClient();
            client.Connect(ipe);
            netStream = client.GetStream();
            SendLoginInfo(name, pass, cmd);
            this.lf = lf;
            Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Start();
        }

        private void SendLoginInfo(string name, string pass, string cmd)
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine(name + "^" + pass + "^0^" + cmd);
            sw.Flush();
        }

        public void Send(string message)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            client = new TcpClient();
            client.Connect(ipe);
            netStream = client.GetStream();
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine(message);
            sw.Flush();
            Thread receiveThread = new Thread(new ThreadStart(RestorePass));
            receiveThread.Start();
        }

        public NetworkStream get_netStream()
        {
            return netStream;
        }

        public void ChangePassword(string login, string oldPas, string newPas)
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine("change," + login + "," + oldPas + "," + newPas);
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
                        Thread thread = new Thread(lf.rl.Show);
                        thread.Start();
                        lf.Hide();
                        break;

                    case "authfail":
                        MessageBox.Show("Invalid login or password");
                        lf.rl.Hide();
                        break;

                    case "regfail":
                        MessageBox.Show("This username already exists. Choose another name!");
                        lf.rl.Hide();
                        break;

                    case "authfailfb":
                        MessageBox.Show("Invalid login or password");
                        lf.rl.Hide();
                        break;

                    case "regfailfb":
                        MessageBox.Show("This username already exists. Choose another name!");
                        lf.rl.Hide();
                        break;

                    case "authfailgl":
                        MessageBox.Show("Invalid login or password");
                        lf.rl.Hide();
                        break;

                    case "regfailgl":
                        MessageBox.Show("This username already exists. Choose another name!");
                        lf.rl.Hide();
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
        private void RestorePass()
        {
            while (true)
            {
                string output = "";

                StreamReader sr = new StreamReader(netStream);
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

        public void SendChangePass(string message)
        {
            StreamWriter sw = new StreamWriter(netStream);
            sw.WriteLine(message);
            sw.Flush();
        }
    }
}