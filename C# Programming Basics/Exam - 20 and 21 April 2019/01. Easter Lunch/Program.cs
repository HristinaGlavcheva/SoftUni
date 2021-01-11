using System;

namespace _01._Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterBreads = int.Parse(Console.ReadLine());
            int eggsBoxes = int.Parse(Console.ReadLine());
            int biscuits = int.Parse(Console.ReadLine());

            double easterBreadsPrice = easterBreads * 3.20;
            double eggsPrice = eggsBoxes * 4.35;
            double biscuitsPrice = biscuits * 5.40;
            double eggPaintPrice = eggsBoxes * 12 * 0.15;
            double totalPrice = easterBreadsPrice + eggsPrice + biscuitsPrice + eggPaintPrice;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
