using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Balls
{
    public partial class Frame : UserControl
    {        
        private Timer timer;
        List<Ball> ballList = new List<Ball>();

        public Frame()
        {
            InitializeComponent();
            InitializeAndStartTimer();
        }

        private void InitializeAndStartTimer()
        {
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1;
            timer.Start();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var item in ballList)
            {
                item.MoveBall(this);
                item.Location = new Point ((int)item.centerX, (int)item.centerY);
                Controls.Add(item);
            }
        }

        private void Frame_MouseClick(object sender, MouseEventArgs e)
        {
            Ball b = new Ball(e.X, e.Y);
            b.DrawBall(this);
            ballList.Add(b);
            b.Location = new Point(e.X, e.Y); 
            Controls.Add(b);
        }
    }
}
