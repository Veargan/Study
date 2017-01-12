using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;
using YamlDotNet.Serialization;

namespace Painter.Vector
{
    public class FigureIO_YML : FigureIO
    {
        public FigureIO_YML()
        {
            PathToFile = "";
        }
        public FigureIO_YML(string path)
        {
            PathToFile = path;
        }


        public override List<Control> Read()
        {
            Deserializer serializer = new Deserializer();
            StreamReader fs = new StreamReader(PathToFile);
            string ymlString = fs.ReadToEnd();
            fs.Dispose();

            string[] figures = ymlString.Split('^');
            List<FigureLine> lines = serializer.Deserialize<List<FigureLine>>(figures[0]);
            List<FigureEllipse> ellipses = serializer.Deserialize<List<FigureEllipse>>(figures[1]);
            List<FigureRectangle> rects = serializer.Deserialize<List<FigureRectangle>>(figures[2]);
            List<FigureCurvedRectangle> cRects = serializer.Deserialize<List<FigureCurvedRectangle>>(figures[3]);
            List<FigureMultiline> multilines = serializer.Deserialize<List<FigureMultiline>>(figures[4]);

            return CreateControlList(lines, ellipses, rects, cRects, multilines);
        }

        public override void Write(List<Control> controls)
        {
            Serializer serializer = new Serializer();
            StreamWriter fs = new StreamWriter(PathToFile);
            fs.Write(serializer.Serialize(GetListOfLines(controls)));
            fs.WriteLine("^");
            fs.Write(serializer.Serialize(GetListOfEllipses(controls)));
            fs.WriteLine("^");
            fs.Write(serializer.Serialize(GetListOfRects(controls)));
            fs.WriteLine("^");
            fs.Write(serializer.Serialize(GetListOfCurvedRects(controls)));
            fs.WriteLine("^");
            fs.Write(serializer.Serialize(GetListOfMultilines(controls)));
            fs.Dispose();
        }

    }
}
