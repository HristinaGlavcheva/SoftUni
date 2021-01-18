using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToList();

            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
