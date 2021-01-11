using System;

namespace _06._Substitute
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIntervalFirstDigitFirstNumber = int.Parse(Console.ReadLine());
            int startIntervalSecondDigitFirstNumber = int.Parse(Console.ReadLine());
            int startIntervalFirstDigitSecondNumber = int.Parse(Console.ReadLine());
            int startIntervalSecondDigitSecondNumber = int.Parse(Console.ReadLine());
            int counterSubstitue = 0;

            for (int firstDigitFirstNumber = startIntervalFirstDigitFirstNumber; firstDigitFirstNumber <= 8; firstDigitFirstNumber++)
            {
                for (int secondDigitFirstNumber = 9; secondDigitFirstNumber >= startIntervalSecondDigitFirstNumber; secondDigitFirstNumber--)
                {
                    for (int firstDigitSecondNumber = startIntervalFirstDigitSecondNumber; firstDigitSecondNumber <= 8; firstDigitSecondNumber++)
                    {
                        for (int secondDigitSecondNumber = 9; secondDigitSecondNumber >= startIntervalSecondDigitSecondNumber; secondDigitSecondNumber--)
                        {
                            if (counterSubstitue >= 6)
                            {
                                break;
                            }
                            if (firstDigitFirstNumber % 2 == 0 && secondDigitFirstNumber % 2 == 1 && firstDigitSecondNumber % 2 == 0 && secondDigitSecondNumber % 2 == 1)
                            {
                                if (firstDigitFirstNumber != firstDigitSecondNumber || secondDigitFirstNumber != secondDigitSecondNumber)
                                {
                                    Console.WriteLine($"{firstDigitFirstNumber}{secondDigitFirstNumber} - {firstDigitSecondNumber}{secondDigitSecondNumber}");
                                    counterSubstitue++;
                                }
                                else
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                
                            }
                        }
                    }
                }
            }


        }
    }
}
