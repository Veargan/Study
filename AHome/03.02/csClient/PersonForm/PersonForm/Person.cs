using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public class Person
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get;  set; }
        public int age { get; set; }
        
        public Person(){}

        public Person(int id, string firstName, string lastName, int age)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        override public string ToString()
        {
            string res = "";

            res = "[" + id + "] [" + firstName + "] [" + lastName + "] [" + age + "]";

            return res;
        }
    }
}
