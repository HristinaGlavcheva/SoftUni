using System;

namespace _01._Oscars_ceremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());
            double statuesPrice = rent * 0.7;
            double cateringPrice = statuesPrice * 0.85;
            double soundPrice = cateringPrice / 2;
            double totalPrice = rent + statuesPrice + cateringPrice + soundPrice;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
