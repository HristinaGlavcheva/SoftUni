using System;

namespace _03._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int countDays = int.Parse(Console.ReadLine());
            string typeAccomodation = Console.ReadLine();
            string rating = Console.ReadLine();
            double price = 0;
            double finalPrice = 0;
            int countNights = countDays - 1;

            if (typeAccomodation == "room for one person")
            {
                price = countNights * 18.00;
            }
            else if (typeAccomodation == "apartment")
            {
                if (countNights < 10)
                {
                    price = countNights * 25.00 * 0.7;
                }
                else if (countNights >= 10 && countNights <= 15)
                {
                    price = countNights * 25.00 * 0.65;
                }
                else 
                {
                    price = countNights * 25.00 * 0.5;
                }
            }
            else if (typeAccomodation == "president apartment")
            {
                if (countNights < 10)
                {
                    price = countNights * 35.00 * 0.9;
                }
                else if (countNights >= 10 && countNights <= 15)
                {
                    price = countNights * 35.00 * 0.85;
                }
                else
                {
                    price = countNights * 35.00 * 0.8;
                }
            }

            if (rating == "positive")
            {
                finalPrice = price * 1.25;
            }
            else
            {
                finalPrice = price * 0.9;
            }

            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
