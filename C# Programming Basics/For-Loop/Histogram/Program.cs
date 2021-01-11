using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            double countP1 = 0;
            double countP2 = 0;
            double countP3 = 0;
            double countP4 = 0;
            double countP5 = 0;

            for (int i = 1; i <= countNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    countP1++;
                }
                else if (number >= 200 && number < 400)
                {
                    countP2++;
                }
                else if (number >= 400 && number < 600)
                {
                    countP3++;
                }
                else if (number >= 600 && number < 800)
                {
                    countP4++;
                }
                else if (number >= 800)
                {
                    countP5++;
                }
            }

            double p1 = countP1 / countNumbers * 100;
            double p2 = countP2 / countNumbers * 100;
            double p3 = countP3 / countNumbers * 100;
            double p4 = countP4 / countNumbers * 100;
            double p5 = countP5 / countNumbers * 100;

            Console.WriteLine($"{p1:F2}%");
            Console.WriteLine($"{p2:F2}%");
            Console.WriteLine($"{p3:F2}%");
            Console.WriteLine($"{p4:F2}%");
            Console.WriteLine($"{p5:F2}%");
        }
    }
}
