using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    class PersonFile_Impl
    {
        public static IPersonIO GetInstance(string type)
        {
            IPersonIO io = null;

            switch(type)
            {
                case "CSV":
                    io = new PersonFile_CSV();
                    break;
                case "JSON":
                    io = new PersonFile_JSON();
                    break;
                case "XML":
                    io = new PersonFile_XML();
                    break;
                case "Yaml":
                    io = new PersonFile_Yaml();
                    break;
                case "CSVAuto":
                    io = new PersonFile_CSVAuto();
                    break;
                case "JSONAuto":
                    io = new PersonFile_JSONAuto();
                    break;
                case "XMLAuto":
                    io = new PersonFile_XMLAuto();
                    break;
                case "YamlAuto":
                    io = new PersonFile_YamlAuto();
                    break;
            }

            return io;
        }
    }
}
