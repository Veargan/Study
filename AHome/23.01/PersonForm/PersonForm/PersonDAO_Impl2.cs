using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public class PersonDAO_Impl2
    {
        List<IPersonDAO2> pd = new List<IPersonDAO2>();

        public PersonDAO_Impl2()
        {
            Assembly thisExe = Assembly.GetExecutingAssembly();
            var types = thisExe.GetTypes();
            foreach (var i in types)
            {

                if (i.BaseType == typeof(IPersonDAO2))
                {
                    if (i.Name == "PersonDAOMock")
                    {
                        pd.Add(new PersonDAOMock());
                    }
                    if (i.Name == "PersonDAO_File")
                    {
                        pd.Add(new PersonDAO_File("CSV"));
                        pd.Add(new PersonDAO_File("JSON"));
                        pd.Add(new PersonDAO_File("XML"));
                        pd.Add(new PersonDAO_File("Yaml"));
                        pd.Add(new PersonDAO_File("CSVAuto"));
                        pd.Add(new PersonDAO_File("JSONAuto"));
                        pd.Add(new PersonDAO_File("XMLAuto"));
                        pd.Add(new PersonDAO_File("YamlAuto"));
                        pd.Add(new PersonDAO_File("XMLRefl"));
                        continue;
                    }
                    var p = (IPersonDAO2)Activator.CreateInstance(i);
                }                                        
            }          
        }

        public IPersonDAO2 GetInstance(string type)
        {
            IPersonDAO2 ppd = null;

            foreach (var p in pd)
            {
                if (p.IsType(type))
                {
                    ppd = p;
                    break;
                }
            }

            return ppd;
        }
    }
}
