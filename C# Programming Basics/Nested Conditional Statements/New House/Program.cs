using System;

namespace New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeFlowers = Console.ReadLine();
            int numberFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;

            if (typeFlowers == "Roses")
            {
                if (numberFlowers > 80)
                {
                    price = numberFlowers * 5.00 * 0.9;
                }
                else
                {
                    price = numberFlowers * 5.00;
                }
            }

            else if (typeFlowers == "Dahlias")
            {
                if (numberFlowers > 90)
                {
                    price = numberFlowers * 3.80 * 0.85;
                }
                else
                {
                    price = numberFlowers * 3.80;
                }
            }

            else if (typeFlowers == "Tulips")
            {
                if (numberFlowers > 80)
                {
                    price = numberFlowers * 2.80 * 0.85;
                }
                else
                {
                    price = numberFlowers * 2.80;
                }
            }

            else if (typeFlowers == "Narcissus")
            {
                if (numberFlowers <120)
                {
                    price = numberFlowers * 3.00 * 1.15;
                }
                else
                {
                    price = numberFlowers * 3.00;
                }
            }

            else if (typeFlowers == "Gladiolus")
            {
                if (numberFlowers < 80)
                {
                    price = numberFlowers * 2.50 * 1.2;
                }
                else
                {
                    price = numberFlowers * 2.50;
                }
            }

            if (price <= budget)
            {
                Console.WriteLine($"Hey, you have a great garden with {numberFlowers} {typeFlowers} and {(budget-price):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(price-budget):F2} leva more.");
            }
        }
    }
}
