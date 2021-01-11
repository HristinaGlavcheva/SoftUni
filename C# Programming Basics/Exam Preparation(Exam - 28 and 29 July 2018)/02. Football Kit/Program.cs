using System;

namespace _02._Football_Kit
{
    class Program
    {
        static void Main(string[] args)
        {
            double tShirtPrice = double.Parse(Console.ReadLine());
            double sumForBall = double.Parse(Console.ReadLine());

            double shortsPrice = tShirtPrice * 0.75;
            double socksPrice = shortsPrice * 0.20;
            double shoesPrice = 2 * (tShirtPrice + shortsPrice);
            double totalSum = tShirtPrice + shortsPrice + socksPrice + shoesPrice;
            double finalSum = totalSum * 0.85;

            if (finalSum >= sumForBall)
            {
                Console.WriteLine($"Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {finalSum:F2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {(sumForBall - finalSum):F2} lv. more.");
            }
        }
    }
}
