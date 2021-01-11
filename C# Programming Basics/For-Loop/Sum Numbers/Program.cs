using System;

namespace Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= countNumbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                sum += currentNumber; 
            }

            Console.WriteLine(sum);
        }
    }
}
