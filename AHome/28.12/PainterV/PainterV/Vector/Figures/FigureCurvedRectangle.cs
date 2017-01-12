using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Painter.Vector
{
    [JsonObject("CurvedRectangle")]
    [Serializable]
    public class FigureCurvedRectangle : IFigure
    {
        [JsonProperty("X")]
        [XmlElement("X")]
        public int X { get; set; }
        [JsonProperty("Y")]
        [XmlElement("Y")]
        public int Y { get; set; }
        [JsonProperty("Width")]
        [XmlElement("Width")]
        public int Width { get; set; }
        [JsonProperty("Height")]
        [XmlElement("Height")]
        public int Height { get; set; }
        [JsonProperty("PenWidth")]
        [XmlElement("PenWidth")]
        public float PenWidth { get; set; }
        [JsonProperty("Color")]
        [XmlElement("Color")]
        public Color Color { get; set; }
        [JsonProperty("ShapeType")]
        [XmlElement("ShapeType")]
        public ShapeType ShapeType { get; set; }
    }
}
