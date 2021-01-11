using System;

namespace _05._Series
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countSeries = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            for (int currentSeries = 1; currentSeries <= countSeries; currentSeries++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());

                if (name == "Thrones")
                {
                    price *= 0.5;
                }
                else if (name == "Lucifer")
                {
                    price *= 0.6;
                }
                else if (name == "Protector")
                {
                    price *= 0.7;
                }
                else if (name == "TotalDrama")
                {
                    price *= 0.8;
                }
                else if (name == "Area")
                {
                    price *= 0.9;
                }
                totalPrice += price;
            }
            if(totalPrice <= budget)
            {
                Console.WriteLine($"You bought all the series and left with {(budget - totalPrice):F2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {(totalPrice - budget):F2} lv. more to buy the series!");
            }
        
        }
    }
}
