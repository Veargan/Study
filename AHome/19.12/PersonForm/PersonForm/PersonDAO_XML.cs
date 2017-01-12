using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public class PersonDAO_XML : PersonDAO_File,IPersonDAO
    {
        string path;

        public PersonDAO_XML()
        {
            this.path = @"E:\xml.txt";
        }


        public PersonDAO_XML(string path)
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
            System.Text.RegularExpressions.Regex r1 = new System.Text.RegularExpressions.Regex("<[A-Za-z]*>");
            System.Text.RegularExpressions.Regex r2 = new System.Text.RegularExpressions.Regex("</[A-Za-z]*>");
            string[] lines = File.ReadAllLines(path);

            if (lines.Length == 0 || lines.Length == 2)
            {
                return pp;
            }

            for (int i = 1; i < lines.Length - 1; i++)
            {
                if (r1.IsMatch(lines[i]) && r2.IsMatch(lines[i]))
                {
                    string[] date1 = lines[i].Split('<');
                    string[] date2 = date1[1].Split('>');
                    s.Add(date2[1]);
                }

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
                sw.WriteLine("<persons>");
                for (int i = 0; i < pp.Count; i++)
                {
                    sw.WriteLine(String.Format(" <person>\r\n" + "\t<id>" + pp[i].id + "</id>\r\n\t<firstName>" + pp[i].fname + "</firstName>\r\n\t<lastName>" + pp[i].lname + "</lastName>\r\n\t<age>" + pp[i].age + "</age>" + "\r\n </person>"));
                }
                sw.WriteLine("</persons>");
            }
        }
    }
}
