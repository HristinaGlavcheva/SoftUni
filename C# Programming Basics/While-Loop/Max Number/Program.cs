using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            int counter = 1;
            int maxNumber=int.MinValue;

            while (counter<=countNumbers)
            {
                int number = int.Parse(Console.ReadLine());
                if (number >= maxNumber)
                {
                    maxNumber = number;
                }
                counter++;
            }

            Console.WriteLine(maxNumber);
        }
    }
}
