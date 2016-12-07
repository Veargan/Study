using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawTree
{
    public partial class FormTree : Form
    {

        public FormTree()
        {
            InitializeComponent();
        }

        private void FormTree_Load(object sender, EventArgs e)
        {
            
        }

        private void FormTree_Click(object sender, EventArgs e)
        {
            BsTree tr = new BsTree();
            tr.Init(new int[] { 50, 25, 11, 7, 30, 27, 40, 90, 80, 110 });

            Graphics gr = this.CreateGraphics();
            tr.Draw(gr, this.Width);
        }

        //private void Draw(Graphics gr, Node root)
        //{
        //    int w = Width();
        //    int h = Height();
        //}
    }
}
