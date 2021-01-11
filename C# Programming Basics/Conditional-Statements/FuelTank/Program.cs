using System;

namespace FuelTank
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            int liters = int.Parse(Console.ReadLine());

            if (liters >= 25)
            {
                if (fuel == "Diesel")
                {
                    Console.WriteLine("You have enough diesel.");
                }
                else if (fuel == "Gasoline")
                {
                    Console.WriteLine("You have enough gasoline.");
                }
                else if (fuel == "Gas")
                {
                    Console.WriteLine("You have enough gas.");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }

            else
            {
                if (fuel == "Diesel")
                {
                    Console.WriteLine("Fill your tank with diesel!");
                }
                else if (fuel == "Gasoline")
                {
                    Console.WriteLine("Fill your tank with gasoline!");
                }
                else if (fuel == "Gas")
                {
                    Console.WriteLine("Fill your tank with gas!");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }
           
        }
    }
}
