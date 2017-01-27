using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PersonForm
{
    public class PersonFile_XMLAuto : IPersonIO
    {
        string path;

        public PersonFile_XMLAuto()
        {
            this.path = @"E:\xml.txt";
        }


        public PersonFile_XMLAuto(string path)
        {
            this.path = path;
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            XmlSerializer XML = new XmlSerializer(typeof(List<Person>));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                pp = (List<Person>)XML.Deserialize(stream);
            }

            return pp;
        }

        public void Write(List<Person> pp)
        {
            using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Person>));
                xmlFormat.Serialize(fStream, pp);
            }
        }
    }
}
