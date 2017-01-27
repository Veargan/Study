using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    class TableModel
    {
        private IPersonDAO2 db = null;
        PersonDAO_Impl2 imp = new PersonDAO_Impl2();
        public void SetDB(string type)
        {
            db = imp.GetInstance(type);
        }

        public void Create(Person p)
        {
            db.Create(p);
        }
        public DataTable Read()
        {
            DataTable dt = new DataTable();
            var pp = db.Read();

            dt.Columns.Add("Id");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Age");
            for (int i = 0; i < pp.Count; i++)
            {
                string[] str = { Convert.ToString(pp[i].id), pp[i].fname, pp[i].lname, Convert.ToString(pp[i].age) };
                dt.Rows.Add(str);
            }
            return dt;
        }
        public void Update(Person p)
        {
            db.Update(p);
        }
        public void Delete(Person p)
        {
            db.Delete(p);
        }
    }
}
