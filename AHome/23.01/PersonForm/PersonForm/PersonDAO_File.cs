﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public class PersonDAO_File : IPersonDAO2
    {
        IPersonIO rw = null;

        public PersonDAO_File(string type)
        {
            this.str = type;
            rw = PersonFile_Impl.GetInstance(type);
        }

        override public void Create(Person p)
        {
            List<Person> pp = null;
            if (rw.Read() != null)
            {
                pp = rw.Read();
                rw.Read();
                pp.Add(p);
            }
            else
            {
                pp.Add(p);
            }
            rw.Write(pp);
        }
        override public void Delete(Person p)
        {
            List<Person> pp = rw.Read();
            if (pp.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = 0; i < pp.Count; i++)
            {
                if (pp[i].id == p.id)
                {
                    pp.RemoveAt(i);
                    break;
                }
            }

            rw.Write(pp);
        }
        override public void Update(Person p)
        {
            List<Person> pp = rw.Read();
            if (pp.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
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

            rw.Write(pp);
        }
        override public List<Person> Read()
        {
            return rw.Read();
        }
    }
}
