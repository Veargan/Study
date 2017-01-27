using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PersonClient
{
    public class ConnectManager
    {
        TcpClient newClient;
        NetworkStream tcpStream;

        public ConnectManager()
        {
        }

        private void Connection()
        {
            newClient = new TcpClient();

            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 11000);

            try
            {
                newClient.Connect(endPoint);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            tcpStream = newClient.GetStream();
        }

        public void SendData(string command, string db, string id, string fname, string lname, string age)
        {
            Connection();
            byte[] sendBytes = Encoding.UTF8.GetBytes(command + " " + db + " " + id + " " + fname + " " + lname + " " + age);
           
            tcpStream.Write(sendBytes, 0, sendBytes.Length);
        }

        public DataTable SendData(string command, string db)
        {
            Connection();
            byte[] sendBytes = Encoding.UTF8.GetBytes(command + " " + db);

            tcpStream.Write(sendBytes, 0, sendBytes.Length);

            byte[] data = new byte[1024];
            int bytes = 0;
            do
            {
                bytes = tcpStream.Read(data, 0, data.Length);
            }
            while (tcpStream.DataAvailable);

            if (bytes != 0)
            {
                MemoryStream ms = new MemoryStream(bytes);
                byte[] temp = new byte[bytes];
                ms.Write(data, 0, bytes);
                BinaryFormatter bf = new BinaryFormatter();
                ms.Position = 0;
                var strr = bf.Deserialize(ms) as string[];
                List<Person> p = new List<Person>();
                for (int i = 0; i < strr.Length; i += 4)
                {
                    p.Add(new Person(Convert.ToInt32(strr[i]), strr[i + 1], strr[i + 2], Convert.ToInt32(strr[i + 3])));
                }
                ms.Close();
                DataTable dt = new DataTable();
                if (p != null)
                {
                    var pp = p;

                    dt.Columns.Add("Id");
                    dt.Columns.Add("FirstName");
                    dt.Columns.Add("LastName");
                    dt.Columns.Add("Age");
                    for (int i = 0; i < pp.Count; i++)
                    {
                        string[] str = { Convert.ToString(pp[i].id), pp[i].fname, pp[i].lname, Convert.ToString(pp[i].age) };
                        dt.Rows.Add(str);
                    }
                }
                return dt;
            }
            return null;
        }
    }
}