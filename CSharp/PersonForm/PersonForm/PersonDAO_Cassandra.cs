using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    class PersonDAO_Cassandra : IPersonDAO
    {
        public void Create(Person p)
        {
            var cluster = Cluster.Builder().AddContactPoint("localhost").Build();
            ISession session = cluster.Connect("person");

            var rowSet = session.Execute(String.Format(@"INSERT INTO ""persons""(firstName, lastName, age) VALUES('{0}', '{1}', {2})", p.fname, p.lname, p.age));
        }

        public void Delete(Person p)
        {
            var cluster = Cluster.Builder().AddContactPoint("localhost").Build();
            ISession session = cluster.Connect("person");

            var rowSet = session.Execute(String.Format(@"DELETE FROM ""persons"" WHERE id = {0}", p.id));
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            var cluster = Cluster.Builder().AddContactPoint("localhost").Build();
            ISession session = cluster.Connect("person");

            var rowSet = session.Execute(@"SELECT * FROM ""persons"";");
            foreach (Row row in rowSet)
            {
                pp.Add(new Person(Convert.ToInt32(row["id"]), Convert.ToString(row["firstname"]), Convert.ToString(row["lastname"]), Convert.ToInt32(row["age"]))); ;
            }

            return pp;
        }

        public void Update(Person p)
        {
            var cluster = Cluster.Builder().AddContactPoint("localhost").Build();
            ISession session = cluster.Connect("person");

            var rowSet = session.Execute(String.Format(@"UPDATE ""persons"" SET firstName = '{0}', lastName = '{1}', age = {2} WHERE id = {3}", p.fname, p.lname, p.age, p.id));

        }
    }
}
