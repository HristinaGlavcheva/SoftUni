using _04._PizzaCalories.Common;
using System;
using System.Collections.Generic;

namespace _04._PizzaCalories
{
    public static class ToppingValidator
    {
        private static Dictionary<string, double> toppings;

        static ToppingValidator()
        {
            toppings = new Dictionary<string, double>()
            {
                { "meat", 1.2},
                { "veggies", 0.8},
                { "cheese", 1.1},
                { "sauce", 0.9},
            };
        }

        public static IReadOnlyDictionary<string, double> Toppings
            => toppings;

        public static void ValidateTopping(string topping)
        {
            if (!Toppings.ContainsKey(topping.ToLower()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingExceptionMessage, topping));
            }
        }

        public static void ValidateWeight(int weight, string topping)
        {
            if (weight < 1 || weight > 50)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingWeightExceptionMessage, topping));
            }
        }
    }
}

