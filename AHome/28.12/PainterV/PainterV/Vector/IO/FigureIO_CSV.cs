using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using System.IO;
using System.Windows.Forms;
using Painter.UserControls.VectorElements.Figures;

namespace Painter.Vector
{
    public class FigureIO_CSV : FigureIO
    {
        public FigureIO_CSV()
        {
            PathToFile = "";
        }
        public FigureIO_CSV(string path)
        {
            PathToFile = path;
        }

        public override List<Control> Read()
        {
            StreamReader fs = new StreamReader(PathToFile);
            string csvString = fs.ReadToEnd();
            fs.Dispose();

            string[] figures = csvString.Split('^');
            List<FigureLine> lines = CsvSerializer.DeserializeFromString<List<FigureLine>>(figures[0]);
            List<FigureEllipse> ellipses = CsvSerializer.DeserializeFromString<List<FigureEllipse>>(figures[1]);
            List<FigureRectangle> rects = CsvSerializer.DeserializeFromString<List<FigureRectangle>>(figures[2]);
            List<FigureCurvedRectangle> cRects = CsvSerializer.DeserializeFromString<List<FigureCurvedRectangle>>(figures[3]);
            List<FigureMultiline> multilines = CsvSerializer.DeserializeFromString<List<FigureMultiline>>(figures[4]);

            return CreateControlList(lines, ellipses, rects, cRects, multilines);
        }

        public override void Write(List<Control> controls)
        {
            StreamWriter fs = new StreamWriter(PathToFile);
            fs.Write(CsvSerializer.SerializeToCsv(GetListOfLines(controls)));
            fs.WriteLine("^");
            fs.Write(CsvSerializer.SerializeToCsv(GetListOfEllipses(controls)));
            fs.WriteLine("^");
            fs.Write(CsvSerializer.SerializeToCsv(GetListOfRects(controls)));
            fs.WriteLine("^");
            fs.Write(CsvSerializer.SerializeToCsv(GetListOfCurvedRects(controls)));
            fs.WriteLine("^");
            fs.Write(CsvSerializer.SerializeToCsv(GetListOfMultilines(controls)));
            fs.Dispose();
        }

    }
}
