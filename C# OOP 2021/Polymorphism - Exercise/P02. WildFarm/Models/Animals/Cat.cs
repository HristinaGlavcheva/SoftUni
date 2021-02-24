using P02._WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P02._WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double WeightIncreasmentCoeficient = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.AllowedFoods = new List<Type>()
            {
                typeof(Vegetable),
                typeof(Meat),
            };
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        protected override double WeightIncreasmentPerPortion
            => WeightIncreasmentCoeficient;

        protected override ICollection<Type> AllowedFoods { get;  }
    }
}
