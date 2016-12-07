using System.Collections.Generic;

namespace DataBaseForms
{
    interface IPersonDAO
    {
        void Create(Person p);
        List<Person> Read();
        void Update(Person p);
        void Delete(Person p);
    }
}
