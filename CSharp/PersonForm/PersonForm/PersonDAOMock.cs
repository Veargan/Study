using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    class PersonDAOMock : IPersonDAO
    {
        List<Person> pp = null;
        public PersonDAOMock()
        {
            pp = new List<Person>();

            pp.Add(new Person(12, "Tyrion", "Lannister", 21));
            pp.Add(new Person(13, "Rob", "Stark", 25));
            pp.Add(new Person(14, "Rhagar", "Targaryen", 45));
            pp.Add(new Person(15, "teon", "Greyjoy", 15));
            pp.Add(new Person(16, "John", "Hardy", 16));
            pp.Add(new Person(17, "Max", "Ort", 48));
            pp.Add(new Person(18, "Peter", "Watts", 30));
            pp.Add(new Person(19, "Ivan", "Stepnov", 24));
            pp.Add(new Person(20, "George", "Mathews", 19));
            pp.Add(new Person(21, "Edward", "Payne", 54));
            pp.Add(new Person(22, "Edward", "Cullen", 22));
            pp.Add(new Person(23, "Leonardo", "DaVinci", 32));
            pp.Add(new Person(24, "George", "Bush", 20));
            pp.Add(new Person(25, "Phill", "Hill", 21));
            pp.Add(new Person(25, "Tom", "Hanks", 21));
            pp.Add(new Person(26, "Bruce", "Wayne", 34));
            pp.Add(new Person(17, "Jozeph", "fox", 48));
            pp.Add(new Person(18, "Peter", "Watts", 30));
            pp.Add(new Person(19, "Ivan", "Ivanov", 24));
            pp.Add(new Person(20, "George", "Mathews", 19));
            pp.Add(new Person(21, "Bread", "Pitt", 54));
            pp.Add(new Person(22, "Oleh", "Jdanov", 22));
            pp.Add(new Person(23, "Leo", "Cohen", 32));
            pp.Add(new Person(24, "George", "Shestakov", 20));
            pp.Add(new Person(26, "Alexandr", "Chehov", 34));
            pp.Add(new Person(27, "yen", "Fox", 32));
            pp.Add(new Person(28, "Karl", "Coxer", 28));
            pp.Add(new Person(29, "Eddy", "Pitt", 35));
            pp.Add(new Person(30, "Maximilian", "Gorner", 70));
            pp.Add(new Person(31, "Stefan", "Hilov", 50));
        }
        public void Create(Person p)
        {
            pp.Add(new Person(p.id, p.fname, p.lname, p.age));
        }

        public void Delete(Person p)
        {
            foreach (var item in pp)
            {
                if (item.id == p.id)
                {
                    pp.Remove(item);
                    break;
                }
            }
        }

        public List<Person> Read()
        {
            return pp;
        }

        public void Update(Person p)
        {
            foreach (var item in pp)
            {
                if (item.id == p.id)
                {
                    item.fname = p.fname;
                    item.fname = p.fname;
                    item.age = p.age;
                    break;
                }
            }
        }
    }
}
