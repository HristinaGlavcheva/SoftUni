using System;

namespace Game_Of_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMoves = int.Parse(Console.ReadLine());
            double result = 0;
            int from0to9 = 0;
            int from10to19 = 0;
            int from20to29 = 0;
            int from30to39 = 0;
            int from40to50 = 0;
            int invalid = 0;


            for (int counter = 1; counter <= numberMoves; counter++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number >= 0 && number <= 9)
                {
                    result += 0.2 * number;
                    from0to9++;
                }
                else if (number >= 10 && number <= 19)
                {
                    result += 0.3 * number;
                    from10to19++;
                }
                else if (number >= 20 && number <= 29)
                {
                    result += 0.4 * number;
                    from20to29++;
                }
                else if (number >= 30 && number <= 39)
                {
                    result += 50;
                    from30to39++;
                }
                else if (number >= 40 && number <= 50)
                {
                    result += 100;
                    from40to50++;
                }
                else
                {
                    result /= 2;
                    invalid++;
                }
            }

            Console.WriteLine($"{result:F2}");
            Console.WriteLine($"From 0 to 9: {(from0to9 * 1.0 / numberMoves * 100):F2}%");
            Console.WriteLine($"From 10 to 19: {(from10to19 * 1.0 / numberMoves * 100):F2}%");
            Console.WriteLine($"From 20 to 29: {(from20to29 * 1.0 / numberMoves * 100):F2}%");
            Console.WriteLine($"From 30 to 39: {(from30to39 * 1.0 / numberMoves * 100):F2}%");
            Console.WriteLine($"From 40 to 50: {(from40to50 * 1.0 / numberMoves * 100):F2}%");
            Console.WriteLine($"Invalid numbers: {(invalid * 1.0 / numberMoves * 100):F2}%");
        }
    }
}
