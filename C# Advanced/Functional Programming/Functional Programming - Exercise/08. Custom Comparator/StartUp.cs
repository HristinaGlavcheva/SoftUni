using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Custom_Comparator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToList();

            Func<int, bool> isEven = n => n % 2 == 0;

            List<int> result = new List<int>();

            result = numbers.Where(isEven).ToList();

            foreach (var number in numbers.Where(n => !isEven(n)))
            {
                result.Add(number);
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
