using _05._FootballTeamGenerator.Common;

using System;
using System.Linq;

namespace _05._FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
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

        public Stats Stats { get; }

        public double SkillLevel
            => this.Stats.AverageStats;
    }
}
