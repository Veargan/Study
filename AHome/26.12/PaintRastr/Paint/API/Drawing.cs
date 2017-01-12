using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint.API
{
    public static class Drawing
    {
        public static XData data;

        public static void SetUp(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }

        public static void Draw(Graphics g, Point p1, Point p2)
        {
            switch (data.type)
            {
                case ShapeType.ELLIPSE:
                    g.DrawEllipse(new Pen(data.color, data.width), new RectangleF(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));
                    break;
                case ShapeType.RECTANGLE:
                    g.DrawRectangle(new Pen(data.color , data.width ), new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));
                    break;
                case ShapeType.CRECTANGLE:
                    g.DrawRectangle(new Pen(data.color, data.width), new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));
                    break;
                default:
                    g.DrawLine(new Pen(data.color, data.width), p1, p2);
                    break;
            }
        }
    }
}
