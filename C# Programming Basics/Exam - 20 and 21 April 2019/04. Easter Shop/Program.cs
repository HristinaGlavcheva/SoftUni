using System;

namespace _04._Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int countEggs = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int eggsSold = 0;

            while (command != "Close")
            {
                int movingEggs = int.Parse(Console.ReadLine());
                if (command == "Buy")
                {
                    if (movingEggs > countEggs)
                    {
                        Console.WriteLine("Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {countEggs}.");
                        break;
                    }
                    countEggs -= movingEggs;
                    eggsSold += movingEggs;
                }
                else if (command == "Fill")
                {
                    countEggs += movingEggs;
                }

                command = Console.ReadLine();
            }

            if (command == "Close")
            {
                Console.WriteLine("Store is closed!");
                Console.WriteLine($"{eggsSold} eggs sold.");
            }
        }
    }
}
