using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    abstract public class PersonDAO_File
    {
        public void Create(Person p)
        {
            List<Person> pp = null;
            if (Read() != null)
            {
                pp = Read();
                Read();
                pp.Add(p);
            }
            else
            {
                pp.Add(p);
            }
            Write(pp);
        }

        public void Delete(Person p)
        {
            List<Person> pp = Read();

            if (pp.Count == 0)
                throw new IndexOutOfRangeException();

            for (int i = 0; i < pp.Count; i++)
            {
                if (pp[i].id == p.id)
                {
                    pp.RemoveAt(i);
                    break;
                }
            }

            Write(pp);
        }

        public void Update(Person p)
        {
            List<Person> pp = Read();

            if (pp.Count == 0)
                throw new IndexOutOfRangeException();

            for (int i = 0; i < pp.Count; i++)
            {
                if (pp[i].id == p.id)
                {
                    pp[i].fname = p.fname;
                    pp[i].lname = p.lname;
                    pp[i].age = p.age;
                    break;
                }
            }

            Write(pp);
        }

        abstract public List<Person> Read();
        abstract public void Write(List<Person> pp);
    }
}
