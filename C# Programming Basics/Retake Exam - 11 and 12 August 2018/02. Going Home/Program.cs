using System;

namespace _02._Going_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int fuelConsumptionPer100km = int.Parse(Console.ReadLine());
            double fuelPricePerLiter = double.Parse(Console.ReadLine());
            int gainedMoney = int.Parse(Console.ReadLine());

            double totalFuelConsumption = distance * 1.0 / 100 * fuelConsumptionPer100km;
            double totalPriceOfFuel = fuelPricePerLiter * totalFuelConsumption;

            if(totalPriceOfFuel <= gainedMoney)
            {
                Console.WriteLine($"You can go home. {(gainedMoney - totalPriceOfFuel):F2} money left.");
            }
            else
            {
                double gainedMoneyPerBoy = gainedMoney * 1.0 / 5;
                Console.WriteLine($"Sorry, you cannot go home. Each will receive {gainedMoneyPerBoy:F2} money.");
            }
        }
    }
}
