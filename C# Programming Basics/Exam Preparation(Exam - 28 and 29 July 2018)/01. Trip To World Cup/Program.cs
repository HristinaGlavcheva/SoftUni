using System;

namespace _01._Trip_To_World_Cup
{
    class Program
    {
        static void Main(string[] args)
        {
            double departureTicketPrice = double.Parse(Console.ReadLine());
            double arrivalTicketPrice = double.Parse(Console.ReadLine());
            double gameTicketPrice = double.Parse(Console.ReadLine());
            int countGames = int.Parse(Console.ReadLine());
            int discouont = int.Parse(Console.ReadLine());

            double totalTravelCosts = (departureTicketPrice + arrivalTicketPrice) * 6;
            double travelCostsAfterDiscount = totalTravelCosts * (1 - discouont/100.0);
            double totalGameTicketsCosts = gameTicketPrice * countGames *6;
            double totalSum = travelCostsAfterDiscount + totalGameTicketsCosts;
            double totalSumForEachFriend = totalSum / 6;

            Console.WriteLine($"Total sum: {totalSum:F2} lv.");
            Console.WriteLine($"Each friend has to pay {totalSumForEachFriend:F2} lv.");
        }
    }
}
