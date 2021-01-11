using System;

namespace _04._Tourist_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int countProducts = 0;
            double finalPrice = 0;

            while (command != "Stop")
            {
                countProducts++;
                double productPrice = double.Parse(Console.ReadLine());
                if (countProducts % 3 != 0)
                {
                    finalPrice += productPrice;
                }
                else
                {
                    finalPrice += 0.5 * productPrice;
                }

                if(finalPrice > budget)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (finalPrice > budget)
            {
                Console.WriteLine("You don't have enough money!");
                Console.WriteLine($"You need {(finalPrice - budget):F2} leva!");
            }
            else
            {
                Console.WriteLine($"You bought {countProducts} products for {finalPrice:F2} leva.");
            }
        }
    }
}
