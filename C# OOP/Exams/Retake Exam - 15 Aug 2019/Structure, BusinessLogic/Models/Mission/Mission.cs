using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {
        }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            ICollection<IAstronaut> aliveAstronauts = (ICollection<IAstronaut>)astronauts.Where(a => a.CanBreath);

            while (aliveAstronauts.Any())
            {
                IAstronaut currentAstronaut = aliveAstronauts.First();

                string currentItem = planet.Items.First();

                currentAstronaut.Bag.Items.Add(currentItem); 

                planet.Items.Remove(currentItem); 

                currentAstronaut.Breath(); 

                if (!currentAstronaut.CanBreath)
                {
                    aliveAstronauts.Remove(currentAstronaut);
                }
            }

            //if (astronauts.Any())
            //{
            //    if (astronauts.Any(a => a.CanBreath))
            //    {
            //        foreach (var astronaut in astronauts.Where(a => a.CanBreath))
            //        {
            //            if (planet.Items.Any())
            //            {
            //                int countOfItems = planet.Items.Count;
            //                for (int i = 0; i < countOfItems; i++)
            //                {
            //                    string item = planet.Items.First();
            //                    astronaut.Bag.Items.Add(item);
            //                    planet.Items.Remove(item);
            //                    astronaut.Breath();
            //                    if (!astronaut.CanBreath)
            //                    {
            //                        break;
            //                    }
            //                }
            //            }

            //        }
            //    }
            //}
        }
    }
}
