using System;
using System.Collections.Generic;

namespace People
{
    class PersonDAO_Mock 
    {
        LinkedList<Person> pp = null;
        #region Init
        public PersonDAO_Mock()
        {
            pp = new LinkedList<Person>();

            pp.AddLast(new Person(12, "Tylor", "Larkins", 21));
            pp.AddLast(new Person(13, "Robert", "Sokek", 25));
            pp.AddLast(new Person(14, "Rock", "Taevix", 45));
            pp.AddLast(new Person(15, "Texon", "Grexyov", 15));
            pp.AddLast(new Person(16, "Qeron", "txtov", 16));
            pp.AddLast(new Person(17, "Welos", "Telakor", 48));
            pp.AddLast(new Person(18, "Eloska", "Totaront", 30));
            pp.AddLast(new Person(19, "Faron", "Delakr", 24));
            pp.AddLast(new Person(20, "Tatov", "Hitop", 19));
            pp.AddLast(new Person(21, "Yongus", "Darden", 54));
            pp.AddLast(new Person(22, "Ulus", "Fatory", 22));
            pp.AddLast(new Person(23, "Cola", "Abranus", 32));
            pp.AddLast(new Person(24, "Enistus", "Salary", 20));
            pp.AddLast(new Person(25, "Proten", "Dyla", 21));
            pp.AddLast(new Person(25, "Askens", "Boland", 21));
            pp.AddLast(new Person(26, "soluk", "enigram", 34));
            pp.AddLast(new Person(17, "bodan", "gwerties", 48));
            pp.AddLast(new Person(18, "Annah", "Swert", 30));
            pp.AddLast(new Person(19, "Cores", "Ollafs", 24));
            pp.AddLast(new Person(20, "Ollah", "Fiestes", 19));
            pp.AddLast(new Person(21, "Jurken", "Brodish", 54));
            pp.AddLast(new Person(22, "Oscar", "Delavish", 22));
            pp.AddLast(new Person(23, "Briest", "Holand", 32));
            pp.AddLast(new Person(24, "Zoom", "Poud", 20));
            pp.AddLast(new Person(26, "Xonar", "Modle", 34));
            pp.AddLast(new Person(27, "Cortes", "Erdas", 32));
            pp.AddLast(new Person(28, "Verdan", "Kolash", 28));
            pp.AddLast(new Person(29, "Bill", "Ruskens", 35));
            pp.AddLast(new Person(30, "Coal", "Operis", 70));
            pp.AddLast(new Person(31, "Mute", "Kidness", 50));
        }
        #endregion

        public void Create(Person p)
        {
            pp.AddLast(new Person(p.id, p.fName, p.lName, p.age));
        }

        public LinkedList<Person> Read()
        {
            return pp;
        }
        public void Update(Person p)
        {
            pp.RemoveLast();
            pp.AddLast(new Person(p.id, p.fName, p.lName, p.age));
        }

        public void Delete(Person p)
        {
            pp.RemoveLast();
        }
    }
}