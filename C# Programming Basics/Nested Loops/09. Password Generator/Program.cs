using System;

namespace _09._Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            for (int firstSymbol = 1; firstSymbol <= n; firstSymbol++)
            {
                for (int secondSymbol = 1; secondSymbol <= n; secondSymbol++)
                {
                    for (char thirdSymbol = (char)97; thirdSymbol < 97 + l; thirdSymbol++)
                    { 
                        for (char fourthSymbol = (char)97; fourthSymbol < 97 + l; fourthSymbol++)
                        {
                            for (int fifthSymbol = Math.Max(firstSymbol, secondSymbol)+1; fifthSymbol <= n; fifthSymbol++)
                            {
                                Console.Write($"{firstSymbol}{secondSymbol}{thirdSymbol}{fourthSymbol}{fifthSymbol} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
