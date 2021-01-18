using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }
        
        public string Name { get; set; }

        public Stat Stat { get; set; }

        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            int sum = this.Stat.Strength + this.Stat.Agility + this.Stat.Flexibility + this.Stat.Skills +
                this.Stat.Intelligence + this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;

            return sum;
        }

        public int GetWeaponPower()
        {
            int sum = this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;

            return sum;
        }

        public int GetStatPower()
        {
            int sum = this.Stat.Strength + this.Stat.Agility + this.Stat.Flexibility + this.Stat.Skills + this.Stat.Intelligence;

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"[{this.Name}] - [{this.GetTotalPower()}]");
            sb.AppendLine($"  Weapon Power: [{this.GetWeaponPower()}]");
            sb.AppendLine($"  Stat Power: [{this.GetStatPower()}]");
            
            return sb.ToString().TrimEnd();
        }
    }
}
