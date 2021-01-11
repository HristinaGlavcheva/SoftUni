using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    public static class PriceCalculator
    {
        
        public static decimal PricePerDay { get; set; }

        public static int Days { get; set; }

        public static decimal GetTotalPrice(decimal pricePerDay, int days, Season season, Discount discount = Discount.None)
        {
            decimal totalPrice = pricePerDay * days * (int)season;

            decimal finalPrice = totalPrice - totalPrice * (int)discount / 100;

            return finalPrice;
        }
    }
}
