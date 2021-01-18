using System;
using System.Linq;

namespace _04._Add_VAT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<double, double> addedVAT = price => price * 1.2;

            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addedVAT)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
