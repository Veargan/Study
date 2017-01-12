using System;
using System.Drawing;
using System.Threading;

namespace Ball
{
    public class Ball
    {
        public int posX;
        public int posY;

        public Color color;
        public int width;
        public int dx;
        public int dy;

        private Random rnd;

        public Ball(int x, int y)
        {
            posX = x;
            posY = y;

            rnd = new Random();
            color = Color.DarkSlateBlue;
            width = rnd.Next(40, 70);
            dx = rnd.Next(-8, 8);
            dy = rnd.Next(-8, 8);
        }

        public void DrawBall(Frame frame)
        {
            Graphics gr = frame.CreateGraphics();
            gr.FillEllipse(new SolidBrush(color), posX, posY, width, width);
        }
        public void EraseBall(Frame frame)
        {
            Graphics gr = frame.CreateGraphics();
            gr.FillEllipse(new SolidBrush(frame.BackColor), posX, posY, width, width);
        }
        public void MoveBall(Frame frame)
        {
            EraseBall(frame);
            posX += dx;
            posY += dy;

            if (posX <= 0 || posX + width >= frame.Width)
            {
                dx = -dx;
                width -= 2;
                color = Color.FromArgb(rnd.Next(200, 255), rnd.Next(0, 100), rnd.Next(0, 100));
            }
            if (posY <= 0 || posY + width >= frame.Height)
            {
                dy = -dy;
                width -= 2;
                color = Color.FromArgb(rnd.Next(0, 50), rnd.Next(0, 50), rnd.Next(200, 255));
            }
            DrawBall(frame);
        }

        public void RunBall(Frame frame)
        { 
            while (true)
            {
                Thread.Sleep(50);
                MoveBall(frame);
            }
        }
    }
}
