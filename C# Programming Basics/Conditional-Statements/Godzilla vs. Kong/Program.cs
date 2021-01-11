using System;

namespace Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberPeople = int.Parse(Console.ReadLine());
            double costumePrice = double.Parse(Console.ReadLine());
            double decorPrice = 0.1 * budget;
            double totalForCostumes= numberPeople * costumePrice;
            if (numberPeople>150)
            {
                totalForCostumes *= 0.9;
            }
            double moneyNeeded = decorPrice + totalForCostumes;
            double moneyLeft = budget - moneyNeeded;
            if (moneyLeft <0)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(moneyLeft):F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:F2} leva left.");
            }
        }
    }
}
