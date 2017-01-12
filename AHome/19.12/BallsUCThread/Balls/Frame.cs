using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Balls
{
    public partial class Frame : UserControl
    {        
        List<Ball> ballList = new List<Ball>();
        Thread t;
        Ball b;

        public Frame()
        {
            InitializeComponent();
            t = new Thread(Run);
            t.Start();
        }
        
        private void Run()
        {
            while (true)
            {
                Thread.Sleep(100);
                foreach (var item in ballList)
                {
                    item.MoveBall(this);
                    item.Location = new Point((int)item.centerX, (int)item.centerY);
                    Controls.Add(item);
                }
            }
        }

        private void Frame_MouseClick(object sender, MouseEventArgs e)
        {
            b = new Ball(e.X, e.Y);
            ballList.Add(b);
            b.Location = new Point(e.X, e.Y); 
            Controls.Add(b);
        }
    }
}
