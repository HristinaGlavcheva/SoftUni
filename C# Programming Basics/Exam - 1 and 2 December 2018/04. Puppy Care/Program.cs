using System;

namespace _04._Puppy_Care
{
    class Program
    {
        static void Main(string[] args)
        {
            int availableFoodKg = int.Parse(Console.ReadLine());
            int availableFoodGrams = availableFoodKg * 1000;
            string command = Console.ReadLine();
            int totalEatenFood = 0;

            while (command != "Adopted")
            {
                int currentEatenFood = int.Parse(command);
                totalEatenFood += currentEatenFood;
                command = Console.ReadLine();
            }

            if (totalEatenFood <= availableFoodGrams)
            {
                Console.WriteLine($"Food is enough! Leftovers: {availableFoodGrams - totalEatenFood} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {totalEatenFood - availableFoodGrams} grams more.");
            }
        }
    }
}
