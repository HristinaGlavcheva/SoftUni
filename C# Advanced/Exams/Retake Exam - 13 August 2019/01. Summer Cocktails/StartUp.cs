using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Summer_Cocktails
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] ingredientsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] freshnessLevelsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredients = new Queue<int>();

            for (int i = 0; i < ingredientsInput.Length; i++)
            {
                ingredients.Enqueue(ingredientsInput[i]);
            }

            Stack<int> freshnessLevels = new Stack<int>();

            for (int i = 0; i < freshnessLevelsInput.Length; i++)
            {
                freshnessLevels.Push(freshnessLevelsInput[i]);
            }

            Dictionary<string, int> cocktails = new Dictionary<string, int>();
                
            cocktails["Mimosa"] = 0;
            cocktails["Daiquiri"] = 0;
            cocktails ["Mojito"] = 0;
            cocktails["Sunshine"] = 0;

            while (ingredients.Count > 0 && freshnessLevels.Count > 0)
            {
                if(ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    conyi
                }
                
                int mixingValue = ingredients.Peek() * freshnessLevels.Pop();
                bool successfullMixed = false;

                if(mixingValue == 150)
                {
                    cocktails["Mimosa"]++;
                    successfullMixed = true;
                }
                else if (mixingValue == 250)
                {
                    cocktails["Daiquiri"]++;
                    successfullMixed = true;
                }
                else if (mixingValue == 300)
                {
                    cocktails["Sunshine"]++;
                    successfullMixed = true;
                }
                else if (mixingValue == 400)
                {
                    cocktails["Mojito"]++;
                    successfullMixed = true;
                }

                if (successfullMixed)
                {
                    ingredients.Dequeue();
                }
                else
                {
                    int increasedIngredient = ingredients.Dequeue() + 5;
                    ingredients.Enqueue(increasedIngredient);
                }
            }

            if (cocktails["Mimosa"] > 0 && cocktails["Daiquiri"] > 0 
                && cocktails["Sunshine"] > 0 && cocktails["Mojito"] > 0)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }

            if(ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var cocktail in cocktails.Where(c => c.Value > 0).OrderBy(c => c.Key))
            {
                Console.WriteLine($" # {cocktail.Key} --> {cocktail.Value}");
            }
        }
    }
}
