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
    public class FIlesAutoTests
    {
        [Test]
        public void CSVReadTestNull()
        {
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvrn.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVReadTestZero()
        {
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvr0.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void CSVReadTestOne()
        {
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvr1.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvr2.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvrm.txt");
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
        public void CSVUpdateTestNull()
        {
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvun.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void CSVUpdateTestZero()
        {
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvu0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void CSVUpdateTestOne()
        {
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvu1.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvu2.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvum.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvumnid.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvdn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void CSVDeleteTestZero()
        {
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvd0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void CSVDeleteTestOne()
        {
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvd1.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvd2.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvdm.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvcn.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvc0.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvc1.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvc2.txt");
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
            PersonDAO_CSVAuto fl = new PersonDAO_CSVAuto(@"E:\testsauto\csvcm.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonrn.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void JSONReadTestZero()
        {
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonr0.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));

        }
        [Test]
        public void JSONReadTestOne()
        {
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonr1.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonr2.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonrm.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonun.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<ArgumentOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void JSONUpdateTestZero()
        {
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonu0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<ArgumentOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void JSONUpdateTestOne()
        {
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonu1.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonu2.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonum.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonumnid.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsondn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<ArgumentOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void JSONDeleteTestZero()
        {
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsond0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<ArgumentOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void JSONDeleteTestOne()
        {
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsond1.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsond2.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsondm.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsoncn.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonc0.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonс1.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\tests\jsonс2.txt");
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
            PersonDAO_JSONAuto fl = new PersonDAO_JSONAuto(@"E:\testsauto\jsonсm.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlrn.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void XMLReadTestZero()
        {
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlr0.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));

        }
        [Test]
        public void XMLReadTestOne()
        {
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlr1.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlr2.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlrm.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlun.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void XMLUpdateTestZero()
        {
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlu0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void XMLUpdateTestOne()
        {
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlu1.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlu2.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlum.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlumnid.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmldn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void XMLDeleteTestZero()
        {
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmld0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void XMLDeleteTestOne()
        {
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmld1.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmld2.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmldm.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlcn.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlc0.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlc1.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlc2.txt");
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
            PersonDAO_XMLAuto fl = new PersonDAO_XMLAuto(@"E:\testsauto\xmlcm.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlrn.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlReadTestZero()
        {
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlr0.txt");
            List<Person> pzero = new List<Person>();
            List<Person> pp = new List<Person>();
            pp = fl.Read();
            Assert.AreEqual(pzero.Count, pp.Count);
            Assert.AreEqual(true, pzero.SequenceEqual(pp, new PersonComparer()));
        }
        [Test]
        public void YamlReadTestOne()
        {
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlr1.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlr2.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlrm.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlun.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void YamlUpdateTestZero()
        {
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlu0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Jack", "Lemonade", 34);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Update(p));
        }
        [Test]
        public void YamlUpdateTestOne()
        {
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlu1.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlu2.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlum.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlumnid.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamldn.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void YamlDeleteTestZero()
        {
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamld0.txt");
            List<Person> pp = new List<Person>();
            Person p = new Person(1, "Lebron", "James", 25);
            Assert.Throws<IndexOutOfRangeException>(() => fl.Delete(p));
        }
        [Test]
        public void YamlDeleteTestOne()
        {
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamld1.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamld2.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamldm.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlcn.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlc0.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlc1.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlc2.txt");
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
            PersonDAO_YamlAuto fl = new PersonDAO_YamlAuto(@"E:\testsauto\yamlcm.txt");
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
