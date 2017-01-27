using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public class PersonFile_JSON : IPersonIO
    {
        string path;

        public PersonFile_JSON()
        {
            this.path = @"E:\tests\jsoncm.txt";
        }


        public PersonFile_JSON(string path)
        {
            this.path = path;
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();

            if (!File.Exists(path))
            {
                return pp;
            }

            List<string> s = new List<string>();

            string[] lines = File.ReadAllLines(path);

            if (lines.Length == 0 || lines[0] == "{}")
            {
                return pp;
            }

            string[] date = lines[0].Split(':');
            for (int i = 1; i < date.Length; i += 4)
            {
                s.Add(date[i].Replace("\"", "").Replace(",", "").Replace("firstName", "").Trim());
                s.Add(date[i + 1].Replace("\"", "").Replace(",", "").Replace("lastName", "").Replace("\"", "").Trim());
                s.Add(date[i + 2].Replace("\"", "").Replace(",", "").Replace("age", "").Trim());
                s.Add(date[i + 3].Replace("\"", "").Replace("}", "").Replace(",", "").Replace("{", "").Replace("id", "").Trim());
            }

            for (int i = 0; i < s.Count; i += 4)
            {
                pp.Add(new Person(Convert.ToInt32(s[i]), s[i + 1], s[i + 2], Convert.ToInt32(s[i + 3])));
            }
            return pp;
        }

        public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write('{');
                sw.Write("{\"id\": " + pp[0].id + ",\"firstName\": \"" + pp[0].fname + "\",\"lastName\": \"" + pp[0].lname + "\",\"age\": " + pp[0].age + "}");
                for (int i = 1; i < pp.Count; i++)
                {
                    sw.Write(String.Format(",{\"id\": " + pp[i].id + ",\"firstName\": \"" + pp[i].fname + "\",\"lastName\": \"" + pp[i].lname + "\",\"age\": " + pp[i].age + "}"));
                }
                sw.Write('}');
            }
        }
    }
}
