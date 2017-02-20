using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Room
    {
        public string name { get; set; }
        private string fileName;
        private string path;
        private string folderName;
        private List<Client> clientList;
        private List<Client> activeList;
        private Queue<string> messages;

        public Room(string name)
        {
            this.name = name;
            activeList = new List<Client>();
            messages = new Queue<string>();
            clientList = new List<Client>();
            CreateFileSystem(name);

            Thread threadSend = new Thread(Send);
            threadSend.Start();
        }

        private void CreateFileSystem(string name)
        {
            folderName = @"C:\Debug";
            path = Path.Combine(folderName, "Files");
            fileName = name + ".txt";
            Directory.CreateDirectory(path);
            path = Path.Combine(path, fileName);
            FileStream fs = File.Create(path);
            fs.Close();
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
                if (client.name == "admin")
                    activeList.Remove(client);
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

        public void UnsubscribeClient(Client client)
        {
            clientList.Remove(client);
        }

        public void AddMessage(string message)
        {
            messages.Enqueue(message);
        }

        public void Send()
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
                        sw.WriteLine("message^" + name + "^" + message);
                    }
                    else
                    {
                        sw.WriteLine("notification^" + name);
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
            send.WriteLine("history^" + name + "^" + history);
            send.Flush();
        }
    }
}