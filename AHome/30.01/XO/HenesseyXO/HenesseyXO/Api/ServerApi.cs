using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using HenesseyXO.Authentification;
using HenesseyXO.Sessions;

namespace HenesseyXO.Api
{
    public class ServerApi
    {
        private const int PORT = 8888;
        private TcpListener serverListener;
        private Thread threadConnection;
        private ConnectionList connList;
        private RequestLoop requestLoop;
        private List<Session> sessions;

        public ServerApi()
        {
            serverListener = new TcpListener(IPAddress.Parse("127.0.0.1"), PORT);
            threadConnection = new Thread(new ThreadStart(ConnectionLoop));
            threadConnection.Start();
            connList = new ConnectionList(this);
            sessions = new List<Session>();
            requestLoop = new RequestLoop(this, connList, sessions);
        }

        private void ConnectionLoop()
        {
            serverListener.Start();
            while (true)
            {
               var clientSocket = serverListener.AcceptTcpClient();
                // add new user
                connList.AddUser(GetClient(clientSocket));
            }
        }

        private Client GetClient(TcpClient clientSocket)
        {
            StreamReader reader = new StreamReader(clientSocket.GetStream());
            string name = String.Empty;
            while (true)
            {
                if (clientSocket.GetStream().DataAvailable)
                {
                    name = reader.ReadLine();
                    break;
                }
            }
            return new Client(name, clientSocket);
        }
    }
}
