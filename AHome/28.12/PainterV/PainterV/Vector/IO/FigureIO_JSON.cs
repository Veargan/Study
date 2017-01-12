using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;

namespace Painter.Vector
{
    public class FigureIO_JSON : FigureIO
    {
        public FigureIO_JSON()
        {
            PathToFile = "";
        }
        public FigureIO_JSON(string path)
        {
            PathToFile = path;
        }


        public override List<Control> Read()
        {
            StreamReader fs = new StreamReader(PathToFile);
            string jsonString = fs.ReadToEnd();
            fs.Dispose();

            string[] figures = jsonString.Replace("][", "]^[").Split('^');
            List<FigureLine> lines = JsonConvert.DeserializeObject<List<FigureLine>>(figures[0]);
            List<FigureEllipse> ellipses = JsonConvert.DeserializeObject<List<FigureEllipse>>(figures[1]);
            List<FigureRectangle> rects = JsonConvert.DeserializeObject<List<FigureRectangle>>(figures[2]);
            List<FigureCurvedRectangle> cRects = JsonConvert.DeserializeObject<List<FigureCurvedRectangle>>(figures[3]);
            List<FigureMultiline> multilines = JsonConvert.DeserializeObject<List<FigureMultiline>>(figures[4]);

            return CreateControlList(lines, ellipses, rects, cRects, multilines);
        }

        public override void Write(List<Control> controls)
        {
            StreamWriter fs = new StreamWriter(PathToFile);
            fs.Write(JsonConvert.SerializeObject(GetListOfLines(controls)));
            fs.Write(JsonConvert.SerializeObject(GetListOfEllipses(controls)));
            fs.Write(JsonConvert.SerializeObject(GetListOfRects(controls)));
            fs.Write(JsonConvert.SerializeObject(GetListOfCurvedRects(controls)));
            fs.Write(JsonConvert.SerializeObject(GetListOfMultilines(controls)));
            fs.Dispose();
        }

    }
}
