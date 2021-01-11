using System;

namespace _06._Christmas_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string itemName = Console.ReadLine();

            while (itemName != "Stop")
            {
                int price = 0;
                for (int i = 0; i <= itemName.Length-1; i++)
                {
                    price += itemName[i];
                }
                if (price <= budget)
                {
                    Console.WriteLine("Item successfully purchased!");
                    budget -= price;
                }
                else
                {
                    Console.WriteLine("Not enough money!");
                    return;
                }
                itemName = Console.ReadLine();
            }
            
                Console.WriteLine($"Money left: {budget}");
        }
    }
}
