
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }
        public Person GetOldestMember()
        {
            return people.FirstOrDefault(people => people.Age == GetMaxAge());
        }
        private int GetMaxAge()
        {
            return people.Max(p => p.Age);
        }
    }
}
