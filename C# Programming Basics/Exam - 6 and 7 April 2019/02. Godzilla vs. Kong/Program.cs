using System;

namespace _02._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countStatics = int.Parse(Console.ReadLine());
            double clothesPricePerMan = double.Parse(Console.ReadLine());
            double decorPrice = budget * 0.1;

            if (countStatics > 150)
            {
                clothesPricePerMan *= 0.9;
            }

            double clothesPriceTotal = countStatics * clothesPricePerMan;
            double totalPrice = decorPrice + clothesPriceTotal;

            if (totalPrice <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - totalPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(totalPrice-budget):F2} leva more.");
            }
        }
    }
}
