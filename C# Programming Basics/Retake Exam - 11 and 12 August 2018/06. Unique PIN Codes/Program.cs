using System;

namespace _06._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFirstDigit = int.Parse(Console.ReadLine());
            int maxSecondDigit = int.Parse(Console.ReadLine());
            int maxThirdDigit = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= maxFirstDigit; firstDigit++)
            {
                for (int secondDigit = 1; secondDigit <= maxSecondDigit; secondDigit++)
                {
                    for (int thirdDigit = 1; thirdDigit <= maxThirdDigit; thirdDigit++)
                    {
                        if (firstDigit % 2 == 0 && thirdDigit % 2 == 0 && (secondDigit == 2 || secondDigit == 3 || secondDigit == 5 || secondDigit == 7))
                        {
                            Console.Write($"{firstDigit} {secondDigit} {thirdDigit}");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
