using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public class PersonDAO_Yaml : PersonDAO_File,IPersonDAO
    {
        string path;

        public PersonDAO_Yaml()
        {
            this.path = @"E:\yaml.txt";
        }


        public PersonDAO_Yaml(string path)
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

            List<string> s = new List<string>();

            string[] lines = File.ReadAllLines(path);

            if (lines.Length == 0 || lines.Length == 1)
            {
                return pp;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] date = lines[i].Split(':');
                s.Add(date[1].Replace("\"", "").Replace("-", "").Trim());
            }

            for (int i = 0; i < s.Count; i += 4)
            {
                pp.Add(new Person(Convert.ToInt32(s[i]), s[i + 1], s[i + 2], Convert.ToInt32(s[i + 3])));
            }
            return pp;
        }       

        override public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("persons:");
                for (int i = 0; i < pp.Count; i++)
                {
                    sw.WriteLine(String.Format(" - id: " + pp[i].id + "\r\n firstName: " + pp[i].fname + "\r\n lastName: " + pp[i].lname + "\r\n age: " + pp[i].age));
                }
            }
        }
    }
}
