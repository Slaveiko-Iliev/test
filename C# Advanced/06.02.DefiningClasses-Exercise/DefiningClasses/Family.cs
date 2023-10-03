using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members = new();

        public List<Person> Members { get; set; }

        public Family()
        {
            Members = members;
        }

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            List<Person> orderedMembers = members.OrderByDescending(member => member.Age).ToList();
            Person oldestPerson = orderedMembers.First();
            return oldestPerson;
        }
    }
}
