using System;

namespace AlcoholMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beerQuantity = double.Parse(Console.ReadLine());
            double wineQuantity = double.Parse(Console.ReadLine());
            double rakiaQuantity = double.Parse(Console.ReadLine());
            double whiskeyQuantity = double.Parse(Console.ReadLine());
            double rakiaPrice = whiskeyPrice / 2;
            double winePrice = rakiaPrice * 0.6;
            double beerPrice = rakiaPrice * 0.2;
            double totalPrice = whiskeyPrice * whiskeyQuantity + beerPrice * beerQuantity + winePrice * wineQuantity + rakiaPrice * rakiaQuantity;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
