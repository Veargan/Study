using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace PersonForm
{
    public class PersonDAO_YamlAuto : PersonDAO_File,IPersonDAO
    {
        string path;

        public PersonDAO_YamlAuto()
        {
            this.path = @"E:\yaml.yml";
        }


        public PersonDAO_YamlAuto(string path)
        {
            this.path = path;
        }        

        override public List<Person> Read()
        {
            List<Person> pp = new List<Person>();
            var input = new StreamReader(path);
            var deserializer = new Deserializer();
            var p = deserializer.Deserialize<List<Person>>(input);
            return pp;
        }
       
        override public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {                
                var serializer = new Serializer();
                serializer.Serialize(sw, pp);
            }
        }

    }
}
