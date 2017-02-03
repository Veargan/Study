using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using ServiceStack.Text;

namespace PersonForm
{
    class PersonDAO_HTTP_CSV : IPersonDAO
    {
        WebRequest req;
        StreamWriter writer;

        private void Connection()
        {
            req = WebRequest.Create("http://localhost/www/API/PersonDAO_API_AJAX_CSV.php");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            writer = new StreamWriter(req.GetRequestStream());
        }
        public void Create(Person p)
        {
            Connection();
            string postData = "query=create&Id=" + p.id + "&FirstName=" +
                p.firstName + "&LastName=" + p.lastName + "&Age=" + p.age;
            writer.Write(postData);
            writer.Close();
        }

        public void Update(Person p)
        {
            Connection();
            string postData = "query=update&Id=" + p.id + "&FirstName=" +
                p.firstName + "&LastName=" + p.lastName + "&Age=" + p.age;
            writer.Write(postData);
            writer.Close();
        }

        public List<Person> Read()
        {
            Connection();
            string postData = "query=read";
            writer.Write(postData);
            writer.Close();

            WebResponse response = req.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            List<Person> list = new List<Person>();
           
            string[] responseFromServer = reader.ReadToEnd().Split('\n');
            string result = "";
            foreach (var s in responseFromServer)
            {
                result += s + "\r\n";
            }

            list = CsvSerializer.DeserializeFromString<List<Person>>(result);
            return list;
        }

        public void Delete(Person p)
        {
            Connection();
            string postData = "query=delete&Id=" + p.id;
            writer.Write(postData);
            writer.Close();
        }
    }
}
