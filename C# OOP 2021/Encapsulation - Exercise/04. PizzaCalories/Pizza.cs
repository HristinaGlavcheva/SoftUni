using _04._PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaNameExceptionMessage);
                }
                
                this.name = value;
            }
        }

        public Dough Dough { get; }

        public double TotalCalories
            => this.Dough.GetTotalCalories() + this.toppings.Sum(t => t.GetTotalCalories());

        public IReadOnlyCollection<Topping> Toppings
            => this.toppings.AsReadOnly();

        public void AddTopping(Topping topping)
        {
            if(this.toppings.Count == 10)
            {
                throw new ArgumentException(ExceptionMessages.MaximumToppingsCountReachedMessage);
            }
            
            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
