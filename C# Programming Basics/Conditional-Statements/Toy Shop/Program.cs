using System;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            int puzzels = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());
            double totalIncome = puzzels * 2.60 + dolls * 3.00 + bears * 4.10 + minions * 8.20 + trucks * 2.00;
            double netIncome;            
            int numberOfToys = puzzels + dolls + bears + minions + trucks;
            if (numberOfToys >= 50)
            {
                netIncome = totalIncome * 0.75;
            }
            else
            {
                netIncome = totalIncome;
            }
            double moneyLeft = netIncome * 0.9;
            if (moneyLeft >= vacationPrice)
            {
                Console.WriteLine($"Yes! {(moneyLeft-vacationPrice):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {(vacationPrice-moneyLeft):F2} lv needed.");
            }
        }
    }
}
