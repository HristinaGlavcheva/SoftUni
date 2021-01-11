using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronauts;
        private readonly IRepository<IPlanet> planets;
        private readonly IMission mission;
        
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.mission = new Mission();
        }

        private int Counter { get; set; } = 0;

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;

            if(type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if(type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronauts.Add(astronaut);

            string result = string.Format(OutputMessages.AstronautAdded, type, astronautName);

            return result;
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planets.Add(planet);

            string result = string.Format(OutputMessages.PlanetAdded, planetName);

            return result;
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (!this.astronauts.Models.Any(a => a.Oxygen > 60))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            this.mission.Explore(planet, this.astronauts.Models.Where(a => a.Oxygen > 60).ToList());

            int deadAstronautsCount = this.astronauts.Models.Where(a => !a.CanBreath).Count();

            this.Counter++;

            string result = string.Format(OutputMessages.PlanetExplored, planetName, deadAstronautsCount);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Counter} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                string bagItems = astronaut.Bag.Items.Any() ? string.Join(", ", astronaut.Bag) : "none";
                
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Oxygen: {bagItems}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FindByName(astronautName);

            if(astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astronaut);

            string result = string.Format(OutputMessages.AstronautRetired, astronautName);

            return result;
        }
    }
}
