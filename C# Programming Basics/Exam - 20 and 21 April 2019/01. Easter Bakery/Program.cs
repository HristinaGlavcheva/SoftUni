using System;

namespace _01._Easter_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double flourPrice = double.Parse(Console.ReadLine());
            double flourQuantity = double.Parse(Console.ReadLine());
            double sugarQuantity = double.Parse(Console.ReadLine());
            int eggsQuantity = int.Parse(Console.ReadLine());
            int yeastQuantity = int.Parse(Console.ReadLine());

            double sugarPrice = flourPrice * 0.75;
            double eggsPrice = flourPrice * 1.1;
            double yeastPrice = sugarPrice * 0.2;

            double sumFlour = flourPrice * flourQuantity;
            double sumSugar = sugarPrice * sugarQuantity;
            double sumEggs = eggsPrice * eggsQuantity;
            double sumYeast = yeastPrice * yeastQuantity;

            double totalSum = sumFlour + sumSugar + sumEggs + sumYeast;
            Console.WriteLine($"{totalSum:F2}");
        }
    }
}
