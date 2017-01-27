namespace HashTable
{
    public class Person
    {
        public int id;
        public string firstName;
        public string lastName;
        public int age;

        public Person(int id, string firstName, string lastName, int age)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public Person(Person p)
        {
            this.id = p.id;
            this.firstName = p.firstName;
            this.lastName = p.lastName;
            this.age = p.age;
        }

        public override int GetHashCode()
        {
            int hash = 0;

            hash += id + age;

            for (int i = 0; i < this.lastName.Length; i++)
            {
                hash += this.lastName[i];
            }

            return hash;
        }

        public override string ToString()
        {
            string res = "[" +
                "id: " + this.id + " ;" +
                "first name: " + this.firstName + " ;" +
                "last name: " + this.lastName + " ;" +
                "age: " + this.age + " ;" +
                "]";
            return res;
        }

        public override bool Equals(object obj)
        {
            bool res;
            Person p = obj as Person;

            if (this.id == p.id && this.age == p.age 
             && this.firstName == p.firstName && this.lastName == p.lastName)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            return res;
        }

    }
}