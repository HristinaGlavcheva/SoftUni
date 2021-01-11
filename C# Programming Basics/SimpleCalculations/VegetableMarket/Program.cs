using System;

namespace VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            double vegetablePrice = double.Parse(Console.ReadLine());
            double fruitPrice = double.Parse(Console.ReadLine());
            int vegetableQuantity = int.Parse(Console.ReadLine());
            int fruitQuantity = int.Parse(Console.ReadLine());
            double incomeLv = vegetablePrice * vegetableQuantity + fruitPrice * fruitQuantity;
            double incomeEUR = incomeLv / 1.94;
            Console.WriteLine(incomeEUR);
        }
    }
}
