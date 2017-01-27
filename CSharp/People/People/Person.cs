using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    public class Person
    {
        public int id;
        public string fName;
        public string lName;
        public int age;

        public Person()
        { }

        public Person( int id, string fName, string lName, int age )
        {
            this.id = id;
            this.fName = fName;
            this.lName = lName;
            this.age = age;
        }

        public override string ToString()
        {
            string str = "[ " + id + ", " + fName + ", " + lName + ", " + age + " ]";
            return str;
        }
    }
}
