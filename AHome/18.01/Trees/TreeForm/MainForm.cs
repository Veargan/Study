using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeForm
{
    public partial class MainForm : Form
    {
        TreeGUI bs = null;
        public MainForm()
        {
            InitializeComponent();
            bs = new TreeGUI();
            bs.Init(new int[] { 1, 2, 3, 0 });
        }

        private void treePanel_Paint(object sender, PaintEventArgs e)
        {
            bs.Show(treePanel);
        }

        private void treePanel_MouseClick(object sender, MouseEventArgs e)
        {
            treePanel.Invalidate();
        }
    }
}
