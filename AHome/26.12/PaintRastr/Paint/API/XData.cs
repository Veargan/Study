using System.Drawing;

namespace Paint
{
    public enum ShapeType : int
    {
        MULTILINE = 0,
        RECTANGLE = 1,
        ELLIPSE = 2,
        CRECTANGLE = 3,
        LINE = 4
    }

    public sealed class XData
    {
        public XData()
        {
            color = Color.Black;
            width = 1;
            PrevPoint = new Point();
            type = ShapeType.MULTILINE;
        }

        public XData(ShapeType t) : base()
        {
            type = t;
        }

        public Color color      { set; get; }
        public int width        { set; get; }
        public ShapeType type   { set; get; }
        public Point PrevPoint  { set; get; }

        public void addPosition(Point position)
        {
            PrevPoint = position;
        }
    }
}