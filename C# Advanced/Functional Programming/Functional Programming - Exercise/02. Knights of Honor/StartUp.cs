using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Action<string> printKnights = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printKnights);
        }
    }
}
