using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ball
{
    public partial class BubbleForm : Form
    {
        private Timer timer;
        private BufferedGraphics bufGraphics;
        private List<Ball> balls = new List<Ball>();

        public BubbleForm()
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
            if (balls.Count > 0)
            {
                bufGraphics.Graphics.Clear(BackColor);

                foreach (Ball ball in balls)
                {
                    ball.posX += ball.dx;
                    ball.posY += ball.dy;

                    if (ball.posX <= 0 || ball.posX + ball.width >= ClientSize.Width)
                    {
                        ball.dx = -ball.dx;
                    }
                    if (ball.posY <= 0 || ball.posY + ball.width >= ClientSize.Height)
                    {
                        ball.dy = -ball.dy;
                    }
                    
                    bufGraphics.Graphics.FillEllipse(new SolidBrush(ball.color), ball.posX, ball.posY, ball.width, ball.width);
                    bufGraphics.Render();
                }
            }
        }

        private void BubbleForm_MouseDown(object sender, MouseEventArgs e)
        {
            balls.Add(new Ball(e.X, e.Y));
        }
    }
}