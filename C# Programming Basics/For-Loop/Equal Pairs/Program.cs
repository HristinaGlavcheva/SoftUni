using System;

namespace Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPairs = int.Parse(Console.ReadLine());
            int firstSum = 0;
            int diff = 0;
            int maxDiff = 0;

            for (int i = 1 ; i <= countPairs; i++)
            {
                int number1 = int.Parse(Console.ReadLine());
                int number2 = int.Parse(Console.ReadLine());
                int sum = number1 + number2;

                if (i == 1)
                {
                    firstSum = number1 + number2;
                }
                else
                {
                    diff = Math.Abs(sum - firstSum);

                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }

                    firstSum = sum;
                }
            }

            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={firstSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}

