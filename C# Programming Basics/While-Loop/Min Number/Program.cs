using System;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            int counter = 1;
            int minNumber = int.MaxValue;

            while (counter <= countNumbers)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < minNumber)
                {
                    minNumber = number;
                }
                counter++;
            }

            Console.WriteLine(minNumber);
        }
    }
}
