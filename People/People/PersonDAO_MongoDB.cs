using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Builders;

namespace People
{
    class PersonDAO_MongoDB : IPersonDAO
    {
        [BsonIgnoreExtraElements]
        public class Persons
        {
            public int id { get; set; }
            [BsonElement("FirstName")]
            public string FirstName { get; set; }
            [BsonElement("LastName")]
            public string LastName { get; set; }
            [BsonElement("Age")]
            public int Age { get; set; }
        }
        public void Create(Person p)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            server.Connect();
            MongoDatabase database = server.GetDatabase("persondb");
            var col = database.GetCollection<Persons>("person");
            Persons pp = new Persons();
            pp.id = p.id;
            pp.FirstName = p.fname;
            pp.LastName = p.lname;
            pp.Age = p.age;
            col.Insert(pp);
            server.Disconnect();
        }

        public void Delete(Person p)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            server.Connect();
            MongoDatabase database = server.GetDatabase("persondb");
            var col = database.GetCollection<Persons>("person");
            Persons pp = new Persons();
            pp.id = p.id;
            pp.FirstName = p.fname;
            pp.LastName = p.lname;
            pp.Age = p.age;
            col.Remove(Query.EQ("_id", p.id));
            server.Disconnect();
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            server.Connect();
            MongoDatabase database = server.GetDatabase("persondb");
            var col = database.GetCollection<Persons>("person");
            MongoCursor<Persons> cur = col.FindAll();
            foreach (var clubMember in cur)
            {
                int id = clubMember.id;
                string fname = clubMember.FirstName;
                string lname = clubMember.LastName;
                int age = clubMember.Age;
                pp.Add(new Person(id, fname, lname, age));
            }
            server.Disconnect();
            return pp;
        }

        public void Update(Person p)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            server.Connect();
            MongoDatabase database = server.GetDatabase("persondb");
            var col = database.GetCollection<Persons>("person");

            var filter = Query.EQ("_id", p.id);
            col.Update(filter, Update.Set("FirstName", p.fname)
            .Set("LastName", p.lname)
            .Set("Age", p.age));
            server.Disconnect();
        }
    }
}