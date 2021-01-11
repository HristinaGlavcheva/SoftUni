using System;

namespace _05._Fan_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int countItems = int.Parse(Console.ReadLine());
            int totalSum = 0;

            for (int counterItems = 1; counterItems <= countItems; counterItems++)
            {
                string typeItem = Console.ReadLine();
                if (typeItem == "hoodie")
                {
                    totalSum += 30;
                }
                else if (typeItem == "keychain")
                {
                    totalSum += 4;
                }
                else if (typeItem == "T-shirt")
                {
                    totalSum += 20;
                }
                else if (typeItem == "flag")
                {
                    totalSum += 15;
                }
                else if (typeItem == "sticker")
                {
                    totalSum += 1;
                }
            }

            if (budget >= totalSum)
            {
                Console.WriteLine($"You bought {countItems} items and left with {budget-totalSum} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalSum-budget} more lv.");
            }
        }
    }
}
