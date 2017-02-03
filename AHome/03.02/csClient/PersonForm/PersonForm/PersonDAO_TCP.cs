using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;

namespace PersonForm
{
    class PersonDAO_TCP : IPersonDAO
    {
        public void Create(Person p)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1200);
            StreamWriter sw = new StreamWriter(client.GetStream());

            sw.WriteLine("create");
            sw.Flush();
            sw.WriteLine(JsonConvert.SerializeObject(p));
            sw.Flush();

            client.Close();
        }

        public void Delete(Person p)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1200);
            StreamWriter sw = new StreamWriter(client.GetStream());

            sw.WriteLine("delete");
            sw.Flush();
            sw.WriteLine(JsonConvert.SerializeObject(p));
            sw.Flush();

            client.Close();
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            TcpClient client = new TcpClient("127.0.0.1", 1200);
            
            StreamWriter sw = new StreamWriter(client.GetStream());
            StreamReader sr = new StreamReader(client.GetStream());
            sw.WriteLine("read");
            sw.Flush();
            pp = JsonConvert.DeserializeObject<List<Person>>(sr.ReadLine());

            client.Close();
            
            return pp;
        }

        public void Update(Person p)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1200);
            StreamWriter sw = new StreamWriter(client.GetStream());

            sw.WriteLine("update");
            sw.Flush();
            sw.WriteLine(JsonConvert.SerializeObject(p));
            sw.Flush();

            client.Close();
        }
    }
}
