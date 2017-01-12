using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RisovalkaTrue
{
    class PictureCSV : IPictureIO
    {
        string path;

        public PictureCSV()
        {
            this.path = @"E:\picture_csv.txt";
        }


        public PictureCSV(string path)
        {
            this.path = path;
        }

        public List<Figures> Load()
        {
            List<Figures> pp = new List<Figures>();
            using (StreamReader r = new StreamReader(path))
            {
                pp = CsvSerializer.DeserializeFromReader<List<Figures>>(r);
            }
            return pp;
        }

        public void Save(List<Figures> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                var csv = CsvSerializer.SerializeToCsv(pp);
                sw.WriteLine(csv);
            }
        }
    }
}
