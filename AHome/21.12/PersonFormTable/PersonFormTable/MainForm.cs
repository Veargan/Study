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
                int id = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string fName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string lName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                int age = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                tm.Update(new Person(id, fName, lName, age));
                dataGridView1.DataSource = tm.Read();
                return;
            }

            counter++;
            
            if (counter == 5)
            {
                counter = 0;
                int i = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string f = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string l = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                int a = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                tm.Create(new Person(i, f, l, a));
                dataGridView1.DataSource = tm.Read();
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            counter++;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = Int32.Parse(dataGridView1.Rows[e.Row.Index].Cells[0].Value.ToString());
            string fName = dataGridView1.Rows[e.Row.Index].Cells[1].Value.ToString();
            string lName = dataGridView1.Rows[e.Row.Index].Cells[2].Value.ToString();
            int age = Int32.Parse(dataGridView1.Rows[e.Row.Index].Cells[3].Value.ToString());

            tm.Delete(new Person(id, fName, lName, age));
            dataGridView1.DataSource = tm.Read();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("" + dataGridView1.CurrentRow + " | " + dataGridView1.CurrentCell.Value.ToString());
        }
    }
}