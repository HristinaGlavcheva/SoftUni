using System;

namespace _02._Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuelNeeded = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double fuelPrice = fuelNeeded * 2.10;
            double totalPrice = fuelPrice + 100;
            double discount = 0;

            if (day == "Saturday")
            {
                discount = 0.1 * totalPrice;
            }
            else if (day == "Sunday")
            {
                discount = 0.2 * totalPrice;
            }

            double finalPrice = totalPrice - discount;

            if (budget >= finalPrice)
            {
                Console.WriteLine($"Safari time! Money left: {(budget - finalPrice):F2} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {(finalPrice-budget):F2} lv.");
            }
        }

    }
}
