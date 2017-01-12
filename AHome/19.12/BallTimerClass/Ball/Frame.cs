using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ball
{
    public partial class Frame : UserControl
    {
        private Timer timer;
        private BufferedGraphics bufGraphics;
        private List<Ball> balls = new List<Ball>();
        private Random rnd = new Random();

        public Frame()
        {
            InitializeComponent();
            InitializeAndStartTimer();
            BufferedGraphicsContext context = new BufferedGraphicsContext();
            bufGraphics = context.Allocate(CreateGraphics(), this.ClientRectangle);
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
                ball.MoveBall(this);
            }
        }

        private void PanelBall_MouseDown(object sender, MouseEventArgs e)
        {
            balls.Add(new Ball(e.X, e.Y));
        }
    }
}