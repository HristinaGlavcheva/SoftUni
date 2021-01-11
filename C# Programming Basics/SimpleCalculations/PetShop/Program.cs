using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDogs = int.Parse(Console.ReadLine());
            int numberOfOtherAnimals = int.Parse(Console.ReadLine());
            double finalSum = numberOfDogs * 2.50 + numberOfOtherAnimals * 4;
            Console.WriteLine($"{finalSum:F2} lv.");
        }
    }
}
