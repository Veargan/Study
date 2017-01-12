using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public class PersonDAO_CSV : PersonDAO_File,IPersonDAO
    {
        string path;

        public PersonDAO_CSV()
        {
            this.path = @"E:\tests\csvdn.txt";
        }


        public PersonDAO_CSV(string path)
        {
            this.path = path;
        }
       
        override public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            if (!File.Exists(path))
            {
                return pp;
            }

            string[] lines = File.ReadAllLines(path);

            if(lines.Length == 0 || lines.Length == 1)
            {
                return pp;
            }

            foreach (var line in lines)
            {
                string[] date = line.Split(',');
                if(date[0] == "id")
                {
                    continue;
                }
                pp.Add(new Person(Convert.ToInt32(date[0]), date[1], date[2], Convert.ToInt32(date[3])));
            }

            return pp;
        }

        override public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("id,fname,lname,age");
                for (int i = 0; i < pp.Count; i++)
                {
                    sw.WriteLine(String.Format(pp[i].id + "," + pp[i].fname + "," + pp[i].lname + "," + pp[i].age));
                }
            }          
        }
    }
}
