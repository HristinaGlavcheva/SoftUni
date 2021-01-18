using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperFirstLetter = (word => char.IsUpper(word[0]));

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(upperFirstLetter)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
