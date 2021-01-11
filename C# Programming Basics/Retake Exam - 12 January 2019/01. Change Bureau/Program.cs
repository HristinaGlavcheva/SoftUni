using System;

namespace _01._Change_Bureau
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double cny = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double levaFromBitcoins = bitcoins * 1168;
            double usdFromCny = cny * 0.15;
            double levaFromUsd = usdFromCny * 1.76;
            double totalSumLeva = levaFromBitcoins + levaFromUsd;
            double totalSumEuro = totalSumLeva / 1.95;
            double finalSumEuro = totalSumEuro - totalSumEuro * (commision / 100);

            Console.WriteLine($"{finalSumEuro:F2}");
        }
    }
}
