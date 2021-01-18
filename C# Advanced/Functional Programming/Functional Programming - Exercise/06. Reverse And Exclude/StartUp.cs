using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            Func<int, bool> removeCriteria = n => n % divisor != 0;

            Console.WriteLine(String.Join(" ", numbers.Where(removeCriteria).Reverse()));

            //Predicate<int> removeCriteria = n => n % divisor != 0;

            //numbers
            //    .Where(n => removeCriteria(n))
            //    .Reverse()
            //    .ToList()
            //    .ForEach(n => Console.Write(n + " "));
        }
    }
}
