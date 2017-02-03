using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HenesseyXO.Authentification;
using System.IO;
using HenesseyXO.Sessions;

namespace HenesseyXO.Api
{
    public class RequestLoop
    {
        private Thread threadListen;
        private Object locker;
        private ConnectionList connList;
        private RequestPool requestPool;
        private List<Session> sessions;

        public RequestLoop(Object locker, ConnectionList connList, List<Session> sessions)
        {
            this.locker = locker;
            this.connList = connList;
            this.sessions = sessions;
            this.requestPool = new RequestPool();
            threadListen = new Thread(new ThreadStart(ListenLoop));
            threadListen.Start();
        }

        private void ListenLoop()
        {
            while (true)
            {
                if (connList.IsEmpty()) continue;
                lock (locker)
                {
                    GetRequest();
                }
            }
        }

        private void GetRequest()
        {
            for (int i = 0; i < connList.Count; i++)
            {
                if (connList[i].User.GetStream().DataAvailable)
                {
                    RequestSelection(connList[i]);
                }
            }
        }

        private void RequestSelection(Client wanter)
        {
            StreamReader sr = new StreamReader(wanter.User.GetStream());
            string message = sr.ReadLine();

            if (message.Contains(':'))
            {
                string modifier = message.Remove(message.IndexOf(':'));
                message = message.Replace(modifier + ":", "");
                string[] names = message.Split(',');

                switch (modifier)
                {
                    case "invite":
                        {
                            var wanted = connList.GetByName(names[0]);
                            if (wanted != null)
                            {
                                bool exists = false;
                                if (requestPool.Item.Count != 0)
                                {
                                    exists = requestPool.Item.Any(r => { return r.Wanted.Name.Equals(wanted.Name); });
                                }
                                if (!exists)
                                {
                                    requestPool.AddRequest(new Request(wanted, wanter));
                                }
                            }
                            break;
                        }
                    case "yes":
                        {
                            sessions.Add(new Session(GameType.XO));
                            SessionResult(names[0], modifier);

                            Thread.Sleep(1000);

                            sessions.Last().AddPlayers(connList.GetByName(names[0]), connList.GetByName(names[1]));
                            connList.RemoveUsers(new Client[] { connList.GetByName(names[0]),
                                connList.GetByName(names[1]) });
                            break;
                        }
                    case "no":
                        {
                            SessionResult(names[0], modifier);
                            break;
                        }
                }
            }
        }

        private void SessionResult(string wantedName, string modifier)
        {
            var request = requestPool.GetByWantedName(wantedName);
            requestPool.SendResponse(request, modifier);
            requestPool.Item.Remove(request);
        }
    }
}
