using System;

namespace _03.Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
            {
                for (int secondDigit = 1; secondDigit <= 9; secondDigit++)
                {
                    for (int thirdDigit = 1; thirdDigit <= 9; thirdDigit++)
                    {
                        for (int forthDigit = 1; forthDigit <= 9; forthDigit++)
                        {
                            int sum1 = firstDigit + secondDigit;
                            int sum2 = thirdDigit + forthDigit;
                            if (sum1 == sum2 && n % sum1 == 0)
                            {
                                Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{forthDigit} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
