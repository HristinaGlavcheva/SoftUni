using System;

namespace _02._Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int countGuests = int.Parse(Console.ReadLine());
            double couvert = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double cakePrice = budget * 0.1;

            if (countGuests >= 10 && countGuests <= 15)
            {
                couvert *= 0.85;
            }
            else if (countGuests > 15 && countGuests <= 20)
            {
                couvert *= 0.8;
            }
            else if (countGuests > 20)
            {
                couvert *= 0.75;
            }

            double finalPrice = countGuests * couvert + cakePrice;

            if (finalPrice <= budget)
            {
                Console.WriteLine($"It is party time! {(budget-finalPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {(finalPrice - budget):F2} leva needed.");
            }
        }
    }
}
