using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    class PersonFile_XMLRefl : IPersonIO
    {
        string path;

        public PersonFile_XMLRefl()
        {
            this.path = @"E:\xmlrefl.txt";
        }


        public PersonFile_XMLRefl(string path)
        {
            this.path = path;
        }

        public List<Person> Read()
        {
            List<Person> pp = new List<Person>();
            PropertyInfo propertyInfo;

            if (!File.Exists(path))
            {
                return pp;
            }

            List<string> s = new List<string>();
            List<string> sp = new List<string>();
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
                    s.Add(date2[0]);
                    sp.Add(date2[1]);
                }

            }

            for (int i = 0; i < s.Count; i += 4)
            {
                Person p = new Person();
                propertyInfo = p.GetType().GetProperty(s[i]);
                propertyInfo.SetValue(p, Convert.ToInt32(sp[i]));
                propertyInfo = p.GetType().GetProperty(s[i + 1]);
                propertyInfo.SetValue(p, sp[i + 1]);
                propertyInfo = p.GetType().GetProperty(s[i + 2]);
                propertyInfo.SetValue(p, sp[i + 2]);
                propertyInfo = p.GetType().GetProperty(s[i + 3]);
                propertyInfo.SetValue(p, Convert.ToInt32(sp[i + 3]));
                pp.Add(p);
            }
            return pp;
        }

        public void Write(List<Person> pp)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("<persons>");
                foreach (var p in pp)
                {
                    Type tt = p.GetType();
                    var ff = tt.GetProperties();                   
                    string res = "<" + tt.Name + ">\r\n";
                    foreach (var f in ff)
                    {
                        res += "\t<" + f.Name + ">" + f.GetValue(p).ToString() + "</" + f.Name + ">\r\n";
                    }
                    res += "</" + tt.Name + ">";
                    sw.WriteLine(res);
                }
                sw.WriteLine("</persons>");
            }
        }
    }
}
