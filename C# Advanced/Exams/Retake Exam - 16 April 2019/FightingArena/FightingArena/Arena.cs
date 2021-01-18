using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }

        public int Count
        {
            get { return gladiators.Count; }
        }

        public void Add(Gladiator gladiator)
        {
            this.gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            this.gladiators.Remove(gladiators.FirstOrDefault(g => g.Name == name));
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int maxStatPower = 0;
            Gladiator highestStatGladiator = gladiators.FirstOrDefault();

            foreach (var gladiator in gladiators)
            {
               if( gladiator.GetStatPower() > maxStatPower)
                {
                    highestStatGladiator = gladiator;
                    maxStatPower = gladiator.GetStatPower();
                }
            }

            return highestStatGladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int maxWeaponPower = 0;
            Gladiator highestWeaponGladiator = gladiators.FirstOrDefault();

            foreach (var gladiator in gladiators)
            {
                if(gladiator.GetWeaponPower() > maxWeaponPower)
                {
                    highestWeaponGladiator = gladiator;
                    maxWeaponPower = gladiator.GetWeaponPower();
                }
            }

            return highestWeaponGladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int maxTotalPower = 0;
            Gladiator highestTotalPowerGladiator = gladiators.FirstOrDefault();

            foreach (var gladiator in gladiators)
            {
                if(gladiator.GetTotalPower() > maxTotalPower)
                {
                    highestTotalPowerGladiator = gladiator;
                    maxTotalPower = gladiator.GetTotalPower();
                }
            }

            return highestTotalPowerGladiator;
        }

        public override string ToString()
        {
            return $"[{this.Name}] - [{this.Count}] gladiators are participating.";
        }
    }
}
