using P02._WildFarm.Common;
using System;

namespace P02._WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get
            {
                return this.livingRegion;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLivingRegionMessage);
                }

                this.livingRegion = value; 
            }
        }
    }
}
