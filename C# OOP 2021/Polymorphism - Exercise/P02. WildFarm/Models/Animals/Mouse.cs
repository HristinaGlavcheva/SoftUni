using P02._WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P02._WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double WeightIncreasmentCoeficient = 0.1;


        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.AllowedFoods = new List<Type>()
            {
                typeof(Vegetable),
                typeof(Fruit),
            };
        }

        protected override double WeightIncreasmentPerPortion
            => WeightIncreasmentCoeficient;

        protected override ICollection<Type> AllowedFoods { get; }
        
        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
