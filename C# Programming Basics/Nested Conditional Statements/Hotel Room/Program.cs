using System;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceApartment = 0;
            double priceStudio = 0;

            if (month == "May" || month == "October")
            {
                priceStudio = nights * 50;
                priceApartment = nights * 65;

                if (nights > 7 && nights <= 14)
                {
                    priceStudio = priceStudio * 0.95;
                }
                else if (nights > 14)
                {
                    priceStudio = priceStudio * 0.7;
                    priceApartment = priceApartment * 0.9;
                }
            }
            else if (month == "June" || month == "September")
            {
                priceStudio = nights * 75.20;
                priceApartment = nights * 68.70;

                if (nights > 14)
                {
                    priceStudio = priceStudio * 0.8;
                    priceApartment = priceApartment * 0.9;
                }
            }
            else if (month == "July" || month == "August")
            {
                priceStudio = nights * 76.00;
                priceApartment = nights * 77.00;

                if (nights > 14)
                {
                    priceApartment = priceApartment * 0.9;
                }
            }
            Console.WriteLine($"Apartment: {priceApartment:F2} lv.");
            Console.WriteLine($"Studio: {priceStudio:F2} lv.");
        }
    }
}
