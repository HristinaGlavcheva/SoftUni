using _05._FootballTeamGenerator.Common;

using System;

namespace _05._FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int StatMinValue = 0;
        private const int StatMaxValue = 100;

        private const double StatsCount = 5.0;
        
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            { 
                return this.shooting;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double AverageStats
            => (this.Endurance + this.Sprint + this.Shooting + this.Passing + this.Dribble) / StatsCount;

        private void ValidateStat(int value, string statName)
        {
            if (value < StatMinValue || value > StatMaxValue)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatValue, statName, StatMinValue, StatMaxValue));
            }
        }
    }
}
