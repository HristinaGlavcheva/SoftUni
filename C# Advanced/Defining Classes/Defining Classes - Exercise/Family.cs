using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private HashSet<Person> members;

        public Family()
        {
            this.members = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = this.members
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();

            //int maxAge = 0;
            //Person oldestPerson = null;
            //List<Person> members = this.members;

            //foreach (var member in members)
            //{
            //    if(member.Age > maxAge)
            //    {
            //        oldestPerson = member;
            //        maxAge = member.Age;
            //    }
            //}

            return oldestPerson;
        }
    }
}
