using System;

namespace _02._Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double widthFloor = double.Parse(Console.ReadLine());
            double lenghtFloor = double.Parse(Console.ReadLine());
            double sideTile = double.Parse(Console.ReadLine());
            double heightTile = double.Parse(Console.ReadLine());
            double pricePerTile = double.Parse(Console.ReadLine());
            double priceForLabour = double.Parse(Console.ReadLine());

            double floorArea = widthFloor * lenghtFloor;
            double tileArea = (sideTile * heightTile) / 2;
            double countTiles = Math.Ceiling(floorArea / tileArea + 5);
            double totalPriceForTiles = countTiles * pricePerTile;
            double totalSum = totalPriceForTiles + priceForLabour;

            if (totalSum <= budget)
            {
                Console.WriteLine($"{(budget - totalSum):F2} lv left.");
            }
            else
            {
                Console.WriteLine($"You'll need {(totalSum - budget):F2} lv more.");
            }
        }
    }
}
