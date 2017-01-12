using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RisovalkaTrue
{
    public partial class SizePanel : UserControl
    {
        public int x;
        public int y;
        public int top;
        public int left;
        public int number;
        public SizePanel()
        {
            InitializeComponent();
            this.Tag = 0;

        }
        public SizePanel(int number, int height, int width)
        {
            InitializeComponent();
            this.Tag = 0;
            this.number = number;
            SetCursour();
            Loc(height, width);
        }

        public void SetCursour()
        {
            if (number == 1 || number == 8)
                this.Cursor = Cursors.SizeNWSE;
            if (number == 2 || number == 7)
                this.Cursor = Cursors.SizeNS;
            if (number == 3 || number == 6)
                this.Cursor = Cursors.SizeNESW;
            if (number == 4 || number == 5)
                this.Cursor = Cursors.SizeWE;
        }

        public void Loc(int height, int width)
        {

            Control c = Parent as Control;
            switch(number)
            {
                case 1:
                    Location = new Point(0, 0);
                    break;
                case 2:
                    Location = new Point(width / 2 - Width / 2, 0);
                    break;
                case 3:
                    Location = new Point(width - Width, 0);
                    break;
                case 4:
                    Location = new Point(0, height / 2 - Height / 2);
                    break;
                case 5:
                    Location = new Point(width - Width, height / 2 - Height / 2);
                    break;
                case 6:
                    Location = new Point(0, height - Height);
                    break;
                case 7:
                    Location = new Point(width / 2 - Width / 2, height - Height);
                    break;
                case 8:
                    Location = new Point(width - Width, height - Height);
                    break;
            }
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
            SizePanelReLoc();
        }

        private void SizePanelReLoc()
        {
            int w = this.Width;
            Control c = Parent as Control;
            if (number == 1)
            {
                c.Top += this.Top - this.top;
                c.Left += this.Left - this.left;
                c.Width += this.left - this.Left;
                c.Height += this.top - this.Top;
            }

            if (number == 2)
            {
                c.Top += this.Top - this.top;
                c.Height += this.top - this.Top;
            }

            if (number == 3)
            {
                c.Top += this.Top - this.top;
                c.Width = this.Left + w;
                c.Height += this.top - this.Top;
            }

            if (number == 4)
            {
                c.Left += this.Left - this.left;
                c.Width += this.left - this.Left;
            }

            if (number == 5)
            {
                c.Width = this.Left + w;
            }

            if (number == 6)
            {
                c.Height = this.Top + w;
                c.Left += this.Left - this.left;
                c.Width += this.left - this.Left;
            }

            if (number == 7)
            {
                c.Height = this.Top + w;
            }

            if (number == 8)
            {
                c.Height = this.Top + w;
                c.Width = this.Left + w;

            }
        }
    }
}
