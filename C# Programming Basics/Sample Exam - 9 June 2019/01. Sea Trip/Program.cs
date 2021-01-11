using System;

namespace _01._Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodCostPerDay = double.Parse(Console.ReadLine());
            double souvenirsCostPerDay = double.Parse(Console.ReadLine());
            double hotelCostPerDay = double.Parse(Console.ReadLine());

            double fuelCostTotal = 420.0 / 100 * 7 * 1.85;
            double souvenirsCostTotal = souvenirsCostPerDay * 3;
            double foodCostTotal = foodCostPerDay * 3;
            double hotelCostTotal = hotelCostPerDay * (0.9 + 0.85 + 0.8);
            double moneyNeeded = fuelCostTotal + souvenirsCostTotal + foodCostTotal + hotelCostTotal;

            Console.WriteLine($"Money needed: {moneyNeeded:F2}");
        }
    }
}
