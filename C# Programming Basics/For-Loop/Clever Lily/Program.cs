using System;

namespace Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashingMachine = double.Parse(Console.ReadLine());
            int priceToy = int.Parse(Console.ReadLine());
            int receivedMoney = 0;
            int takenMoney = 0;
            int moneyFromToys = 0;
            int totalSum = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    receivedMoney += i * 5;
                    takenMoney++;
                }
                else
                {
                    moneyFromToys += priceToy; 
                }
            }

            totalSum = receivedMoney - takenMoney + moneyFromToys;

            if (totalSum >= priceWashingMachine)
            {
                Console.WriteLine($"Yes! {(totalSum-priceWashingMachine):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(priceWashingMachine - totalSum):F2}");
            }
        }
    }
}
