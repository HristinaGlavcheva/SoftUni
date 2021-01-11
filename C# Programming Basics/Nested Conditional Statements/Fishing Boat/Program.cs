using System;

namespace Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());
            double price = 0;
            double finalPrice = 0;

            if (season == "Spring")
            {
                if (fishermen <= 6)
                {
                    price = 3000 * 0.9;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    price = 3000 * 0.85;
                }
                else if (fishermen >= 12)
                {
                    price = 3000 * 0.75;
                }
            }

            else if (season == "Summer" || season == "Autumn")
            {
                if (fishermen <= 6)
                {
                    price = 4200 * 0.9;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    price = 4200 * 0.85;
                }
                else if (fishermen >= 12)
                {
                    price = 4200 * 0.75;
                }
            }

            else if (season == "Winter")
            {
                if (fishermen <= 6)
                {
                    price = 2600 * 0.9;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    price = 2600 * 0.85;
                }
                else if (fishermen >= 12)
                {
                    price = 2600 * 0.75;
                }
            }

            if (season != "Autumn" && fishermen % 2 == 0)
            {
                finalPrice = price * 0.95;
            }
            else 
            {
                finalPrice = price;
            }

            if (finalPrice <= budget)
            {
                Console.WriteLine($"Yes! You have {(budget - finalPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(finalPrice - budget):F2} leva.");
            }

        }
    }
}
