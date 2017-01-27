using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonForm
{
    public partial class Form1 : Form
    {
        TableModel tm = new TableModel();
        public Form1()
        {
            InitializeComponent();
         
        }
       
        private void dbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tm.SetDB(dbList.SelectedItem.ToString());
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tm.Read();           
        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            tm.Create(ReadPerson());
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            tm.Update(ReadPerson());
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            tm.Delete(ReadPerson());
        }

        private Person ReadPerson()
        {
            int id = Convert.ToInt32(textBox1.Text);
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            int age = Convert.ToInt32(textBox4.Text);
            return new Person(id, fname, lname, age);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly thisExe = Assembly.GetExecutingAssembly();
            var types = thisExe.GetTypes();
            foreach(var i in types)
            {                
                switch(i.Name)
                {
                    case "PersonDAOMock":
                        dbList.Items.Add("Mock");
                        break;
                    case "PersonDAO_MySQL":
                        dbList.Items.Add("MySQL");
                        break;
                    case "PersonDAO_MSSQL":
                        dbList.Items.Add("MSSQL");
                        break;
                    case "PersonDAO_H2":
                        dbList.Items.Add("H2");
                        break;
                    case "PersonDAO_MongoDB":
                        dbList.Items.Add("MongoDB");
                        break;
                    case "PersonDAO_Redis":
                        dbList.Items.Add("Redis");
                        break;
                    case "PersonDAO_Cassandra":
                        dbList.Items.Add("Casandra");
                        break;
                    case "PersonDAO_Neo4j":
                        dbList.Items.Add("Neo4j");
                        break;
                    case "PersonDAO_File":
                        dbList.Items.Add("CSV");
                        dbList.Items.Add("JSON");
                        dbList.Items.Add("XML");
                        dbList.Items.Add("Yaml");
                        dbList.Items.Add("CSVAuto");
                        dbList.Items.Add("JSONAuto");
                        dbList.Items.Add("XMLAuto");
                        dbList.Items.Add("YamlAuto");
                        dbList.Items.Add("XMLRefl");
                        break;
                    case "PersonDAO_Entity":
                        dbList.Items.Add("Entity");
                        break;
                    case "PersonDAO_NH":
                        dbList.Items.Add("NH");
                        break;
                }
            }
            //if (dbList != null)
            //{
            //    dbList.SelectedIndex = 0;
            //    tm.SetDB("PersonDAOMock");
            //}
        }
    }
}
