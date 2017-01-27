using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace PersonForm
{
    class PersonDAO_Redis : IPersonDAO
    {
        public void Create(Person p)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            string s = Convert.ToString(p.id) + " " + p.fname + " " + p.lname + " " + Convert.ToString(p.age);
            db.ListRightPush("person", s);
        }

        public void Delete(Person p)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            string s = Convert.ToString(p.id) + " " + p.fname + " " + p.lname + " " + Convert.ToString(p.age);
            db.ListRemove("person", s);
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();

            for (long i = db.ListLength("person") - 1; i >= 0; i--)
            {
                string s = db.ListGetByIndex("person", i);
                string[] str = s.Split(' ');
                pp.Add(new Person(Convert.ToInt32(str[0]), str[1], str[2], Convert.ToInt32(str[3])));
            }

            return pp;
        }

        public void Update(Person p)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = redis.GetDatabase();
            string s = Convert.ToString(p.id) + " " + p.fname + " " + p.lname + " " + Convert.ToString(p.age);
            db.ListSetByIndex("person", db.ListLength("person") - p.id, s);
        }
    }
}
