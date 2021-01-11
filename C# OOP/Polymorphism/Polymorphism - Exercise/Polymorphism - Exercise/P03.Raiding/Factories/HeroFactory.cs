using P03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Raiding.Factories
{
    public class HeroFactory
    {
        public BaseHero CreateHero(string name, string type)
        {
            BaseHero hero = null;
            
            if (type == "Druid")
            {
                hero = new Druid(name, type);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name, type);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name, type);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name, type);
            }

            if (hero == null)
            {
                throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
