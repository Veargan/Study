using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace PersonForm
{
    public class PersonFile_YamlAuto : IPersonIO
    {
        string path;

        public PersonFile_YamlAuto()
        {
            this.path = @"E:\yaml.yml";
        }


        public PersonFile_YamlAuto(string path)
        {
            this.path = path;
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();
            var input = new StreamReader(path);
            var deserializer = new Deserializer();
            var p = deserializer.Deserialize<List<Person>>(input);
            return pp;
        }

        public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                var serializer = new Serializer();
                serializer.Serialize(sw, pp);
            }
        }

    }
}
