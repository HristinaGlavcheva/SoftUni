using System;

namespace _04._Christmas_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int numberAdults = 0;
            int numberKids = 0;
            int moneyForToys = 0;
            int moneyForSweaters = 0;

            while (command != "Christmas")
            {
                int age = int.Parse(command);
                if (age <= 16)
                {
                    numberKids++;
                    moneyForToys += 5;
                }
                else
                {
                    numberAdults++;
                    moneyForSweaters += 15;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Number of adults: {numberAdults}");
            Console.WriteLine($"Number of kids: {numberKids}");
            Console.WriteLine($"Money for toys: {moneyForToys}");
            Console.WriteLine($"Money for sweaters: {moneyForSweaters}");
        }
    }
}
