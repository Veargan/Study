using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.sql;

namespace PersonForm
{
    class PersonDAO_H2 : IPersonDAO
    {
        public void Create(Person p)
        {
            org.h2.Driver.load();
            Connection conn = DriverManager.getConnection("jdbc:h2:~/test", "sa", "sa");
            Statement stat = conn.createStatement();
            ResultSet rs = stat.executeQuery(String.Format("INSERT INTO person(FirstName, LastName, Age) VALUES('{0}', '{1}', {2})", p.fname, p.lname, p.age));
            conn.close();
        }

        public void Delete(Person p)
        {
            org.h2.Driver.load();
            Connection conn = DriverManager.getConnection("jdbc:h2:~/test", "sa", "sa");
            Statement stat = conn.createStatement();
            ResultSet rs = stat.executeQuery(String.Format("DELETE FROM Person WHERE Id = {0}", p.id));
            conn.close();
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            org.h2.Driver.load();
            Connection conn = DriverManager.getConnection("jdbc:h2:~/test", "sa", "sa");
            Statement stat = conn.createStatement();
            ResultSet rs = stat.executeQuery("SELECT * FROM person");
            while (rs.next())
            {
                int id = rs.getInt(1);
                string f = rs.getString(2);
                string l = rs.getString(3);
                int age = rs.getInt(4);
                pp.Add(new Person(id, f, l, age));
            }
            conn.close();
            return pp;
        }

        public void Update(Person p)
        {
            org.h2.Driver.load();
            Connection conn = DriverManager.getConnection("jdbc:h2:~/test", "sa", "sa");
            Statement stat = conn.createStatement();
            ResultSet rs = stat.executeQuery(String.Format("UPDATE Person SET FirstName = '{0}', LastName = '{1}', Age = {2} WHERE Id = {3}", p.fname, p.lname, p.age, p.id));
            conn.close();
        }
    }
}
