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
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            CrudDialog d = new CrudDialog("");
            if (d.ShowDialog(this) == DialogResult.OK)
            {
                tm.Create(d.GetPerson());
            }
            d.Dispose();
        } 

        private void bRead_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tm.Read();
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            
            CrudDialog d = new CrudDialog("update");
            d.SetPerson(ReadPerson());

            if (d.ShowDialog(this) == DialogResult.OK)
            {
                tm.Update(d.GetPerson());
            }
            d.Dispose();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            CrudDialog d = new CrudDialog("delete");
            d.SetPerson(ReadPerson());

            if (d.ShowDialog(this) == DialogResult.OK)
            {
                tm.Delete(d.GetPerson());
            }
            d.Dispose();
        }

        private Person ReadPerson()
        {
            int row = dataGridView1.SelectedRows[0].Cells[0].RowIndex;
            int id = Int32.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
            string fname = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string lname = dataGridView1.Rows[row].Cells[2].Value.ToString();
            int age = Int32.Parse(dataGridView1.Rows[row].Cells[3].Value.ToString());

            return new Person(id, fname, lname, age);
        }
    }
}
