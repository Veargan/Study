using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace RisovalkaTrue
{
    class PictureYaml : IPictureIO
    {
        string path;

        public PictureYaml()
        {
            this.path = @"E:\picture_yaml.yml";
        }


        public PictureYaml(string path)
        {
            this.path = path;
        }

        public List<Figures> Load()
        {
            List<Figures> pp = new List<Figures>();
            var input = new StreamReader(path);
            var deserializer = new Deserializer();
            pp = deserializer.Deserialize<List<Figures>>(input);

            return pp;
        }

        public void Save(List<Figures> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                var serializer = new Serializer();
                serializer.Serialize(sw, pp);
            }
        }
    }
}
