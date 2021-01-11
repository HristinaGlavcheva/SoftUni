using System;

namespace _05._Equal_Sums_Left_Right_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondtNumber = int.Parse(Console.ReadLine());

            for (int firstDigit = 1; firstDigit <= 9; firstDigit++)
            {
                for (int secondDigit = 0; secondDigit <= 9; secondDigit++)
                {
                    for (int thirdDigit = 0; thirdDigit <= 9; thirdDigit++)
                    {
                        for (int fourthDigit = 0; fourthDigit <= 9; fourthDigit++)
                        {
                            for (int fifthDigit = 0; fifthDigit <= 9; fifthDigit++)
                            {
                                int number = firstDigit * 10000 + secondDigit * 1000 + thirdDigit * 100 + fourthDigit * 10 + fifthDigit;
                                if (number >= firstNumber && number <= secondtNumber)
                                {
                                    int leftSum = firstDigit + secondDigit;
                                    int rightSum = fourthDigit + fifthDigit;
                                    if(leftSum == rightSum)
                                    {
                                        Console.Write($"{number} ");
                                    }
                                    else
                                    {
                                        int smallerSum = Math.Min(leftSum, rightSum);
                                        int biggerSum = Math.Max(leftSum, rightSum);
                                        int newSum = smallerSum + thirdDigit;

                                        if (biggerSum == newSum)
                                        {
                                            Console.Write($"{number} ");
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
