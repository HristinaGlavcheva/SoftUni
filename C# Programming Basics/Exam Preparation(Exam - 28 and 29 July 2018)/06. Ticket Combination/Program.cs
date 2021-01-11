using System;

namespace _06._Ticket_Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int luckyNumber = int.Parse(Console.ReadLine());
            int counterCombinations = 0;
            int prizeSum = 0;

            for (int stadiumName = 'B'; stadiumName <= 'L'; stadiumName += 2)
            {
                for (int sectorName = 'f'; sectorName >= 'a'; sectorName--)
                {
                    for (int entrance = 'A'; entrance <= 'C'; entrance++)
                    {
                        for (int row = 1; row <= 10; row++)
                        {
                            for (int seat = 10; seat >= 1; seat--)
                            {
                                counterCombinations++;
                                prizeSum = stadiumName + sectorName + entrance + row + seat;

                                if (counterCombinations == luckyNumber)
                                {
                                    Console.WriteLine($"Ticket combination: {(char)stadiumName}{(char)sectorName}{(char)entrance}{row}{seat}");
                                    Console.WriteLine($"Prize: {prizeSum} lv.");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
        }
    }
}
