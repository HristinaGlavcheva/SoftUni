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

        public HashSet<Person> GetOlderTnahThirty()
        {
            members = this.members
                .Where(p => p.Age >= 30)
                .OrderBy(p => p.Name)
                .ToHashSet();

            return members;
        }
    }
}
