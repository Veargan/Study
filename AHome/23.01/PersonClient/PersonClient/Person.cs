using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClient
{
    [Serializable]
    public class Person
        {
            public int id { get; set; }
            public string fname { get; set; }
            public string lname { get; set; }
            public  int age { get; set; }


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
}
