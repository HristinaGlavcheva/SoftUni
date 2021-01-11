using System;

namespace _02._Beer_And_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double budget = double.Parse(Console.ReadLine());
            int countBeers = int.Parse(Console.ReadLine());
            int countChips = int.Parse(Console.ReadLine());

            double moneyForBeer = countBeers * 1.20;
            double priceForOneChips = 0.45 * moneyForBeer;
            double moneyForChips = Math.Ceiling(priceForOneChips * countChips);
            double totalPrice = moneyForBeer + moneyForChips;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"{name} bought a snack and has {(budget-totalPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"{name} needs {(totalPrice - budget):F2} more leva!");
            }
        }
    }
}
