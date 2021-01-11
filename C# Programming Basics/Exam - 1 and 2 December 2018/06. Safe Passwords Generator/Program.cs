using System;

namespace _06._Safe_Passwords_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int lastThirdSymbol = int.Parse(Console.ReadLine());
            int lastForthSymbol = int.Parse(Console.ReadLine());
            int maxCountPasswords = int.Parse(Console.ReadLine());
            int currentCountPassords = 0;
            int firstSymbol = 35;
            int secondSymbol = 64;

            for (int thirdSymbol = 1; thirdSymbol <= lastThirdSymbol; thirdSymbol++)
            {
                for (int forthSymbol = 1; forthSymbol <= lastForthSymbol; forthSymbol++)
                {
                    Console.Write($"{(char)firstSymbol}{(char)secondSymbol}{thirdSymbol}{forthSymbol}{(char)secondSymbol}{(char)firstSymbol}|");
                    currentCountPassords++;
                    firstSymbol++;
                    if(firstSymbol == 56)
                    {
                        firstSymbol = 35;
                    }
                    secondSymbol++;
                    if(secondSymbol == 97)
                    {
                        secondSymbol = 64;
                    }
                    if(currentCountPassords == maxCountPasswords)
                    {
                        return;
                    }
                }
            }
        }
    }
}
