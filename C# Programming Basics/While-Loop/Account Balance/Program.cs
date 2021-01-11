using System;

namespace Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTransactions = int.Parse(Console.ReadLine());
            int counter = 1;
            double totalSum=0;

            while (counter <= countTransactions)
            {
                double increaseSum = double.Parse(Console.ReadLine());

                if (increaseSum<0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {increaseSum:F2}");
                totalSum += increaseSum;
                counter += 1;
            }

            Console.WriteLine($"Total: {totalSum:F2}");
        
        }
    }
}
