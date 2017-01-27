using People;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataBaseForms
{
    public partial class Form1 : Form
    {
        private IPersonDAO pd;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Read(pd.Read());
        }

        private void Read(List<Person> pp)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[0].Name = "fName";
            dataGridView1.Columns[0].Name = "lName";
            dataGridView1.Columns[0].Name = "Age";

            for (int i = 0; i < pp.Count; i++)
            {
                string[] str = { pp[i].id.ToString(), pp[i].fName, pp[i].lName, pp[i].age.ToString() };
                dataGridView1.Rows.Add(str);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            pd.Create(GetPerson());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            pd.Update(GetPerson());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            pd.Delete(GetPerson());
        }

        private Person GetPerson()
        {
            return new Person(Int32.Parse(Id.Text), fName.Text, lName.Text, Int32.Parse(Age.Text));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Mock":
                    pd = new PersonDAO_Mock();
                    break;
                case "MsSQL":
                    pd = new PersonDAO_MsSQL();
                    break;
                case "MySql":
                    pd = new PersonDAO_MySQL();
                    break;
                case "MongoDB":
                    pd = new PersonDAO_MongoDB();
                    break;
                default:
                    break;
            }
        }
    }
}