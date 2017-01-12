using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonFormDialog
{
    class TableModel
    {
        private IPersonDAO db = new PersonDAOMock();

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

        public void SetValueAt(int id, Object obj)
        {
            var pp = db.Read();
        }
    }
}