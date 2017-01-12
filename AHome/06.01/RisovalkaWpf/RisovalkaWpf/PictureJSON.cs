using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisovalkaWpf
{
    class PictureJSON : IPictureIO
    {
        string path;

        public PictureJSON()
        {
            this.path = @"E:\picture_json.txt";
        }


        public PictureJSON(string path)
        {
            this.path = path;
        }


        public List<Figures> Load()
        {
            List<Figures> pp = new List<Figures>();
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                pp = JsonConvert.DeserializeObject<List<Figures>>(json);
            }
            return pp;
        }

        public void Save(List<Figures> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                string output = JsonConvert.SerializeObject(pp);
                sw.WriteLine(output);
            }
        }
    }
}
