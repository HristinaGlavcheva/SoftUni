using System;

namespace Fuel_Tank_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double liters = double.Parse(Console.ReadLine());
            string card = Console.ReadLine();

            double totalPrice;
            double priceAfterCardDiscount;
            double finalPrice=0;

            if (fuel == "Diesel")
            {
                totalPrice = liters * 2.33;
                if (card == "Yes")
                {
                    priceAfterCardDiscount = totalPrice - 0.12*liters;
                }
                else
                {
                    priceAfterCardDiscount = totalPrice;
                }

                if (liters > 25)
                {
                    finalPrice = priceAfterCardDiscount * 0.9;
                }
                else if (liters >= 20)
                {
                    finalPrice = priceAfterCardDiscount * 0.92;
                }
                else
                {
                    finalPrice = priceAfterCardDiscount;
                }
            }

            else if (fuel == "Gasoline")
            {
                totalPrice = liters * 2.22;
                if (card == "Yes")
                {
                    priceAfterCardDiscount = totalPrice - 0.18*liters;
                }
                else
                {
                    priceAfterCardDiscount = totalPrice;
                }

                if (liters > 25)
                {
                    finalPrice = priceAfterCardDiscount * 0.9;
                }
                else if (liters >= 20)
                {
                    finalPrice = priceAfterCardDiscount * 0.92;
                }
                else
                {
                    finalPrice = priceAfterCardDiscount;
                }
            }

            else if (fuel == "Gas")
            {
                totalPrice = liters * 0.93;
                if (card == "Yes")
                {
                    priceAfterCardDiscount = totalPrice - 0.08*liters;
                }
                else
                {
                    priceAfterCardDiscount = totalPrice;
                }

                if (liters > 25)
                {
                    finalPrice = priceAfterCardDiscount * 0.9;
                }
                else if (liters >= 20)
                {
                    finalPrice = priceAfterCardDiscount * 0.92;
                }
                else
                {
                    finalPrice = priceAfterCardDiscount;
                }
            }

            Console.WriteLine($"{finalPrice:F2} lv.");
        }
    }
}
