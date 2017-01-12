using System;
using System.Drawing;

namespace Ball
{
    public class Ball
    {
        public Color color;
        public int width;
        public int posX;
        public int posY;

        public int dx;
        public int dy;

        private Random rnd;

        public Ball(int x, int y)
        {
            rnd = new Random();
            color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            width = rnd.Next(30, 60);
            posX = x;
            posY = y;
            dx = rnd.Next(-10, 10);
            dy = rnd.Next(-10, 10);
        }
    }
}