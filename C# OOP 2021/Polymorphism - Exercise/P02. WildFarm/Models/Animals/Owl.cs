using P02._WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P02._WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double WeightIncreasmentCoeficient = 0.25;


        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
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
            return "Hoot Hoot";
        }
    }
}
