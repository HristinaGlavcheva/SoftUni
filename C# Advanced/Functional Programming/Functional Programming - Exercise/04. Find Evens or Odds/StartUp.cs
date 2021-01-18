using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBoundary = boundaries[0];
            int upperBoundary = boundaries[1];

            List<int> numbers = new List<int>();

            string command = Console.ReadLine();

            for (int i = lowerBoundary; i <= upperBoundary; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> even = n => n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;

            switch (command)
            {
                case "even":
                    numbers = numbers.FindAll(even);
                    break;
                default:
                    numbers = numbers.FindAll(odd);
                    break;
            }

            //numbers = command switch
            //{
            //    "even" => numbers.FindAll(even),
            //    _ => numbers.FindAll(odd),
            //};

            Console.WriteLine(String.Join(" ", numbers));

            //Func<int, bool> filterFunc = command switch
            //{
            //    "even" => n => n % 2 == 0,
            //    "odd" => n => n % 2 != 0,
            //    _=> null
            //};

            ////numbers = numbers.Where(filterFunc).ToList();

            //Console.WriteLine(String.Join(" ", numbers.Where(filterFunc).ToList()));
        }
    }
}
