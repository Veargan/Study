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
    public partial class UpdateDialog : Form
    {
        public UpdateDialog()
        {
            InitializeComponent();
        }

        public void SetPerson(Person p)
        {
            tbId.Text = p.id.ToString();
            tbFName.Text = p.fname;
            tbLName.Text = p.lname;
            tbAge.Text = p.age.ToString();
        }

        public Person GetPerson()
        {
            int id = Int32.Parse(tbId.Text);
            string fname = tbFName.Text;
            string lname = tbLName.Text;
            int age = Int32.Parse(tbAge.Text);

            return new Person(id, fname, lname, age);
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(tId.Text);
            string fname = tFname.Text;
            string lname = tLname.Text;
            int age = Int32.Parse(tAge.Text);
            bOk.DialogResult = DialogResult.OK;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            bCancel.DialogResult = DialogResult.Cancel;
        }
    }
}