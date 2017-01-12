using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Ball
{
    public partial class Frame : UserControl
    {
        private List<Ball> balls = new List<Ball>();
        private Thread t;
        private Ball b;
        public Frame()
        {
            InitializeComponent();
        }

        private void PanelBall_MouseDown(object sender, MouseEventArgs e)
        {
            b = new Ball(e.X, e.Y);
            balls.Add(b);
            t = new Thread(Run);
            t.Start();
        }

        private void Run()
        {
            foreach (Ball item in balls)
            {
                b.RunBall(this);
            }
        }
    }
}