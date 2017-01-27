using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;

namespace PersonForm
{
    class PersonDAO_NH : IPersonDAO2
    {
        Configuration configuration;
        ISessionFactory sessionFactory;
        ISession mySession;
        public void Connect()
        {
            configuration = new Configuration();
            configuration.Configure();
            sessionFactory = configuration.BuildSessionFactory();
            mySession = sessionFactory.OpenSession();
        }
        override public void Create(Person p)
        {
            Connect();
            using (mySession.BeginTransaction())
            {
                mySession.Save(p,p.id);
                mySession.Transaction.Commit();
            }
        }

        override public void Delete(Person p)
        {
            Connect();
            using (mySession.BeginTransaction())
            {
                mySession.Delete(p);
                mySession.Transaction.Commit();
            }
        }

        override public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            Connect();
            using (mySession.BeginTransaction())
            {
                ICriteria criteria = mySession.CreateCriteria<Person>();
                IList<Person> list = criteria.List<Person>();
                foreach(var p in list)
                {
                    pp.Add(new Person(p.id, p.fname, p.lname, p.age));
                }
            }

            return pp;
        }

        override public void Update(Person p)
        {
            Connect();
            using (mySession.BeginTransaction())
            {
                mySession.Update(p,p.id);
                mySession.Transaction.Commit();
            }
        }
    }
}
