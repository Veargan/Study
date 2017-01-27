using System.Collections.Generic;

namespace People
{
    public interface IPersonDAO
    {
        void Create(Person p);
        List<Person> Read();
        void Update(Person p);
        void Delete(Person p);
    }
}
