using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer
{
    class Room
    {
        public string name;
        private string path;
        List<Client> clientList;
        List<Client> activeList;
        Queue<string> messages;

        public Room(string name)
        {
            this.name = name;
            activeList = new List<Client>();
            messages = new Queue<string>();
            clientList = new List<Client>();

            path = @"D:\" + name + ".txt";
            FileStream fs = File.Create(path);
            fs.Close();

            Thread threadSend = new Thread(Send);
            threadSend.Start();
        }

        public bool IsRoom(string name)
        {
            if (this.name == name)
                return true;
            return false;
        }

        public void AddClient(Client client)
        {
            activeList.Add(client);
            if (!clientList.Contains(client))
            {
                clientList.Add(client);
            }
            else
            {
                SendAllHistory(client);
            }
        }

        public void ExitClient(Client client)
        {
            activeList.Remove(client);
        }

        public void AddMessage(string message)
        {
            messages.Enqueue(message);
        }

        private void Send()
        {
            while (true)
            {
                if (messages.Count == 0)
                    continue;

                string message = messages.Dequeue();

                foreach (Client client in clientList)
                {
                    StreamWriter sw = new StreamWriter(client.user.GetStream());

                    if (activeList.Contains(client))
                    {
                        sw.WriteLine("message," + name + "," + message);
                    }
                    else
                    {
                        sw.WriteLine("notification," + name);
                    }
                    sw.Flush();
                }

                SaveMessage(message);
                Thread.Sleep(100);
            }
        }

        private void SaveMessage(string message)
        {
            using (StreamWriter file = File.AppendText(path))
            {
                file.Write(message + "~");
                file.Flush();
                file.Close();
            }
        }

        private void SendAllHistory(Client client)
        {
            string history = File.ReadAllText(path);
            StreamWriter send = new StreamWriter(client.user.GetStream());
            send.WriteLine("history," + name + "," + history);
            send.Flush();
        }
    }
}