using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisovalkaWpf
{
    class PictureImpl
    {
        public static IPictureIO GetInstance(string type)
        {
            IPictureIO io = null;
            string[] str = type.Split('.');
            switch (str[str.Length - 1])
            {
                case "xml":
                    io = new PictureXML(type);
                    break;
                case "csv":
                    io = new PictureCSV();
                    break;
                case "json":
                    io = new PictureJSON();
                    break;
                case "yml":
                    io = new PictureYaml();
                    break;
            }

            return io;
        }
    }
}
