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

            List<Figure> figures = serializer.Deserialize<List<Figure>>(ymlString);

            return CreateControlList(figures);
        }

        public override void Write(List<Control> controls)
        {
            Serializer serializer = new Serializer();
            StreamWriter fs = new StreamWriter(PathToFile);
            fs.Write(serializer.Serialize(GetListOfFigures(controls)));
            fs.Dispose();
        }

    }
}
