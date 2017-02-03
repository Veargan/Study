using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using XOClient.Api;

namespace XOClient.Sessions
{
    public class Session
    {
        private TcpClient client;
        
        private Thread threadListen;
        private StreamWriter writer;
        public event EventHandler Init;
        public event EventHandler TurnOccur;

        public Session(TcpClient client, EventHandler initHandler, EventHandler turnHandler)
        {
            Init += initHandler;
            TurnOccur += turnHandler;
            this.client = client;
            writer = new StreamWriter(client.GetStream());
            threadListen = new Thread(new ThreadStart(ListenLoop));
            threadListen.Start();
        }

        private void ListenLoop()
        {
            NetworkStream netStream = client.GetStream();
            StreamReader reader = new StreamReader(netStream);
            
            string xmlStr = String.Empty;
            while (true)
            {
                if (netStream.DataAvailable)
                {
                    xmlStr = reader.ReadLine();
                    break;
                }
            }
            var packet = XmlPacketDecoder.Decode(xmlStr);
            Init(packet, null);

            while (true)
            {
                if (netStream.DataAvailable)
                {
                    xmlStr = reader.ReadLine();
                    packet = XmlPacketDecoder.Decode(xmlStr);
                    TurnOccur(packet, null);
                }
            }
        }
         
        public void Send(TTTpacket packet)
        {
            string packetStr = XmlPacketDecoder.Encode(packet);
            writer.WriteLine(packetStr);
            writer.Flush();
        }

    }
}
