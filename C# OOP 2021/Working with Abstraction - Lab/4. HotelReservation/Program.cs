using _4._HotelReservation.Enumerations;
using System;
using System.Linq;

namespace _4._HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine()
                .Split()
                .ToArray();

            PriceCalculator priceCalculator = new PriceCalculator(inputData);

            Console.WriteLine($"{priceCalculator.GetFinalPrice():F2}");
        }
    }
}
