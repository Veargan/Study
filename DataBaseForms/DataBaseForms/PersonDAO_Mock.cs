using System.Collections.Generic;

namespace DataBaseForms
{
    class PersonDAO_Mock : IPersonDAO
    {
        List<Person> pp = null;

        public PersonDAO_Mock()
        {
            pp = new List<Person>();

            pp.Add(new Person(1, "Tylor", "Larkins", 21));
            pp.Add(new Person(2, "Robert", "Sokek", 25));
            pp.Add(new Person(3, "Rock", "Taevix", 45));
            pp.Add(new Person(4, "Texon", "Grexyov", 15));
            pp.Add(new Person(5, "Qeron", "txtov", 16));
            pp.Add(new Person(6, "Welos", "Telakor", 48));
            pp.Add(new Person(7, "Eloska", "Totaront", 30));
            pp.Add(new Person(8, "Faron", "Delakr", 24));
            pp.Add(new Person(9, "Tatov", "Hitop", 19));
            pp.Add(new Person(10, "Yongus", "Darden", 54));
            pp.Add(new Person(11, "Ulus", "Fatory", 22));
            pp.Add(new Person(12, "Cola", "Abranus", 32));
            pp.Add(new Person(13, "Enistus", "Salary", 20));
            pp.Add(new Person(14, "Proten", "Dyla", 21));
            pp.Add(new Person(15, "Askens", "Boland", 21));
            pp.Add(new Person(16, "soluk", "enigram", 34));
            pp.Add(new Person(17, "bodan", "gwerties", 48));
            pp.Add(new Person(18, "Annah", "Swert", 30));
            pp.Add(new Person(19, "Cores", "Ollafs", 19));
            pp.Add(new Person(20, "Ollah", "Fiestes", 19));
            pp.Add(new Person(21, "Jurken", "Brodish", 54));
            pp.Add(new Person(22, "Oscar", "Delavish", 22));
            pp.Add(new Person(23, "Briest", "Holand", 32));
            pp.Add(new Person(24, "Zoom", "Poud", 20));
            pp.Add(new Person(25, "Xonar", "Modle", 34));
            pp.Add(new Person(26, "Cortes", "Erdas", 32));
            pp.Add(new Person(27, "Verdan", "Kolash", 28));
            pp.Add(new Person(28, "Bill", "Ruskens", 35));
            pp.Add(new Person(29, "Coal", "Operis", 70));
            pp.Add(new Person(30, "Mute", "Kidness", 50));
        }

        public void Create(Person p)
        {
            pp.Add(new Person(p.id, p.fName, p.lName, p.age));
        }

        public List<Person> Read()
        {
            return pp;
        }

        public void Update(Person p)
        {
            for (int i = 0; i < pp.Count; i++)
            {
                if (pp[i].id == p.id)
                {
                    pp[i].age = p.age;
                    pp[i].fName = p.fName;
                    pp[i].lName = p.lName;
                    return;
                }
            }
        }

        public void Delete(Person p)
        {
            for (int i = 0; i < pp.Count; i++)
            {
                if (pp[i].id == p.id)
                {
                    pp.RemoveAt(i);
                    return;
                }
            }
        }
    }
}