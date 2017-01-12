using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    public class Ball
    {
        public Color color;
        public int width;
        public int posX { get; set; }
        public int posY { get; set; }

        public int dx;
        public int dy;
        public int speed;


        public Ball()
        {
            color = Color.Black;
            width = 30;
            posX = 0;
            posY = 0;
            dx = 3;
            dy = 3;
            speed = 10;
        }

        public Ball(int x, int y)
        {
            color = Color.Black;
            width = 30;
            posX = x;
            posY = y;
            dx = 3;
            dy = 3;
            speed = 10;
        }

        public void SetDirectionVector(int x, int y)
        {
            dx = (x - posX) / speed;
            dy = (y - posY) / speed;
        }

    }
}
