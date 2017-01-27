using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data;

namespace PersonForm
{
    class PersonDAO_Entity : IPersonDAO2
    {
        override public void Create(Person p)
        {
            using (var db = new User())
            {
                Users us = new Users();
                us.id = p.id;
                us.fname = p.fname;
                us.lname = p.lname;
                us.age = p.age;
                db.Users.Add(us);
            }
        }

        override public void Delete(Person p)
        {
            using (var db = new User())
            {
                Users us = new Users();
                us.id = p.id;
                us.fname = p.fname;
                us.lname = p.lname;
                us.age = p.age;
                db.Users.Remove(us);
            }
        }

        override public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            using (var db = new User())
            {
                var users = db.Users.ToList();
                foreach (var u in users)
                {
                    pp.Add(new Person(u.id, u.fname, u.lname, Convert.ToInt32(u.age)));
                }
            }
            return pp;
        }

        override public void Update(Person p)
        {
            using (var db = new User())
            {
                foreach (var us in db.Users)
                {
                    if (us.id == p.id)
                    {
                        us.id = p.id;
                        us.fname = p.fname;
                        us.lname = p.lname;
                        us.age = p.age;
                        break;
                    }
                }
            }
        }
    }
}
