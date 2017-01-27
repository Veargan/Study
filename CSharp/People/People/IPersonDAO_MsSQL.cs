using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    class IPersonDAO_MsSQL : IPersonDAO
    {
        private List<Person> personList;
        private SqlConnection connection;

        public IPersonDAO_MsSQL()
        {
            personList = new List<Person>();
            connection = null;
        }

        private void createConnection()
        {
            if (connection == null)
            {
                SqlConnectionStringBuilder connectStrBuilder = new SqlConnectionStringBuilder();
                connectStrBuilder.DataSource = "DESKTOP-D9F70GC";
                connectStrBuilder.InitialCatalog = "master";
                connectStrBuilder.UserID = "DESKTOP-D9F70GC/Ilya";
                connectStrBuilder.IntegratedSecurity = true;
                connection = new SqlConnection(connectStrBuilder.ConnectionString);
            }
        }

        public void Create(Person persona)
        {
            createConnection();
            string insertScript = String.Format("INSERT INTO Table_1_Ilya(fName, lName, age) VALUES('{0}', '{1}', {2})", persona.fName, persona.lName, persona.age);
            SqlCommand iniQuery = null;
            try
            {
                connection.Open();
                iniQuery = new SqlCommand(insertScript, connection);
            }
            catch (SqlException ex)
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
            SqlCommand iniQuery = null;
            SqlDataReader dataReader = null;
            string selectQuery = "SELECT id, fName, lName, age FROM Table_1_Ilya";
            try
            {
                connection.Open();
                iniQuery = new SqlCommand(selectQuery, connection);
                dataReader = iniQuery.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            while (dataReader.Read())
            {
                personList.Add(
                new Person(
                    (int)dataReader["id"],
                    dataReader["fName"].ToString(),
                    dataReader["lName"].ToString(),
                    (int)dataReader["age"]
                ));
            }

            dataReader.Close();
            dataReader.Dispose();
            iniQuery.Dispose();
            connection.Close();

            return personList;
        }

        public void Delete(Person persona)
        {
            createConnection();
            string insertScript = String.Format("DELETE FROM Table_1_Ilya WHERE id = {0}", persona.id);
            SqlCommand iniQuery = null;
            try
            {
                connection.Open();
                iniQuery = new SqlCommand(insertScript, connection);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            iniQuery.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Person p)
        {
            createConnection();
            string insertScript = String.Format("UPDATE Table_1_Ilya SET fName= '" + p.fName + "',lName= '" + p.lName + "',age= " + p.age + " WHERE id= " + p.id);
            SqlCommand iniQuery = null;
            try
            {
                connection.Open();
                iniQuery = new SqlCommand(insertScript, connection);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            iniQuery.ExecuteNonQuery();
            connection.Close();
        }
    }
}
