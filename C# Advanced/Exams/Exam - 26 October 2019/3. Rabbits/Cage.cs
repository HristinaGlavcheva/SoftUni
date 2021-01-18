using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        private Cage()
        {
            this.data = new List<Rabbit>();
        }

        public Cage(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Rabbit rabbit)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbitToRemove = this.data.FirstOrDefault(r => r.Name == name);

            if(rabbitToRemove != null)
            {
                this.data.Remove(rabbitToRemove);

                return true;
            }

            return false;

            //или
            //return this.data.Remove(this.data.FirstOrDefault(r => r.Name == name));

            // или
            //foreach (var rabbit in data)
            //{
            //    if(rabbit.Name == name)
            //    {
            //        data.Remove(rabbit);
            //        return true;
            //    }
            //}

            //return false;
        }

        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(r => r.Species == species);

            //foreach (var rabbit in data)
            //{
            //    if (rabbit.Species == species)
            //    {
            //        data.Remove(rabbit);
            //    }
            //}
        }

        public Rabbit SellRabbit(string name)
        {
            //Rabbit soldRabbit = data.Where(r => r.Name == name).FirstOrDefault();

            Rabbit soldRabbit = data.FirstOrDefault(r => r.Name == name);

            if(soldRabbit != null)
            {
                soldRabbit.Available = false;
            }

            return soldRabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] soldRabbits = this.data
                .Where(r => r.Species == species)
                .ToArray();

            foreach (var rabbit in soldRabbits)
            {
                rabbit.Available = false;
            }

            return soldRabbits;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in this.data.Where(r => r.Available))
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
