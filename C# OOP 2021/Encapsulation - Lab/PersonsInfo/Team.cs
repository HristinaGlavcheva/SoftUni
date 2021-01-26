using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;

            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name { get; }

        public IReadOnlyCollection<Person> FirstTeam =>
            this.firstTeam.AsReadOnly();

        public IReadOnlyCollection<Person> ReserveTeam =>
            this.reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if(person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
