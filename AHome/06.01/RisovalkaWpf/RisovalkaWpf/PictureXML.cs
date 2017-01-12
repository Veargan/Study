using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RisovalkaWpf
{
    class PictureXML : IPictureIO
    {
        string path;
        public PictureXML()
        {
            this.path = @"E:\picture_xml.txt";
        }


        public PictureXML(string path)
        {
            this.path = path;
        }

        public List<Figures> Load()
        {
            List<Figures> pp = new List<Figures>();

            XmlSerializer XML = new XmlSerializer(typeof(List<Figures>));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                pp = (List<Figures>)XML.Deserialize(stream);
            }

            return pp;
        }

        public void Save(List<Figures> fg)
        {
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Figures>));
                xmlFormat.Serialize(fStream, fg);
            }
        }
    }
}
