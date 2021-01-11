using System;

namespace _04._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int availableSeats = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int totalCountPeople = 0;
            int cinemaIncome = 0;

            while (command != "Movie time!")
            {
                int currentCountPeople = int.Parse(command);
                totalCountPeople += currentCountPeople;
                if (totalCountPeople <= availableSeats)
                {
                    if (currentCountPeople % 3 == 0)
                    {
                        cinemaIncome += currentCountPeople * 5 - 5;
                    }
                    else
                    {
                        cinemaIncome += currentCountPeople * 5;
                    }
                }
                else
                {
                    Console.WriteLine("The cinema is full.");
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "Movie time!")
            {
                Console.WriteLine($"There are {availableSeats - totalCountPeople} seats left in the cinema.");
            }
            Console.WriteLine($"Cinema income - {cinemaIncome} lv.");
        }
    }
}
