using System;
using System.Collections.Generic;

namespace PersonForm
{
    public class Person
    {
        public virtual int id { get; set; }
        public virtual string fname { get; set; }
        public virtual string lname { get;  set; }
        public virtual int age { get; set; }

        [Obsolete("Only needed for serialization and materialization", true)]
        public Person()
        {

        }

        public Person(int id, string fname, string lname, int age)
        {
            this.id = id;
            this.fname = fname;
            this.lname = lname;
            this.age = age;
        }

        override public string ToString()
        {
            string res = "";

            res = "[" + id + "] [" + fname + "] [" + lname + "] [" + age + "]";

            return res;
        }
    }

    public class PersonComparer : IEqualityComparer<Person>
    {

        public bool Equals(Person x, Person y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            return (x != null && y != null && x.id.Equals(y.id) && x.fname.Equals(y.fname) && x.lname.Equals(y.lname) && x.age.Equals(y.age));
        }

        public int GetHashCode(Person obj)
        {
            int hashProductName = obj.fname == null ? 0 : obj.fname.GetHashCode();

            int hashProductCode = obj.id.GetHashCode();

            return hashProductName ^ hashProductCode;
        }
    }
}
