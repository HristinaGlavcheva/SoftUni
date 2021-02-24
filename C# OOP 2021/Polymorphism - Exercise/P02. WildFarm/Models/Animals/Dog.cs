using System;
using System.Collections.Generic;

using P02._WildFarm.Models.Foods;

namespace P02._WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double WeightIncreasmentCoeficient = 0.4;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
            this.AllowedFoods = new List<Type>()
            {
                typeof(Meat),
            };
        }

        protected override double WeightIncreasmentPerPortion
            => WeightIncreasmentCoeficient;

        protected override ICollection<Type> AllowedFoods { get; }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
