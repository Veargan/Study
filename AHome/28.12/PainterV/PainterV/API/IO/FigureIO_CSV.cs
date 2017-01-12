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

            List<Figure> figures = CsvSerializer.DeserializeFromString<List<Figure>>(csvString);

            return CreateControlList(figures);
        }

        public override void Write(List<Control> controls)
        {
            StreamWriter fs = new StreamWriter(PathToFile);
            fs.Write(CsvSerializer.SerializeToCsv(GetListOfFigures(controls)));
            fs.Dispose();
        }

    }
}
