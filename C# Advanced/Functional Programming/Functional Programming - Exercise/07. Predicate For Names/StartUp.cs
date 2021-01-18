using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int maxLength = int.Parse(Console.ReadLine());

            Predicate<string> acceptable = n => n.Length <= maxLength;

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(n => acceptable(n))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
