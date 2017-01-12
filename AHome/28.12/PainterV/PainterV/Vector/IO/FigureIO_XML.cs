using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;
using System.Xml.Serialization;
using System.Xml;

namespace Painter.Vector
{
    public class FigureIO_XML : FigureIO
    {
        public FigureIO_XML()
        {
            PathToFile = "";
        }
        public FigureIO_XML(string path)
        {
            PathToFile = path;
        }


        public override List<Control> Read()
        {
            XmlSerializer serializerL = new XmlSerializer(typeof(List<FigureLine>));
            XmlSerializer serializerE = new XmlSerializer(typeof(List<FigureEllipse>));
            XmlSerializer serializerR = new XmlSerializer(typeof(List<FigureRectangle>));
            XmlSerializer serializerCR = new XmlSerializer(typeof(List<FigureCurvedRectangle>));
            XmlSerializer serializerML = new XmlSerializer(typeof(List<FigureMultiline>));

            StreamReader fs = new StreamReader(PathToFile);

            XmlReader reader = XmlReader.Create(fs);
            List<FigureLine> lines = (List<FigureLine>)serializerL.Deserialize(reader);
            List<FigureEllipse> ellipses = (List<FigureEllipse>)serializerL.Deserialize(reader);
            List<FigureRectangle> rects = (List<FigureRectangle>)serializerL.Deserialize(reader);
            List<FigureCurvedRectangle> cRects = (List<FigureCurvedRectangle>)serializerL.Deserialize(reader);
            List<FigureMultiline> multilines = (List<FigureMultiline>)serializerL.Deserialize(reader);
            reader.Dispose();
            fs.Dispose();

            return CreateControlList(lines, ellipses, rects, cRects, multilines);
        }

        public override void Write(List<Control> controls)
        {
            XmlSerializer serializerL = new XmlSerializer(typeof(List<FigureLine>));
            XmlSerializer serializerE = new XmlSerializer(typeof(List<FigureEllipse>));
            XmlSerializer serializerR = new XmlSerializer(typeof(List<FigureRectangle>));
            XmlSerializer serializerCR = new XmlSerializer(typeof(List<FigureCurvedRectangle>));
            XmlSerializer serializerML = new XmlSerializer(typeof(List<FigureMultiline>));
            StreamWriter fs = new StreamWriter(PathToFile);
            serializerL.Serialize(fs, GetListOfLines(controls));
            fs.WriteLine("^");
            serializerE.Serialize(fs, GetListOfEllipses(controls));
            fs.WriteLine("^");
            serializerR.Serialize(fs, GetListOfRects(controls));
            fs.WriteLine("^");
            serializerCR.Serialize(fs, GetListOfCurvedRects(controls));
            fs.WriteLine("^");
            serializerML.Serialize(fs, GetListOfMultilines(controls));
            fs.Dispose();
        }

    }
}
