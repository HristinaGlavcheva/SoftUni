using System;

namespace _01._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxFirstDigit = int.Parse(Console.ReadLine());
            int maxSecondDigit = int.Parse(Console.ReadLine());
            int maxThirdDigit = int.Parse(Console.ReadLine());

            for (int firstDigit = 2; firstDigit <= maxFirstDigit; firstDigit += 2)
            {
                for (int secondDigit = 1; secondDigit <= maxSecondDigit; secondDigit++)
                {
                    for (int thirddigit = 2; thirddigit <= maxThirdDigit; thirddigit += 2)
                    {
                        if (secondDigit == 2 || secondDigit == 3 || secondDigit == 5 || secondDigit == 7)
                        {
                            Console.WriteLine($"{firstDigit} {secondDigit} {thirddigit}");
                        }
                    }
                }
            }
        }
    }
}
