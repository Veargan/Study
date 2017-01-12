using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace PersonForm
{
    public class PersonDAO_CSVAuto : PersonDAO_File,IPersonDAO
    {
        string path;

        public PersonDAO_CSVAuto()
        {
            this.path = @"E:\csv.txt";
        }


        public PersonDAO_CSVAuto(string path)
        {
            this.path = path;
        }       

        override public List<Person> Read()
        {
            List<Person> pp = new List<Person>();
            using (StreamReader r = new StreamReader(@"E:\csv.txt"))
            {
                pp = CsvSerializer.DeserializeFromReader<List<Person>>(r);
            }
            return pp;
        }

        override public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                var csv = CsvSerializer.SerializeToCsv(pp);
                sw.WriteLine(csv);
            }
        }
    }
}
