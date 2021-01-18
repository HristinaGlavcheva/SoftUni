using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.roster.Count; }
        }

        public void AddPlayer(Player player)
        {
            if(roster.Count < this.Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            foreach (var player in this.roster)
            {
                if(player.Name == name)
                {
                    this.roster.Remove(player);
                    return true;
                }
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player playerToPromote = this.roster.FirstOrDefault(p => p.Name == name);
            
            if(playerToPromote != null)
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player playerToDeomote = this.roster.FirstOrDefault(p => p.Name == name);

            if(playerToDeomote != null && playerToDeomote.Rank != "Trial")
            {
                playerToDeomote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classPorp)
        {
            List<Player> playersToRemove = new List<Player>();
            
            foreach (var player in this.roster)
            {
                if(player.Class == classPorp)
                {
                    playersToRemove.Add(player);
                }
            }

            roster.RemoveAll(p => p.Class == classPorp);

            return playersToRemove.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
