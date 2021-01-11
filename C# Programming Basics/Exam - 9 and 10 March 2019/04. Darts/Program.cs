using System;

namespace _04._Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string sector = Console.ReadLine();
            int points = 301;
            int countSuccessfulShots = 0;
            int countUnsuccessfulShots = 0;

            while (sector != "Retire")
            {
                int currentPoints = int.Parse(Console.ReadLine());
                if (sector == "Single")
                {
                    if (currentPoints <= points)
                    {
                        points -= currentPoints;
                        countSuccessfulShots++;
                    }
                    else
                    {
                        countUnsuccessfulShots++;
                    }
                }
                else if (sector == "Double")
                {
                    if (currentPoints*2 <= points)
                    {
                        points -= 2 * currentPoints;
                        countSuccessfulShots++;
                    }
                    else
                    {
                        countUnsuccessfulShots++;
                    }
                }
                else if (sector == "Triple")
                {
                    if (currentPoints * 3 <= points)
                    {
                        points -= 3 * currentPoints;
                        countSuccessfulShots++;
                    }
                    else
                    {
                        countUnsuccessfulShots++;
                    }
                }

                if (points == 0)
                {
                    Console.WriteLine($"{name} won the leg with {countSuccessfulShots} shots.");
                    break;
                }
                sector = Console.ReadLine();
            }
            if(sector == "Retire")
            {
                Console.WriteLine($"{name} retired after {countUnsuccessfulShots} unsuccessful shots.");
            }
        }
    }
}
