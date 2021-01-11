using System;

namespace _04._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int firstDigit = start; firstDigit <= end; firstDigit++)
            {
                for (int secondDigit = start; secondDigit <= end; secondDigit++)
                {
                    for (int thirdDigit = start; thirdDigit <= end; thirdDigit++)
                    {
                        for (int forthDigit = start; forthDigit <= end; forthDigit++)
                        {
                            bool fistCondition = (firstDigit % 2 == 0 && forthDigit % 2 == 1) || (firstDigit % 2 == 1 && forthDigit % 2 == 0);
                            bool secondCondition = firstDigit > forthDigit;
                            bool thirdCondition = (secondDigit + thirdDigit) % 2 == 0;

                            if(fistCondition && secondCondition && thirdCondition)
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
