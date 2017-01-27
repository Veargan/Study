using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace PersonForm
{
    public class PersonFile_CSVAuto : IPersonIO
    {
        string path;

        public PersonFile_CSVAuto()
        {
            this.path = @"E:\csv.txt";
        }


        public PersonFile_CSVAuto(string path)
        {
            this.path = path;
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();
            using (StreamReader r = new StreamReader(@"E:\csv.txt"))
            {
                pp = CsvSerializer.DeserializeFromReader<List<Person>>(r);
            }
            return pp;
        }

        public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                var csv = CsvSerializer.SerializeToCsv(pp);
                sw.WriteLine(csv);
            }
        }
    }
}
