using System;
using static HotelReservation.PriceCalculator;

namespace HotelReservation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] reservationInfo = Console.ReadLine()
                 .Split();

            decimal pricePerDay = decimal.Parse(reservationInfo[0]);
            int days = int.Parse(reservationInfo[1]);

            Season season = Enum.Parse<Season>(reservationInfo[2]);
            Discount discount = 0;

            if (reservationInfo.Length == 4)
            {
               discount = Enum.Parse<Discount>(reservationInfo[3]);
            }

            Console.WriteLine($"{PriceCalculator.GetTotalPrice(pricePerDay, days, season, discount):F2}"); 
        }
    }
}
