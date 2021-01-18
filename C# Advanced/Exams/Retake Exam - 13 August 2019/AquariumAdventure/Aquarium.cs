using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        public List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public void Add(Fish fish)
        {
            if (!fishInPool.Contains(fish) && fishInPool.Count + 1 <= Capacity)
            {
                this.fishInPool.Add(fish);
            }
        }
        public bool Remove(string name)
        {
            foreach (var fish in this.fishInPool)
            {
                if (fish.Name == name)
                {
                    this.fishInPool.Remove(fish);
                    return true;
                }
            }
            return false;
        }
        public Fish FindFish(string name)
        {
            Fish fish = this.fishInPool.FirstOrDefault(x => x.Name == name);
            return fish;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");
            foreach (var fish in this.fishInPool)
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
