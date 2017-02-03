using HenesseyXO.Authentification;
using HenesseyXO.RealJope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using HenesseyXO.Api;

namespace HenesseyXO.Sessions
{
    public class Session : IDisposable
    {
        private Client player1;
        private Client player2;
        private IGame game;
        private Thread threadListener;

        public Session(GameType gameType)
        {
            game = GameCreator.CreateInstance(gameType);
            threadListener = new Thread(new ThreadStart(ListenLoop));
        }

        private void SendInitPackage()
        {
            var package = new TTTpacket(PlayerTurn.TURN, "X", 0, null, null);
            StreamWriter writer = new StreamWriter(player1.User.GetStream());
            writer.WriteLine(XmlPacketDecoder.Encode(package));
            writer.Flush();
            package = new TTTpacket(PlayerTurn.WAIT, "0", 0, null, null);
            writer = new StreamWriter(player2.User.GetStream());
            writer.WriteLine(XmlPacketDecoder.Encode(package));
            writer.Flush();
        }

        /*
        private void ListenLoop()
        {
            NetworkStream netStream1 = player1.User.GetStream();
            NetworkStream netStream2 = player2.User.GetStream();
            StreamReader reader1 = new StreamReader(netStream1);
            StreamReader reader2 = new StreamReader(netStream2);
            while (true)
            {
                string message = String.Empty;
                if (netStream1.DataAvailable)
                {
                    while (player1.User.Available > 1)
                    {
                        message += reader1.ReadLine();
                    }
                    var packet = XmlPacketDecoder.Decode(message);
                    PackageUsage(packet, netStream1, netStream2);
                }
                if (netStream2.DataAvailable)
                {
                    while (player2.User.Available > 1)
                    {
                        message += reader2.ReadLine();
                    }
                    var packet = XmlPacketDecoder.Decode(message);
                    PackageUsage(packet, netStream2, netStream1);
                }
            }
        }
         * */

        private void ListenLoop()
        {
            NetworkStream netStream1 = player1.User.GetStream();
            NetworkStream netStream2 = player2.User.GetStream();
            StreamReader reader1 = new StreamReader(netStream1);
            StreamReader reader2 = new StreamReader(netStream2);
            while (true)
            {
                if (netStream1.DataAvailable)
                {
                    string message = reader1.ReadLine();
                    PackageUsage(XmlPacketDecoder.Decode(message), netStream1, netStream2);
                }
                if (netStream2.DataAvailable)
                {
                    string message = reader2.ReadLine();
                    PackageUsage(XmlPacketDecoder.Decode(message), netStream2, netStream1);
                }
            }
        }

        private void PackageUsage(TTTpacket packet, NetworkStream net1, NetworkStream net2)
        {
            game.Turn(packet.ButtonNumber - 1, packet.Unit);
            if (game.IsGameOver())
            {
                packet.GameResult = game.Result;
            }
            packet.Matrix = game.GetMatrix();
            StreamWriter writer = new StreamWriter(net2);
            writer.WriteLine(XmlPacketDecoder.Encode(packet));
            writer.Flush();
            packet.Turn = ~packet.Turn;
            writer = new StreamWriter(net1);
            writer.WriteLine(XmlPacketDecoder.Encode(packet));
            writer.Flush();
        }

        public void AddPlayers(Client player1, Client player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            SendInitPackage();
            threadListener.Start();
        }

        public void Dispose()
        {
            this.player1.Dispose();
            this.player2.Dispose();
        }
    }
}
