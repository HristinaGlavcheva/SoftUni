using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sum_Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Func<string, int> parseFunc = n => int.Parse(n);
            Func<string, string[]> splitFunc = s => s.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<int> numbers = splitFunc(Console.ReadLine())
                 .Select(parseFunc)
                 .ToList();

            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
