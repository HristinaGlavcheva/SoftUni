using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int foodLeft = int.Parse(Console.ReadLine());
            double dogPerDayKg = double.Parse(Console.ReadLine());
            double catPerDayKg = double.Parse(Console.ReadLine());
            double turtlePerDayGrams = double.Parse(Console.ReadLine());

            double turtlePerDayKg = turtlePerDayGrams / 1000;
            double foodNeeded = (dogPerDayKg + catPerDayKg + turtlePerDayKg) * days;

            if (foodLeft >= foodNeeded)
            {
                Console.WriteLine($"{Math.Floor(foodLeft - foodNeeded)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(foodNeeded - foodLeft)} more kilos of food are needed.");
            }
        }
    }
}
