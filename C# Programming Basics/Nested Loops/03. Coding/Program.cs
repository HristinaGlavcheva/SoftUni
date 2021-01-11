using System;

namespace _03._Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int countDigits = 1;
            int counterDigits = number;

            while (counterDigits / 10 != 0)
            {
                counterDigits /= 10;
                countDigits ++;
            }

            for (int row = 1; row <= countDigits; row++)
            {
                int countSymbols = number % 10;

                if(countSymbols == 0)
                {
                    Console.WriteLine("ZERO");
                    number /= 10;
                    continue;
                }

                for (int i = countSymbols; i >= 1; i--)
                {
                    int symbol = countSymbols + 33;
                    Console.Write((char)symbol);
                }
                Console.WriteLine();
                number /= 10;
            }
            
        }
    }
}
