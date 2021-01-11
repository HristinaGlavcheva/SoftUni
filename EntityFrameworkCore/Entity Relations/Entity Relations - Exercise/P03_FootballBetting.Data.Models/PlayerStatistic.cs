using System.Collections;
using System.Collections.Generic;

namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        public PlayerStatistic()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }
        
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public byte ScoredGoals { get; set; }

        public byte Assists { get; set; }

        public byte MinutesPlayed { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
