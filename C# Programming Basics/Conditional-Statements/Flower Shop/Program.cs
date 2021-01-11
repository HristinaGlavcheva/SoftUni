using System;

namespace Flower_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());
            int hyacinths = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactuses = int.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());

            double incomeTotal = magnolias * 3.25 + hyacinths * 4 + roses * 3.5 + cactuses * 8;
            double incomeAfterTaxes = incomeTotal * 0.95;

            if (incomeAfterTaxes >= presentPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(incomeAfterTaxes - presentPrice)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(presentPrice-incomeAfterTaxes)} leva.");
            }
        }
    }
}
