using System;

namespace _02._Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char invalid = char.Parse(Console.ReadLine());
            int countValidCombinations = 0;

            for (char firstLetter = start; firstLetter <= end; firstLetter++)
            {
                for (char secondLetter = start; secondLetter <= end; secondLetter++)
                {
                    for (char thirdLetter = start; thirdLetter <= end; thirdLetter++)
                    {
                        if (firstLetter != invalid && secondLetter != invalid && thirdLetter != invalid)
                        {
                            countValidCombinations++;
                            Console.Write($"{firstLetter}{secondLetter}{thirdLetter} ");
                        }
                    }
                }
            }
            Console.Write(countValidCombinations);
        }
    }
}
