using System;

namespace _03._Pastry_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeSweet = Console.ReadLine();
            int countSweet = int.Parse(Console.ReadLine());
            int date = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            double finalPrice = 0;

            if (date <= 15)
            {
                if (typeSweet == "Cake")
                {
                    totalPrice = countSweet * 24;
                }
                else if (typeSweet == "Souffle")
                {
                    totalPrice = countSweet * 6.66;
                }
                else if (typeSweet == "Baklava")
                {
                    totalPrice = countSweet * 12.60;
                }

                if (totalPrice >= 100 && totalPrice <= 200)
                {
                    finalPrice = totalPrice * 0.85;
                }
                else if (totalPrice > 200)
                {
                    finalPrice = totalPrice * 0.75;
                }
                else
                {
                    finalPrice = totalPrice;
                }

                finalPrice *= 0.9;
            }

            else if (date > 15 && date <= 22)
            {
                if (typeSweet == "Cake")
                {
                    totalPrice = countSweet * 28.70;
                }
                else if (typeSweet == "Souffle")
                {
                    totalPrice = countSweet * 9.80;
                }
                else if (typeSweet == "Baklava")
                {
                    totalPrice = countSweet * 16.98;
                }

                if (totalPrice >= 100 && totalPrice <= 200)
                {
                    finalPrice = totalPrice * 0.85;
                }
                else if (totalPrice > 200)
                {
                    finalPrice = totalPrice * 0.75;
                }
                else
                {
                    finalPrice = totalPrice;
                }
            }

            else 
            {
                if (typeSweet == "Cake")
                {
                    totalPrice = countSweet * 28.70;
                }
                else if (typeSweet == "Souffle")
                {
                    totalPrice = countSweet * 9.80;
                }
                else if (typeSweet == "Baklava")
                {
                    totalPrice = countSweet * 16.98;
                }

                    finalPrice = totalPrice;
            }

            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
