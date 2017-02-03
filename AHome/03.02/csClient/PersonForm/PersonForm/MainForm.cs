using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonForm
{
    public partial class MainForm : Form
    {
        TableModel tm = new TableModel();
        public MainForm()
        {
            InitializeComponent();
            tm.SetDB("TCP");
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
            string firstName = textBox2.Text;
            string lastName = textBox3.Text;
            int age = Convert.ToInt32(textBox4.Text);
            return new Person(id, firstName, lastName, age);
        }
    }
}
