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
    public partial class SizePanel : UserControl
    {
        public int x;
        public int y;
        public int top;
        public int left;

        public SizePanel()
        {
            InitializeComponent();
            this.Tag = 0;
        }

        private void SizePanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.Tag = 1;
            x = e.X;
            y = e.Y;
            top = this.Top;
            left = this.Left;
        }

        private void SizePanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.Tag = 0;
        }

        private void SizePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Tag.Equals(1))
            {
                this.Top += e.Y - y;
                this.Left += e.X - x;
            }
        }
    }
}
