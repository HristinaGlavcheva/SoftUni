using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            this.members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        //public Person GetOldestMember()
        //{
        //    Person oldestMember = this.members
        //        .OrderByDescending(m => m.Age)
        //        .FirstOrDefault();

        //    return oldestMember;
        //}

        public Person GetOldestMember() =>         
            members.OrderByDescending(m => m.Age).FirstOrDefault();
    }
}
