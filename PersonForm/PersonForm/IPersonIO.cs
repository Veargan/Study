using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonForm
{
    public interface IPersonIO
    {
        List<Person> Read();
        void Write(List<Person> lst);
    }
}
