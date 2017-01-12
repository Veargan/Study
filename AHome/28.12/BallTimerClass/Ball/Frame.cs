using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ball
{
    public partial class Frame : UserControl
    {
        private Timer timer;
        private List<Ball> balls = new List<Ball>();
        private Random rnd = new Random();

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
            foreach (Ball ball in balls)
            {
                ball.MoveBall(this, balls);
            }
        }

        private void PanelBall_MouseDown(object sender, MouseEventArgs e)
        {
            Ball b = new Ball(e.X, e.Y);
            b.DrawBall(this);
            balls.Add(b);
        }
    }
}