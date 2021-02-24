using P02._WildFarm.Common;
using P02._WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace P02._WildFarm.Models.Animals
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAnymalTypeMessage);
                }

                this.name = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAnymalWeightMessage);
                }

                this.weight = value;
            }
        }

        public int FoodEaten
        {
            get
            {
                return this.foodEaten;
            }
            private set
            {
                this.foodEaten = value;
            }
        }

        protected abstract double WeightIncreasmentPerPortion { get; }

        protected abstract ICollection<Type> AllowedFoods { get; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            if (!this.AllowedFoods.Contains(typeof(Food)))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InappropriateFoodMessage, this.Name, food.GetType().Name));
            }

            this.Weight += food.Quantity * this.WeightIncreasmentPerPortion;
            this.FoodEaten += food.Quantity;
        }
    }
}
