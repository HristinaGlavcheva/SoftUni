using System;

namespace _01._Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double rocketPrice = double.Parse(Console.ReadLine());
            int countRockets = int.Parse(Console.ReadLine());
            int countSneakers = int.Parse(Console.ReadLine());
            double sneakersPrice = rocketPrice / 6;
            double otherEquipmentPrice = (rocketPrice * countRockets + sneakersPrice * countSneakers) * 0.2;
            double totalPrice = rocketPrice * countRockets + sneakersPrice * countSneakers + otherEquipmentPrice;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(totalPrice/8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(totalPrice*7/8)}");

        }
    }
}
