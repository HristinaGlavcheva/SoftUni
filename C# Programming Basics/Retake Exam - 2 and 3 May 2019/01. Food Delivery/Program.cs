using System;

namespace _01._Food_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int countChickenMenus = int.Parse(Console.ReadLine());
            int countFishMenus = int.Parse(Console.ReadLine());
            int countVegeMenus = int.Parse(Console.ReadLine());

            double priceMeals = countChickenMenus * 10.35 + countFishMenus * 12.40 + countVegeMenus * 8.15;
            double priceMealsPlusDesert = priceMeals * 1.2;
            double totalPrice = priceMealsPlusDesert + 2.50;

            Console.WriteLine($"Total: {totalPrice:F2}");
        }
    }
}
