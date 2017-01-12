using Newtonsoft.Json;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Painter.Vector
{
    [JsonObject("Figure")]
    [Serializable]
    public class Figure : IFigure
    {
        [JsonProperty("ClientRect")]
        [XmlElement("ClientRect")]
        public Rectangle Bounds { get; set; }
        [JsonProperty("PenWidth")]
        [XmlElement("PenWidth")]
        public float PenWidth { get; set; }
        [JsonProperty("Color")]
        [XmlElement("Color")]
        public int Color { get; set; }
        [JsonProperty("Path")]
        [XmlElement("Path")]
        public PointF[] Path { get; set; }
        [JsonProperty("ShapeType")]
        [XmlElement("ShapeType")]
        public ShapeType ShapeType { get; set; }
    }
}
