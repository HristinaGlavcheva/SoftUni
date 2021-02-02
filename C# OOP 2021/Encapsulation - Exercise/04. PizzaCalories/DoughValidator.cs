using _04._PizzaCalories.Common;
using System;
using System.Collections.Generic;

namespace _04._PizzaCalories
{
    public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTechniques;

        static DoughValidator()
        {
            flourTypes = new Dictionary<string, double>()
            {
                { "white", 1.5 },
                { "wholegrain", 1.0 }
            };

            bakingTechniques = new Dictionary<string, double>()
            {
                {"crispy", 0.9 },
                {"chewy", 1.1},
                {"homemade", 1.0 }
            };
        }

        public static IReadOnlyDictionary<string, double> FlourTypes
           => flourTypes;

        public static IReadOnlyDictionary<string, double> BakingTechniques
            => bakingTechniques;


        public static void ValidateDouhgType(string flourType)
        {
            if (!FlourTypes.ContainsKey(flourType.ToLower()))
            {
                throw new ArgumentException(ExceptionMessages.InvalidDoughTypeExceptionMessage);
            }
        }

        public static void ValidateBakingTechnique(string bakingTechnique)
        {
            if (!BakingTechniques.ContainsKey(bakingTechnique.ToLower()))
            {
                throw new ArgumentException(ExceptionMessages.InvalidDoughTypeExceptionMessage);
            }
        }

        public static void ValidateWeight(int weight)
        {
            if (weight < 1 || weight > 200)
            {
                throw new ArgumentException(ExceptionMessages.InvalidDoughWeihgtExceptionMessage);
            }
        }
    }
}
