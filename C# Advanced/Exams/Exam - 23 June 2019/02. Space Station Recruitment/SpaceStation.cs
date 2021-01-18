using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }
        
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Astronaut astronaut)
        {
            if(data.Count < this.Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            //foreach (var astronaut in data)
            //{
            //    if(astronaut.Name == name)
            //    {
            //        data.Remove(astronaut);
            //        return true;
            //    }
            //}

            //return false;

            return data.Remove(data.Where(a => a.Name == name).FirstOrDefault());
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldestAstrounaut = this.data.OrderByDescending(a => a.Age).FirstOrDefault();

            return oldestAstrounaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut foundAstronaut = this.data.Where(a => a.Name == name).FirstOrDefault();

            return foundAstronaut;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in data)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
