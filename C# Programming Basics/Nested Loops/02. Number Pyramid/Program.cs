using System;

namespace _02._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            int currentNumber = 1;
            bool isBigger = false;

            for (int row = 1; row <= countNumbers; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    if (currentNumber > countNumbers)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write($"{currentNumber} ");
                    currentNumber++;
                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
