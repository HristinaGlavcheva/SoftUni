using System;

namespace _04._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= 3; firstDigit++)
            {
                for (int secondDigit = 0; secondDigit <= 9; secondDigit++)
                {
                    for (int thirdDigit = 0; thirdDigit <= 9; thirdDigit++)
                    {
                        for (int fourhtDigit = 0; fourhtDigit <= 9; fourhtDigit++)
                        {
                            for (int fifthDigit = 0; fifthDigit <= 9; fifthDigit++)
                            {
                                for (int sixthDigit = 0; sixthDigit <= 9; sixthDigit++)
                                {
                                    int number = firstDigit * 100000 + secondDigit * 10000 + thirdDigit * 1000 + fourhtDigit * 100 + fifthDigit * 10 + sixthDigit;
                                    if (number >= firstNumber && number <= secondNumber)
                                    {
                                        if (firstDigit+thirdDigit+fifthDigit == secondDigit + fourhtDigit + sixthDigit)
                                        {
                                            Console.Write($"{firstDigit}{secondDigit}{thirdDigit}{fourhtDigit}{fifthDigit}{sixthDigit} ");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}
