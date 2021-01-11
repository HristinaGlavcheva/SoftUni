using System;

namespace _03._Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int countOrderedSets = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            double finalPrice = 0;

            if (size == "small")
            {
                if (fruit == "Watermelon")
                {
                    totalPrice = countOrderedSets * 2 * 56;
                }
                else if (fruit == "Mango")
                {
                    totalPrice = countOrderedSets * 2 * 36.66;
                }
                else if (fruit == "Pineapple")
                {
                    totalPrice = countOrderedSets * 2 * 42.10;
                }
                else if (fruit == "Raspberry")
                {
                    totalPrice = countOrderedSets * 2 * 20.00;
                }
            }
            else
            {
                if (fruit == "Watermelon")
                {
                    totalPrice = countOrderedSets * 5 * 28.70;
                }
                else if (fruit == "Mango")
                {
                    totalPrice = countOrderedSets * 5 * 19.60;
                }
                else if (fruit == "Pineapple")
                {
                    totalPrice = countOrderedSets * 5 * 24.80;
                }
                else if (fruit == "Raspberry")
                {
                    totalPrice = countOrderedSets * 5 * 15.20;
                }
            }

            if (totalPrice >= 400 && totalPrice <= 1000)
            {
                finalPrice = totalPrice * 0.85;
            }
            else if (totalPrice > 1000)
            {
                finalPrice = totalPrice * 0.50;
            }
            else 
            {
                finalPrice = totalPrice;
            }

            Console.WriteLine($"{finalPrice:F2} lv.");
        }
    }
}
