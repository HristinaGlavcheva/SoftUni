using System;

namespace _06._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int firstDigit = (number / 100) % 10;
            int secondDigit = (number / 10) % 10;
            int thirdDigit = number % 10;
            int rows = firstDigit + secondDigit;
            int columns = firstDigit + thirdDigit;

            for (int currentRow = 1; currentRow <= rows; currentRow++)
            {
                for (int currentColumn = 1; currentColumn <= columns; currentColumn++)
                {
                    if (number % 5 == 0)
                    {
                        number -= firstDigit;
                    }
                    else if (number % 3 == 0)
                    {
                        number -= secondDigit;
                    }
                    else
                    {
                        number += thirdDigit;
                    }
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        }
    }
}
