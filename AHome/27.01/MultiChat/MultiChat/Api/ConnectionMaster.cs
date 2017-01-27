using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace MultiChat.Api
{
    public class ConnectionMaster
    {
        private List<TcpClient> connections { set; get; }
        private List<string> broadcastMessages { set; get; }
        private Thread threadListen;

        public ConnectionMaster()
        {
            connections = new List<TcpClient>();
            broadcastMessages = new List<string>();
            threadListen = new Thread(new ThreadStart(EternalKaif));
            threadListen.Start();
        }

        public void AddSocket(TcpClient socket)
        {
            connections.Add(socket);
            broadcastMessages.Add(String.Empty);
        }

        public void EternalKaif()
        {
            while (true)
            {
                if (connections.Count > 0)
                {
                    ReadFromStream();
                    WriteToStream();
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
                    broadcastMessages[i] = reader.ReadLine();
                }
            }
        }

        private void WriteToStream()
        {
            for (int i = 0;i < connections.Count; i++)
            {
                NetworkStream netStream = connections[i].GetStream();
                for (int j = 0; j < broadcastMessages.Count; j++)
                {
                    if (broadcastMessages[j] != String.Empty)
                    {
                        StreamWriter writer = new StreamWriter(netStream);
                        writer.WriteLine(broadcastMessages[j]);
                        writer.Flush();
                    }
                }
            }
            ClearBroadcast();
        }

        private void ClearBroadcast()
        {
            for (int i = 0; i < broadcastMessages.Count; i++)
            {
                broadcastMessages[i] = String.Empty;
            }
        }
    }
}
