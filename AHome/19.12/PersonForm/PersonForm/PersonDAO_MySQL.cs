using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PersonForm
{
    class PersonDAO_MySQL : IPersonDAO
    {
        public void Create(Person p)
        {
            string MyConnectionString = "Server=localhost;Database=person;User Id=root;Password=";
            try
            {

                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = String.Format("INSERT INTO person(FirstName, LastName, Age) VALUES('{0}', '{1}', {2})", p.fname, p.lname, p.age);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Person p)
        {
            string MyConnectionString = "Server=localhost;Database=person;User Id=root;Password=";
            try
            {

                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = String.Format("DELETE FROM Person WHERE Id = {0}", p.id);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            string MyConnectionString = "Server=localhost;Database=person;User Id=root;Password=";
            try
            {
                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM person";
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("Id"));
                    string f = reader.GetString(reader.GetOrdinal("FirstName"));
                    string l = reader.GetString(reader.GetOrdinal("LastName"));
                    int age = reader.GetInt32(reader.GetOrdinal("Age"));
                    pp.Add(new Person(id, f, l, age));
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return pp;
        }

        public void Update(Person p)
        {
            string MyConnectionString = "Server=localhost;Database=person;User Id=root;Password=";
            try
            {

                MySqlConnection connection = new MySqlConnection(MyConnectionString);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = String.Format("UPDATE Person SET FirstName = '{0}', LastName = '{1}', Age = {2} WHERE Id = {3}", p.fname, p.lname, p.age, p.id);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
