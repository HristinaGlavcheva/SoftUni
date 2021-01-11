using System;

namespace _02._School_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int countDays = int.Parse(Console.ReadLine());
            int foodLeft = int.Parse(Console.ReadLine());
            double foodNeededFirstDog = double.Parse(Console.ReadLine());
            double foodNeededSecondDog = double.Parse(Console.ReadLine());
            double foodNeededThirdDog = double.Parse(Console.ReadLine());

            double neededFoodTotal = (foodNeededFirstDog + foodNeededSecondDog + foodNeededThirdDog) * countDays;

            if (neededFoodTotal <= foodLeft)
            {
                Console.WriteLine($"{Math.Floor(foodLeft - neededFoodTotal)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(neededFoodTotal - foodLeft)} more kilos of food are needed.");
            }
        }
    }
}
