using _05._FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace _05._FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public IReadOnlyCollection<Player> Players
            => this.players.AsReadOnly();

        public int Rating
        {
            get
            {
                if(this.players.Count == 0)
                {
                    return 0;
                }
                
                return (int)Math.Round(this.players.Average(p => p.SkillLevel));
            }
        }

        public SerializationInfo ExceptionMessage { get; private set; }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MissingPlayer, playerName, this.Name));
            }

            this.players.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
