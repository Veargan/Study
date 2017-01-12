using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public abstract class IPersonDAO2
    {
        protected string str = "";
        public bool IsType(string type)
        {
            bool ret = false;
            if (str.Equals(type))
            {
                ret = true;
            }
            return ret;
        }
        public abstract void Create(Person p);
        public abstract List<Person> Read();
        public abstract void Update(Person p);
        public abstract void Delete(Person p);
    }
}
