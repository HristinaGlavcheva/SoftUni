using P02._WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P02._WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double WeightIncreasmentCoeficient = 1;


        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }
    }
}
