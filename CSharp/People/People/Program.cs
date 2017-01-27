using System;
using System.Collections.Generic;
using System.Linq;

namespace People
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPersonDAO pd = new PersonDAO_MySQL();
            //IPersonDAO pd = new PersonDAO_Mock();
            IPersonDAO pd = new IPersonDAO_MsSQL();

            List<Person> pp = pd.Read();

            Person p = new Person(2, "rack", "lemonade", 123);
            pd.Update(p);
            pp = pd.Read();

            PrintAll(pp);

            Console.ReadKey();
        }

        static void PrintAll(List<Person> pp)
        {
            for (int i = 0; i < pp.Count; i++)
            {
                Console.WriteLine(pp.ElementAt(i));
            }
        }
    }
}