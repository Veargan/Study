using Server.Api;
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
            try
            {
                folderName = @"C:\Debug";
                path = Path.Combine(folderName, "Files");
                fileName = name + ".txt";
                Directory.CreateDirectory(path);
                path = Path.Combine(path, fileName);
                FileStream fs = File.Create(path);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: CreateFileSystem" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }
    

        public bool IsRoom(string name)
        {
            try
            {
                if (this.name == name)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: IsRoom" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void AddClient(Client client)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("METHOD: AddClient" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void ExitClient(Client client)
        {
            try
            {
                activeList.Remove(client);
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: ExitClient" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void UnsubscribeClient(Client client)
        {
            try
            {
                clientList.Remove(client);
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: UnsubscribeClient" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void AddMessage(string message)
        {
            try
            {
                messages.Enqueue(message);
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: AddMessage" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        public void Send()
        {
            try
            {
                while (true)
                {
                    if (messages.Count == 0)
                        continue;
                    
                    string message = messages.Dequeue();

                    foreach (Client client in clientList)
                    {
                        if (activeList.Contains(client))
                        {
                            client.Write("message^" + name + "^" + message);
                        }
                        else
                        {
                            client.Write("notification^" + name);
                        }
                    }

                    SaveMessage(message);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                CrashReport.CrashReportToFile(ex.StackTrace + ex.Message, ex.InnerException?.ToString());
            }
        }

        private void SaveMessage(string message)
        {
            try
            {
                using (StreamWriter file = File.AppendText(path))
                {
                    file.Write(message + "~");
                    file.Flush();
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: SaveMessage" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }

        private void SendAllHistory(Client client)
        {
            try
            {
                string history = File.ReadAllText(path);
                client.Write("history^" + name + "^" + history);
            }
            catch (Exception ex)
            {
                throw new Exception("METHOD: SendAllHistory" + ex.StackTrace + ex.Message, ex.InnerException);
            }
        }
    }
}