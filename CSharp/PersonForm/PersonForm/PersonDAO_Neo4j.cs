using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;
using Neo4jClient;

namespace PersonForm
{
    class PersonDAO_Neo4j : IPersonDAO
    {
        IDriver driver;
        ISession session;
        public void Connect()
        {
            driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "02101995"));
            session = driver.Session();
        }
        public void Create(Person p)
        {
            Connect();
            IGraphClient client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "02101995");
            client.Connect();
            var personA = p;
            client.Cypher
                .Create("(agency:Person {personA})")
                .WithParam("personA", p)
                .ExecuteWithoutResultsAsync()
                .Wait();
        }

        public void Delete(Person p)
        {
            Connect();
            session.Run(String.Format("MATCH (n:Person) WHERE n.id = {0} DELETE n", p.id));
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            Connect();
            var resultid = session.Run("MATCH (n:Person) RETURN n.id,n.fname,n.lname,n.age");

            foreach (var record in resultid)
            {
                pp.Add(new Person(record["n.id"].As<int>(), record["n.fname"].As<string>(), record["n.lname"].As<string>(), record["n.age"].As<int>()));
            }

            return pp;
        }

        public void Update(Person p)
        {
            Connect();
            session.Run(String.Format("MATCH (n:Person) WHERE n.id={0} SET n.fname='{1}',n.lname='{2}',n.age={3}", p.id, p.fname, p.lname, p.age));
        }
    }
}
