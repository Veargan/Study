using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RisovalkaWpf
{
    /// <summary>
    /// Interaction logic for SizePanel.xaml
    /// </summary>
    public partial class SizePanel : UserControl
    {
        public int x;
        public int y;
        public double top;
        public double left;
        public int number;
        Point prev;
        bool flag = false;
        public SizePanel()
        {
            InitializeComponent();
            this.Tag = 0;

        }
        public SizePanel(int number, double height, double width)
        {
            InitializeComponent();
            this.Tag = 0;
            this.number = number;
            SetCursour();
            this.Background = new SolidColorBrush(Colors.Black);
            this.Width = 10;
            this.Height = 10;
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

        private void SizePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                Point pt = Mouse.GetPosition(canvas);
                //this.Margin = new Thickness(this.Margin.Top + (pt.Y - prev.Y), this.Margin.Left + (pt.X - prev.X), this.Margin.Right, this.Margin.Bottom);
                SizePanelReLoc();
            }          
        }

        private void SizePanelReLoc()
        {
            //int w = this.Width;
            //var p = Parent;

           // System.Windows.Controls.Canvas c = Parent as System.Windows.Controls.Canvas;
            //if (number == 1)
            //{
            //    c.Margin = new Thickness(this.Margin.Top - this.top, this.Margin.Left - this.left, this.Margin.Right, this.Margin.Bottom);
            //    //c.Top += this.Top - this.top;
            //    //c.Left += this.Left - this.left;
            //    c.Width += this.left - this.Margin.Left;
            //    c.Height += this.top - this.Margin.Top;
            //}

            //if (number == 2)
            //{
            //    c.Top += this.Top - this.top;
            //    c.Height += this.top - this.Top;
            //}

            //if (number == 3)
            //{
            //    c.Top += this.Top - this.top;
            //    c.Width = this.Left + w;
            //    c.Height += this.top - this.Top;
            //}

            //if (number == 4)
            //{
            //    c.Left += this.Left - this.left;
            //    c.Width += this.left - this.Left;
            //}

            //if (number == 5)
            //{
            //    c.Width = this.Left + w;
            //}

            //if (number == 6)
            //{
            //    c.Height = this.Top + w;
            //    c.Left += this.Left - this.left;
            //    c.Width += this.left - this.Left;
            //}

            //if (number == 7)
            //{
            //    c.Height = this.Top + w;
            //}

            //if (number == 8)
            //{
            //    c.Height = this.Top + w;
            //    c.Width = this.Left + w;

            //}
        }

        private void SizePanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Tag = 0;
            flag = false;
        }

        private void SizePanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            flag = true;
            this.Tag = 1;
            prev = Mouse.GetPosition(canvas);
            top = this.Margin.Top;
            left = this.Margin.Left;
        }
    }
}
