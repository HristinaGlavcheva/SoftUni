using System;

namespace _01._Christmas_Sweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double baklavaPrice = double.Parse(Console.ReadLine());
            double muffinsPrice = double.Parse(Console.ReadLine());
            double cakeQuantity = double.Parse(Console.ReadLine());
            double candyQuantity = double.Parse(Console.ReadLine());
            int cookieQuantity = int.Parse(Console.ReadLine());

            double cakePrice = baklavaPrice * 1.6;
            double candyPrice = muffinsPrice * 1.8;
            double totalPrice = cakeQuantity * cakePrice + candyQuantity * candyPrice + cookieQuantity * 7.50;

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
