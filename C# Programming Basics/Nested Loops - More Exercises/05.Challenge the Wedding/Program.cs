using System;

namespace _05.Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int countMen = int.Parse(Console.ReadLine());
            int countWomen = int.Parse(Console.ReadLine());
            int maxTables = int.Parse(Console.ReadLine());
            int numberTable = 1;

            for (int numberMan = 1; numberMan <= countMen; numberMan++)
            {
                for (int numberWoman = 1; numberWoman <= countWomen; numberWoman++)
                {
                    if (numberTable <= maxTables)
                    {
                        Console.Write($"({numberMan} <-> {numberWoman}) ");
                    }
                    else
                    {
                        break;
                    }
                    numberTable++;
                }
            }

        }
    }
}
