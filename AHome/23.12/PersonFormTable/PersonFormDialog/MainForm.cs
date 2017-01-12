using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonFormDialog
{
    public partial class MainForm : Form
    {
        TableModel tm = new TableModel();
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = tm.Read();
        }
        
        int counter = 0;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (counter == 0)
            { 
                tm.Update(GetPerson());
                dataGridView1.DataSource = tm.Read();
                return;
            }

            counter++;

            if (counter == 5)
            {
                counter = 0;
                tm.Create(GetPerson());
                dataGridView1.DataSource = tm.Read();
            }
        }

        private Person GetPerson()
        {
            int row = dataGridView1.CurrentCell.RowIndex;

            int id = Int32.Parse(dataGridView1[0, row].Value.ToString());
            string fName = dataGridView1[1, row].Value.ToString();
            string lName = dataGridView1[2, row].Value.ToString();
            int age = Int32.Parse(dataGridView1[3, row].Value.ToString());

            return new Person(id, fName, lName, age);
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            counter++;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            tm.Delete(GetPerson());
            dataGridView1.DataSource = tm.Read();
        }

        //private bool checkP()
        //{
        //    int row = dataGridView1.CurrentCell.RowIndex;

        //    int id = Int32.Parse(dataGridView1[0, row].Value.ToString());
        //    string fName = dataGridView1[1, row].Value.ToString();
        //    string lName = dataGridView1[2, row].Value.ToString();

        //    int k;
        //    if(Int32.TryParse(dataGridView1[3, row].Value.ToString(), out k)) return false;
        //    int age = Int32.Parse(dataGridView1[0, row].Value.ToString());

        //    if (id == 0 || fName == null || lName == null || age == 0)
        //        return true;

        //    return false;
        //}
    }
}