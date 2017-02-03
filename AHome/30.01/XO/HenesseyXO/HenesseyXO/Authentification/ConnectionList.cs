using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenesseyXO.Authentification
{
    public class ConnectionList
    {
        private List<Client> userList;
        private Object locker;

        public int Count { get { return userList.Count; } }

        public void AddUser(Client user)
        {
            lock(locker)
            {
                this.userList.Add(user);
            }
            BroadcastSend();
        }

        public void RemoveUser(Client user)
        {
            lock (locker)
            {
                this.userList.Remove(user);
            }
        }

        public void RemoveUsers(IEnumerable<Client> users)
        {
            lock (locker)
            {
                foreach (var item in users)
                {
                    this.userList.Remove(item);
                }
            }
            BroadcastSend();
        }

        public Client GetByName(string name)
        {
            IEnumerable<Client> client = null;
            client = from cl in userList
                     where cl.Name.Equals(name)
                     select cl;
            return client.First();
        }

        public ConnectionList(Object locker)
        {
            userList = new List<Client>();
            this.locker = locker;
        }

        public bool IsEmpty()
        {
            return userList.Count == 0;
        }

        private void BroadcastSend()
        {
            string freeUsersStr = "broadcast:";
            userList.ForEach(c => freeUsersStr += c.Name + ",");
            freeUsersStr = freeUsersStr.Remove(freeUsersStr.Length - 1);
            userList.ForEach(c =>
            {
                var writer = new StreamWriter(c.User.GetStream());
                writer.WriteLine(freeUsersStr);
                writer.Flush();
            });
        }

        public Client this[int index]
        {
            set
            {
                this.userList[index] = value;
            }
            get
            {
                return this.userList[index];
            }
        }
    }
}
