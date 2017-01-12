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
    public partial class CrudDialog : Form
    {
        public CrudDialog()
        {
            InitializeComponent();
        }

        public CrudDialog(string type)
        {
            InitializeComponent();
            SetTB(type);
        }

        private void SetTB(string type)
        {
            switch (type)
            {
                case "delete":
                    tbId.ReadOnly = true;
                    tbName.ReadOnly = true;
                    tbLast.ReadOnly = true;
                    tbAge.ReadOnly = true;
                    break;
                case "update":
                    tbId.ReadOnly = true;
                    break;
                default:
                    break;
            }
        }

        public void SetPerson(Person p)
        {
            tbId.Text = p.id.ToString();
            tbName.Text = p.fname;
            tbLast.Text = p.lname;
            tbAge.Text = p.age.ToString();
        }

        public Person GetPerson()
        {
            int id = Int32.Parse(tbId.Text);
            string name = tbName.Text;
            string last = tbLast.Text;
            int age = Int32.Parse(tbAge.Text);

            return new Person(id, name, last, age);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.DialogResult = DialogResult.Cancel;
        }
    }
}
