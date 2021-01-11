using P03.Raiding.Factories;
using P03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Raiding.Core
{
    public class Engine
    {
        private HeroFactory heroFactory;

        public Engine()
        {
            this.heroFactory = new HeroFactory();
        }

        public void Run()
        {
            List<BaseHero> raidingGroup = new List<BaseHero>();
            
            int countHeros = int.Parse(Console.ReadLine());

            while (raidingGroup.Count < countHeros)
            {
                try
                {
                    string name = Console.ReadLine();
                    string type = Console.ReadLine();

                    BaseHero hero = this.heroFactory.CreateHero(name, type);

                    Console.WriteLine(hero.CastAbility());

                    raidingGroup.Add(hero);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            if(raidingGroup.Sum(h => h.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
