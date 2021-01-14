using _4._HotelReservation.Enumerations;
using System;

namespace _4._HotelReservation
{
    public class PriceCalculator
    {
        private decimal pricePerDay;
        private int numberOfDays;
        private SeasonMultiplier seasonMultiplier;
        private DiscountPercentage discountPercentage;

        public PriceCalculator(string[] inputData)
        {
            this.pricePerDay = decimal.Parse(inputData[0]);
            this.numberOfDays = int.Parse(inputData[1]);
            this.seasonMultiplier = Enum.Parse<SeasonMultiplier>(inputData[2]);

            if (inputData.Length > 3)
            {
                string discountPercentageAsString = inputData[3];
                this.discountPercentage = Enum.Parse<DiscountPercentage>(discountPercentageAsString);
            }
        }

        public decimal GetFinalPrice()
        {
            var totalPrice = pricePerDay * numberOfDays * (int) seasonMultiplier;
            var finalPrice = totalPrice - totalPrice * (decimal)discountPercentage / 100;

            return finalPrice;
        }
    }
}

