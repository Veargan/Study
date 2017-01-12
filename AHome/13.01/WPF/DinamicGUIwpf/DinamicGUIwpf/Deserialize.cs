using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DynamicGUI
{
    class Deserialize
    {
        static string file = @"D:\Paint.xml";
        public static Velement Load()
        {
            Velement el = null;
            XmlSerializer XML = new XmlSerializer(typeof(Velement));
            if (File.Exists(file))
            { 
                using (var stream = new FileStream(file, FileMode.Open))
                {
                    el = (Velement)XML.Deserialize(stream);
                }
            }
            return el;
        }
    }
}
