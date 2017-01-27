using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class PanelWidth : UserControl
    {
        public XData data = null;
        public PanelWidth()
        {
            InitializeComponent();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            data.width = 3;
        }

        private void b1_Click(object sender, EventArgs e)
        {
            data.width = 1;
        }

        private void PanelWidth_Load(object sender, EventArgs e)
        {

        }

        private void b7_Click(object sender, EventArgs e)
        {
            data.width = 7;
        }
    }
}
