using P02._WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P02._WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WeightIncreasmentCoeficient = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.AllowedFoods = new List<Type>()
            {
                typeof(Vegetable),
                typeof(Fruit),
                typeof(Meat),
                typeof(Seeds)
            };
        }

        protected override double WeightIncreasmentPerPortion 
            => WeightIncreasmentCoeficient;

        protected override ICollection<Type> AllowedFoods { get; }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
