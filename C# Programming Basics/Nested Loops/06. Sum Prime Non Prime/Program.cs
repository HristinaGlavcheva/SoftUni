using System;

namespace _06._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int sumPrimeNumbers = 0;
            int sumNonPrimeNumbers = 0;
            bool isPrime = true;

            while (command != "stop")
            {
                int currentNumber = int.Parse(command);

                if (currentNumber < 0)
                {
                    Console.WriteLine("Number is negative.");
                    command = Console.ReadLine();
                    continue;
                }

                if (currentNumber == 1)
                {
                    sumNonPrimeNumbers += currentNumber;
                    command = Console.ReadLine();
                    continue;
                }

                for (int i = 2; i < currentNumber; i++)
                {
                    if (currentNumber % i == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                {
                    sumPrimeNumbers += currentNumber;
                }
                else
                {
                    sumNonPrimeNumbers += currentNumber;
                }

                isPrime = true;
                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNumbers}");
        }
    }
}