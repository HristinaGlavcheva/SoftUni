using System;

namespace _06._Movie_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int firstSymbol = a1; firstSymbol <= a2-1; firstSymbol++)
            {
                for (int secondSymbol = 1; secondSymbol <= n-1; secondSymbol++)
                {
                    for (int thirdSymbol = 1; thirdSymbol <= n / 2 -1; thirdSymbol++)
                    {
                        if(firstSymbol % 2 == 1 && (secondSymbol + thirdSymbol + firstSymbol) % 2 == 1)
                        {
                            Console.WriteLine($"{(char)firstSymbol}-{secondSymbol}{thirdSymbol}{firstSymbol}");
                        }
                    }
                }
            }

        }
    }
}
