using System;

namespace _05._Gifts_from_Santa
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());
            int firstNumber = int.Parse(Console.ReadLine());
            int quittingNumber = int.Parse(Console.ReadLine());

            for (int currentNumber = firstNumber; currentNumber >= lastNumber; currentNumber--)
            {
                if (currentNumber % 2 == 0 && currentNumber % 3 == 0)
                {
                    
                    if (currentNumber == quittingNumber)
                    {
                        break;
                    }

                    Console.Write($"{currentNumber} ");
                }
            }
        }
    }
}
