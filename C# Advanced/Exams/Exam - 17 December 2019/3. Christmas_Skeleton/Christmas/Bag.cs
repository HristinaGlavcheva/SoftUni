using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        private Bag()
        {
            this.data = new List<Present>();
        }

        public Bag(string color, int capacity)
            : this()
        {
            this.Color = color;
            this.Capacity = capacity;
        }
        
        public string Color { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Present present)
        {
            if(this.data.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            Present presentToRemove = this.data.FirstOrDefault(p => p.Name == name);

            if(presentToRemove != null)
            {
                this.data.Remove(presentToRemove);
                return true;
            }

            return false;
            
            //return this.data.Remove(this.data.FirstOrDefault(p => p.Name == name));
            
            //for (int i = 0; i < data.Count; i++)
            //{
            //    if(this.data[i].Name == name)
            //    {
            //        data.Remove(this.data[i]);
            //        return true;
            //    }
            //}

            //return false;
        }

        public Present GetHeaviestPresent()
        {
            Present heaviestPresent = this.data
                .OrderByDescending(p => p.Weight)
                .FirstOrDefault();

            return heaviestPresent;
        }

        public Present GetPresent(string name)
        {
            Present persent = this.data.FirstOrDefault(p => p.Name == name);

            return persent;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
