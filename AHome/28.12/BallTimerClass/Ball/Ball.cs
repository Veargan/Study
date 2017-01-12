using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Ball
{
    public class Ball
    {
        public float centerX { set; get; }
        public float centerY { set; get; }
        public float dx { set; get; }
        public float dy { set; get; }

        private const float difference = 3;
        private const float radius = 20;
        private Brush brush;

        public Ball(int x, int y)
        {
            centerX = x;
            centerY = y;

            Random rand = new Random();
            int r = rand.Next();
            switch (r % 4)
            {
                case 1:
                    dx = difference;
                    dy = difference;
                    break;
                case 2:
                    dx = -difference;
                    dy = difference;
                    break;
                case 3:
                    dx = -difference;
                    dy = -difference;
                    break;
                case 0:
                    dx = difference;
                    dy = -difference;
                    break;
            }

            brush = new SolidBrush(Color.FromArgb(rand.Next(255), rand.Next(50), rand.Next(50)));
        }

        public void DrawBall(Frame frame)
        {
            Graphics graphics = frame.CreateGraphics();
            graphics.FillEllipse(brush, centerX - radius, centerY - radius, radius * 2, radius * 2);
        }
        public void EraseBall(Frame frame)
        {
            Graphics graphics = frame.CreateGraphics();
            graphics.FillEllipse(new SolidBrush(frame.BackColor), centerX - radius, centerY - radius, radius * 2, radius * 2);
        }
        public void MoveBall(Frame frame, List<Ball> balls)
        {
            if (dx > 0)
            {
                if (centerX + radius + dx >= frame.Size.Width)
                {
                    dx = -dx;
                }
            }
            else if (dx < 0)
            {
                if (centerX - radius - dx <= 0)
                {
                    dx = -dx;
                }
            }
            if (dy > 0)
            {
                if (centerY + radius + dy + 20 >= frame.Size.Height)
                {
                    dy = -dy;
                }
            }
            else if (dy < 0)
            {
                if (centerY - radius - dy <= 0)
                {
                    dy = -dy;
                }
            }

            foreach (Ball ball in balls)
            {
                if (this.Equals(ball))
                    continue;

                if (Math.Sqrt(Math.Pow(centerX - ball.centerX, 2) - Math.Pow(centerY - ball.centerY, 2)) <= radius)
                {
                    dx = -dx;
                    dy = -dy;
                }
            }

            EraseBall(frame);
            centerX += dx;
            centerY += dy;
            DrawBall(frame);
        }
    }
}
