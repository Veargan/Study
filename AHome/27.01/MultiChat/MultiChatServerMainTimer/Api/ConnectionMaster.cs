using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace MultiChatServerMainTimer.Api
{
    public class ConnectionMaster
    {
        private List<TcpClient> connections { set; get; }
        private List<string> broadcastMessages { set; get; }
        private List<Thread> threadClients { set; get; }
        private Thread threadSay;
        private object lockSay = new object();

        public ConnectionMaster()
        {
            connections = new List<TcpClient>();
            broadcastMessages = new List<string>();
            threadSay = new Thread(new ThreadStart(WriteToStream));
            threadSay.Start();
        }

        public void AddSocket(TcpClient socket)
        {
            connections.Add(socket);
            new Thread(new ParameterizedThreadStart(EternalKaif)).Start(socket);
        }

        public void EternalKaif(object socket)
        {
            while (true)
            {
                lock (lockSay)
                {
                    ReadFromStream(socket as TcpClient);
                }
            }
        }

        private void ReadFromStream(TcpClient client)
        {
            NetworkStream netStream = client.GetStream();
            if (netStream.DataAvailable)
            {
                StreamReader reader = new StreamReader(netStream);
                broadcastMessages.Add(reader.ReadLine());
            }
        }

        private void WriteToStream()
        {
            while (true)
            {
                lock (lockSay)
                {
                    if (broadcastMessages.Count == 0) continue;
                    for (int j = 0; j < broadcastMessages.Count; j++)
                    {
                        for (int i = 0; i < connections.Count; i++)
                        {
                            NetworkStream netStream = connections[i].GetStream();
                            StreamWriter writer = new StreamWriter(netStream);
                            writer.WriteLine(broadcastMessages[j]);
                            writer.Flush();
                        }
                    }
                    ClearBroadcast();
                }
            }
        }

        private void ClearBroadcast()
        {
            broadcastMessages.Clear();
        }
    }
}
