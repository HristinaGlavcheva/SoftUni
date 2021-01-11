using System;

namespace _01._Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());
            double sneakersPrice = tax * 0.6;
            double outfitPrice = sneakersPrice * 0.8;
            double ballPrice = outfitPrice * 0.25;
            double accesoariesPrice = ballPrice * 0.2;
            double totalPrice = tax + sneakersPrice + outfitPrice + ballPrice + accesoariesPrice;
            Console.WriteLine($"{totalPrice:F2}");

        }
    }
}
