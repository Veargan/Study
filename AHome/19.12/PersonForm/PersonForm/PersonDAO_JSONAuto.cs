using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PersonForm
{
    public class PersonDAO_JSONAuto : PersonDAO_File,IPersonDAO
    {
        string path;

        public PersonDAO_JSONAuto()
        {
            this.path = @"E:\json.txt";
        }


        public PersonDAO_JSONAuto(string path)
        {
            this.path = path;
        }      

        override public List<Person> Read()
        {
            List<Person> pp = new List<Person>();
            using (StreamReader r = new StreamReader(@"E:\json.txt"))
            {
                string json = r.ReadToEnd();
                pp = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            return pp;
        }

        override public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                string output = JsonConvert.SerializeObject(pp);
                sw.WriteLine(output);
            }
        }

    }
}
