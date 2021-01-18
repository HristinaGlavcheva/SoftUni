using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isLarger = (name, charsLength)
                => name.Sum(x => x) >= charsLength;

            Func<string[], Func<string, int, bool>, string> nameFilter =
                (inputNames, isLargerFilter)
                => inputNames.FirstOrDefault(x => isLargerFilter(x, length));

            string resultName = nameFilter(names, isLarger);

            Console.WriteLine(resultName);
        }
    }
}
