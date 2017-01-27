using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonForm;

namespace FilesCrudTest
{
    [TestFixture]
    public class FIlesTests
    {
        [Test]
        public void CSVReadTestNull()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvrn.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVReadTestZero()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvr0.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVReadTestOne()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvr1.txt");
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Lebron", "James", 25));
            List<Person> pp = new List<Person>();
            pp = fl.Read();           
            Assert.AreEqual(pone.Count, pp.Count); 
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));      
        }
        [Test]
        public void CSVReadTestTwo()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvr2.txt");
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Lebron", "James", 25));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVReadTestMany()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvrm.txt");
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp =new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVUpdateTestNull()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvun.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void CSVUpdateTestZero()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvu0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void CSVUpdateTestOne()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvu1.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Jack", "Lemonade", 34));
            List<Person> pp = new List<Person>();          
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVUpdateTestTwo()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvu2.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Jack", "Lemonade", 34));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVUpdateTestMany()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvum.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Jack", "Lemonade", 34));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVUpdateTestManyNoneId()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvumnid.txt");
            Person p = new Person(9, "Jack", "Lemonade", 34);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVDeleteTestNull()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvdn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void CSVDeleteTestZero()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvd0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void CSVDeleteTestOne()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvd1.txt");
            Person p = new Person(1, "Lebron", "James", 25);           
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVDeleteTestTwo()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvd2.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVDeleteTestMany()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvdm.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }

        [Test]
        public void CSVCreateTestNull()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvcn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            pzero.Add(new Person(1, "Lebron", "James", 25));
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVCreateTestZero()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvc0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            pzero.Add(new Person(1, "Lebron", "James", 25));
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVCreateTestOne()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvc1.txt");
            Person p = new Person(2, "Jack", "Lemonade", 22);
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Lebron", "James", 22));
            pone.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVCreateTestTwo()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvc2.txt");
            Person p = new Person(3, "Chris", "Paul", 23);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Lebron", "James", 22));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            ptwo.Add(new Person(3, "Chris", "Paul", 23));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVCreateTestMany()
        {
            PersonDAO_CSV fl = new PersonDAO_CSV(@"E:\tests\csvcm.txt");
            Person p = new Person(8, "Lebron", "James", 25);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            pmany.Add(new Person(8, "Lebron", "James", 25));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }

        [Test]
        public void JSONReadTestNull()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonrn.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONReadTestZero()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonr0.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));

        }
        [Test]
        public void JSONReadTestOne()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonr1.txt");
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Lebron", "James", 25));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONReadTestTwo()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonr2.txt");
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Lebron", "James", 25));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONReadTestMany()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonrm.txt");
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONUpdateTestNull()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonun.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<ArgumentOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void JSONUpdateTestZero()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonu0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<ArgumentOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void JSONUpdateTestOne()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonu1.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Jack", "Lemonade", 34));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONUpdateTestTwo()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonu2.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Jack", "Lemonade", 34));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONUpdateTestMany()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonum.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Jack", "Lemonade", 34));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONUpdateTestManyNoneId()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonumnid.txt");
            Person p = new Person(9, "Jack", "Lemonade", 34);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONDeleteTestNull()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsondn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<ArgumentOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void JSONDeleteTestZero()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsond0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<ArgumentOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void JSONDeleteTestOne()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsond1.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONDeleteTestTwo()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsond2.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONDeleteTestMany()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsondm.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }

        [Test]
        public void JSONCreateTestNull()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsoncn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            pzero.Add(new Person(1, "Lebron", "James", 25));
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONCreateTestZero()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonc0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            pzero.Add(new Person(1, "Lebron", "James", 25));
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONCreateTestOne()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonс1.txt");
            Person p = new Person(2, "Jack", "Lemonade", 22);
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Lebron", "James", 25));
            pone.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONCreateTestTwo()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonс2.txt");
            Person p = new Person(3, "Chris", "Paul", 23);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Lebron", "James", 25));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            ptwo.Add(new Person(3, "Chris", "Paul", 23));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONCreateTestMany()
        {
            PersonDAO_JSON fl = new PersonDAO_JSON(@"E:\tests\jsonсm.txt");
            Person p = new Person(8, "Lebron", "James", 25);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            pmany.Add(new Person(8, "Lebron", "James", 25));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }

        [Test]
        public void XMLReadTestNull()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlrn.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLReadTestZero()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlr0.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));

        }
        [Test]
        public void XMLReadTestOne()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlr1.txt");
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Lebron", "James", 25));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLReadTestTwo()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlr2.txt");
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Lebron", "James", 25));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLReadTestMany()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlrm.txt");
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLUpdateTestNull()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlun.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void XMLUpdateTestZero()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlu0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void XMLUpdateTestOne()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlu1.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Jack", "Lemonade", 34));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLUpdateTestTwo()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlu2.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Jack", "Lemonade", 34));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLUpdateTestMany()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlum.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Jack", "Lemonade", 34));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLUpdateTestManyNoneId()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlumnid.txt");
            Person p = new Person(9, "Jack", "Lemonade", 34);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLDeleteTestNull()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmldn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void XMLDeleteTestZero()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmld0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void XMLDeleteTestOne()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmld1.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLDeleteTestTwo()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmld2.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLDeleteTestMany()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmldm.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }

        [Test]
        public void XMLCreateTestNull()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlcn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            pzero.Add(new Person(1, "Lebron", "James", 25));
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLCreateTestZero()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlc0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            pzero.Add(new Person(1, "Lebron", "James", 25));
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLCreateTestOne()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlc1.txt");
            Person p = new Person(2, "Jack", "Lemonade", 22);
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Lebron", "James", 25));
            pone.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLCreateTestTwo()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlc2.txt");
            Person p = new Person(3, "Chris", "Paul", 23);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Lebron", "James", 25));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            ptwo.Add(new Person(3, "Chris", "Paul", 23));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLCreateTestMany()
        {
            PersonDAO_XML fl = new PersonDAO_XML(@"E:\tests\xmlcm.txt");
            Person p = new Person(8, "Lebron", "James", 25);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            pmany.Add(new Person(8, "Lebron", "James", 25));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }

        [Test]
        public void YamlReadTestNull()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlrn.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlReadTestZero()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlr0.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlReadTestOne()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlr1.txt");
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Lebron", "James", 25));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlReadTestTwo()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlr2.txt");
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Lebron", "James", 25));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlReadTestMany()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlrm.txt");
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlUpdateTestNull()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlun.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void YamlUpdateTestZero()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlu0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void YamlUpdateTestOne()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlu1.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Jack", "Lemonade", 34));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlUpdateTestTwo()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlu2.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Jack", "Lemonade", 34));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlUpdateTestMany()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlum.txt");
            Person p = new Person(1, "Jack", "Lemonade", 34);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Jack", "Lemonade", 34));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlUpdateTestManyNoneId()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlumnid.txt");
            Person p = new Person(9, "Jack", "Lemonade", 34);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Update(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlDeleteTestNull()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamldn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void YamlDeleteTestZero()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamld0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void YamlDeleteTestOne()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamld1.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlDeleteTestTwo()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamld2.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlDeleteTestMany()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamldm.txt");
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            List<Person> pp = new List<Person>();
            fl.Delete(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }

        [Test]
        public void YamlCreateTestNull()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlcn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            pzero.Add(new Person(1, "Lebron", "James", 25));
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlCreateTestZero()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlc0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            List<Person> pzero = new List<Person>();
            pzero.Add(new Person(1, "Lebron", "James", 25));
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlCreateTestOne()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlc1.txt");
            Person p = new Person(2, "Jack", "Lemonade", 22);
            List<Person> pone = new List<Person>();
            pone.Add(new Person(1, "Lebron", "James", 25));
            pone.Add(new Person(2, "Jack", "Lemonade", 22));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pone.Count, pp.Count);
            Assert.AreEqual(true, pone.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlCreateTestTwo()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlc2.txt");
            Person p = new Person(3, "Chris", "Paul", 23);
            List<Person> ptwo = new List<Person>();
            ptwo.Add(new Person(1, "Lebron", "James", 25));
            ptwo.Add(new Person(2, "Jack", "Lemonade", 22));
            ptwo.Add(new Person(3, "Chris", "Paul", 23));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(ptwo.Count, pp.Count);
            Assert.AreEqual(true, ptwo.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlCreateTestMany()
        {
            PersonDAO_Yaml fl = new PersonDAO_Yaml(@"E:\tests\yamlcm.txt");
            Person p = new Person(8, "Lebron", "James", 25);
            List<Person> pmany = new List<Person>();
            pmany.Add(new Person(1, "Lebron", "James", 25));
            pmany.Add(new Person(2, "Jack", "Lemonade", 22));
            pmany.Add(new Person(3, "Chris", "Paul", 21));
            pmany.Add(new Person(4, "Tim", "Duncan", 25));
            pmany.Add(new Person(5, "Kobe", "Bryant", 35));
            pmany.Add(new Person(6, "Tony", "Parker", 40));
            pmany.Add(new Person(7, "John", "Wall", 17));
            pmany.Add(new Person(8, "Lebron", "James", 25));
            List<Person> pp = new List<Person>();
            fl.Create(p);
            pp = fl.Read();
            Assert.AreEqual(pmany.Count, pp.Count);
            Assert.AreEqual(true, pmany.SequenceEqual(pp, new PersonComparer()));
        }
    }
}
