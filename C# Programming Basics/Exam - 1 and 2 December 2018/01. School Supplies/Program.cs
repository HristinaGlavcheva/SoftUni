using System;

namespace _01._School_Supplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPens = int.Parse(Console.ReadLine());
            int countMarkers = int.Parse(Console.ReadLine());
            double quantityPreparation = double.Parse(Console.ReadLine());
            int discountPercent = int.Parse(Console.ReadLine());

            double totalPrice = countPens * 5.80 + countMarkers * 7.20 + quantityPreparation * 1.20;
            double discount = (discountPercent * 1.0) / 100 * totalPrice;
            double finalPrice = totalPrice - discount;
            Console.WriteLine($"{finalPrice:F3}");
            
        }
    }
}
