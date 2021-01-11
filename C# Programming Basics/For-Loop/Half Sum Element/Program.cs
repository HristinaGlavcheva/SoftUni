using System;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            int currentNumber = 0;
            int maxNumber = int.MinValue;
            int sum = 0;

            for (int i=1; i<=countNumbers; i++)
            {
                currentNumber = int.Parse(Console.ReadLine()); 
                sum += currentNumber; 

                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                }
            }

            sum -= maxNumber;
            if (sum == maxNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {sum}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {Math.Abs(sum-maxNumber)}");
            }

        }
    }
}
