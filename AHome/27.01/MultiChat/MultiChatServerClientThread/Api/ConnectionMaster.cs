using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace MultiChatServerClientThread.Api
{
    public class ConnectionMaster
    {
        private List<TcpClient> connections { set; get; }
        private List<string> broadcastMessages { set; get; }
        private Timer timerListen;
        private Thread threadSay;
        private object lockSay = new object();

        public ConnectionMaster()
        {
            connections = new List<TcpClient>();
            broadcastMessages = new List<string>();
            timerListen = new Timer(new TimerCallback(EternalKaif), null, 0, 1000);
            threadSay = new Thread(new ThreadStart(WriteToStream));
            threadSay.Start();
        }

        public void AddSocket(TcpClient socket)
        {
            connections.Add(socket);
        }

        public void EternalKaif(object obj)
        {
            if (connections.Count > 0)
            {
                lock (lockSay)
                {
                    ReadFromStream();
                }
            }
        }

        private void ReadFromStream()
        {
            for (int i = 0; i < connections.Count; i++)
            {
                NetworkStream netStream = connections[i].GetStream();
                if (netStream.DataAvailable)
                {
                    StreamReader reader = new StreamReader(netStream);
                    broadcastMessages.Add(reader.ReadLine());
                }
            }
        }

        private void WriteToStream()
        {
            while (true)
            {
                lock (lockSay)
                {
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
