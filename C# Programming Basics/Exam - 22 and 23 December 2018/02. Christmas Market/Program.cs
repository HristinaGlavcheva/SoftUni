using System;

namespace _02._Christmas_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double goalSum = double.Parse(Console.ReadLine());
            int fantasy = int.Parse(Console.ReadLine());
            int horror = int.Parse(Console.ReadLine());
            int romans = int.Parse(Console.ReadLine());

            double totalSum = fantasy * 14.90 + horror * 9.80 + romans * 4.30;
            double sumWithoutVAT = totalSum * 0.8;

            if(sumWithoutVAT >= goalSum)
            {
                double moneyForSellers = Math.Floor((sumWithoutVAT - goalSum) * 0.1);
                double moneyForDonation = goalSum + (sumWithoutVAT - goalSum) - moneyForSellers;
                Console.WriteLine($"{moneyForDonation:F2} leva donated.");
                Console.WriteLine($"Sellers will receive {moneyForSellers} leva.");
            }
            else
            {
                Console.WriteLine($"{(goalSum-sumWithoutVAT):F2} money needed.");
            }
        }
    }
}
