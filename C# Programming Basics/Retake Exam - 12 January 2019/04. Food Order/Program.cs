using System;

namespace _04._Food_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            double totalSum = 2.50;
            int countProducts = 0;

            while(product != "Order")
            {
                double productPrice = double.Parse(Console.ReadLine());
                totalSum += productPrice;
                if (totalSum > budget)
                {
                    Console.WriteLine("You will exceed the budget if you order this!");
                    totalSum -= productPrice;
                    product = Console.ReadLine();
                }
                else
                {
                    countProducts++;
                    product = Console.ReadLine();
                }
            }
            Console.WriteLine($"You ordered {countProducts} items!");
            Console.WriteLine($"Total: {totalSum:F2}");
        }
    }
}
