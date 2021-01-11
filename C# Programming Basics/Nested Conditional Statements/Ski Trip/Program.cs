using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string assessment = Console.ReadLine();
            double priceAfterDiscount = 0;
            double finalPrice = 0;

            if (roomType == "room for one person")
            {
                priceAfterDiscount = (days - 1) * 18.00;
            }

            else if (roomType == "apartment")
            {
                if ((days - 1) < 10)
                {
                    priceAfterDiscount = (days - 1) * 25.00 * 0.7;
                }
                else if ((days - 1) >= 10 && (days-1)<=15)
                {
                    priceAfterDiscount = (days - 1) * 25.00 * 0.65;
                }
                else
                {
                    priceAfterDiscount = (days - 1) * 25.00 * 0.5;
                }
            }

            else if (roomType == "president apartment")
            {
                if ((days - 1) < 10)
                {
                    priceAfterDiscount = (days - 1) * 35.00 * 0.9;
                }
                else if ((days - 1) >= 10 && (days - 1) <= 15)
                {
                    priceAfterDiscount = (days - 1) * 35.00 * 0.85;
                }
                else
                {
                    priceAfterDiscount = (days - 1) * 35.00 * 0.8;
                }
            }

            if (assessment == "positive")
            {
                finalPrice = priceAfterDiscount * 1.25;
            }
            else if (assessment == "negative")
            {
                finalPrice = priceAfterDiscount * 0.9;
            }

            Console.WriteLine($"{finalPrice:F2}");

        }
    }
}
