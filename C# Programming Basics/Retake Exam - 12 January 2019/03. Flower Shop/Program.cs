using System;

namespace _03._Flower_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int countChrysanthemums = int.Parse(Console.ReadLine());
            int countRoses = int.Parse(Console.ReadLine());
            int countTulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holiday = Console.ReadLine();
            double bouquetPrice = 0;

            if (season == "Spring" || season == "Summer")
            {
                bouquetPrice = countChrysanthemums * 2.00 + countRoses * 4.10 + countTulips * 2.50;

                if (holiday == "Y")
                {
                    bouquetPrice *= 1.15;
                }
                if (season == "Spring" && countTulips > 7)
                {
                    bouquetPrice *= 0.95;
                }
                if (countChrysanthemums + countRoses + countTulips > 20)
                {
                    bouquetPrice *= 0.8;
                }
            }
            else if (season == "Autumn" || season == "Winter")
            {
                bouquetPrice = countChrysanthemums * 3.75 + countRoses * 4.50 + countTulips * 4.15;

                if (holiday == "Y")
                {
                    bouquetPrice *= 1.15;
                }
                if (season == "Winter" && countRoses >= 10)
                {
                    bouquetPrice *= 0.9;
                }
                if (countChrysanthemums + countRoses + countTulips > 20)
                {
                    bouquetPrice *= 0.8;
                }
            }
            double finalPrice = bouquetPrice + 2;
            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
