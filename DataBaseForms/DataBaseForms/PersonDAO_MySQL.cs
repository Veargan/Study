using DataBaseForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace People
{
    class PersonDAO_MySQL : IPersonDAO
    {
        private List<Person> people = new List<Person>();
        private MySqlConnection connection;

        public PersonDAO_MySQL()
        {
            people = new List<Person>();
            connection = null;
        }

        private void createConnection()
        {
            if (connection == null)
            {
                connection = new MySqlConnection("server = localhost; user = root; database = streets;");
            }
        }
        public void Create(Person p)
        {
            createConnection();
            string insertScript = String.Format("INSERT INTO Person(FirstName, LastName, Age) VALUES('{0}', '{1}', {2})",
                p.fName, p.lName, p.age);
            MySqlCommand iniQuery = null;
            try
            {
                connection.Open();
                iniQuery = new MySqlCommand(insertScript, connection);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            iniQuery.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Person p)
        {
            createConnection();
            string insertScript = String.Format("DELETE FROM Person WHERE id = {0}", p.id);
            MySqlCommand iniQuery = null;
            try
            {
                connection.Open();
                iniQuery = new MySqlCommand(insertScript, connection);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            iniQuery.ExecuteNonQuery();
            connection.Close();
        }

        public List<Person> Read()
        {
            createConnection();
            MySqlCommand iniQuery = null;
            MySqlDataReader dataReader = null;
            string selectQuery = "SELECT id, FirstName, LastName, Age FROM person";
            try
            {
                connection.Open();
                iniQuery = new MySqlCommand(selectQuery, connection);
                dataReader = iniQuery.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            while (dataReader.Read())
            {
                int i = (int)dataReader["id"];
                string f = dataReader["FirstName"].ToString();
                string l = dataReader["LastName"].ToString();
                int a = (int)dataReader["Age"];
                people.Add(new Person(i, f, l, a));
            }

            dataReader.Close();
            dataReader.Dispose();
            iniQuery.Dispose();
            connection.Close();

            return people;
        }

        public void Update(Person p)
        {
            createConnection();
            string insertScript = String.Format("UPDATE Person SET `FirstName`= '" + p.fName + "',`LastName`= '" + p.lName + "',`Age`= " + p.age + " WHERE `id`= " + p.id);
            MySqlCommand iniQuery = null;
            try
            {
                connection.Open();
                iniQuery = new MySqlCommand(insertScript, connection);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            iniQuery.ExecuteNonQuery();
            connection.Close();
        }
    }
}