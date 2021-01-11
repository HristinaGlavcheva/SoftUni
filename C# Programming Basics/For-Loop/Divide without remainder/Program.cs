using System;

namespace Divide_without_remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            double countP1 = 0;
            double countP2 = 0;
            double countP3 = 0;

            for (int i = 1; i <= countNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    countP1++;
                }
                if (number % 3 == 0)
                {
                    countP2++;
                }
                if (number % 4 == 0)
                {
                    countP3++;
                }
            }

            double p1 = countP1 / countNumbers * 100;
            double p2 = countP2 / countNumbers * 100;
            double p3 = countP3 / countNumbers * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
        }
    }
}
