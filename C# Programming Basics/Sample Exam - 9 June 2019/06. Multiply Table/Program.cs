using System;

namespace _06._Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int thirdDigit = 1; thirdDigit <= number % 10; thirdDigit++)
            {
                for (int secondDigit = 1; secondDigit <= (number / 10) % 10; secondDigit++)
                {
                    for (int firstDitig = 1; firstDitig <= number / 100; firstDitig++)
                    {
                        int result = firstDitig * secondDigit * thirdDigit;
                        Console.WriteLine($"{thirdDigit} * {secondDigit} * {firstDitig} = {result};");
                    }
                }
            }
        }
    }
}
