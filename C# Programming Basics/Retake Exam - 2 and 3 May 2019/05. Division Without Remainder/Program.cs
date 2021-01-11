using System;

namespace _05._Division_Without_Remainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            int countP1 = 0;
            int countP2 = 0;
            int countP3 = 0;

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

            double percentP1 = countP1 * 1.0 / countNumbers * 100;
            double percentP2 = countP2 * 1.0 / countNumbers * 100;
            double percentP3 = countP3 * 1.0 / countNumbers * 100;

            Console.WriteLine($"{percentP1:F2}%");
            Console.WriteLine($"{percentP2:F2}%");
            Console.WriteLine($"{percentP3:F2}%");
        }
    }
}
