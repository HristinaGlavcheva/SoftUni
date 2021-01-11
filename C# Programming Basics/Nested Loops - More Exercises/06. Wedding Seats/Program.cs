using System;

namespace _06._Wedding_Seats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int countRows = int.Parse(Console.ReadLine());
            int countSeatsOddRow = int.Parse(Console.ReadLine());
            int totalCountSeats = 0;

            for (char sector = 'A'; sector <= lastSector; sector++)
            {
                for (int row = 1; row <= countRows; row++)
                {
                    if (row % 2 == 0)
                    {
                        countSeatsOddRow += 2;
                    }

                    for (char seat = 'a'; seat <= 'a' + countSeatsOddRow - 1; seat++)
                    {
                        Console.WriteLine($"{sector}{row}{seat}");
                        totalCountSeats++;
                    }

                    if (row % 2 == 0)
                    {
                        countSeatsOddRow -= 2;
                    }
                }
                countRows++;
            }
            Console.WriteLine(totalCountSeats);
        }
    }
}
