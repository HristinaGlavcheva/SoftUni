using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int lastNumber = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();
            List<int> result = new List<int>();

            for (int i = 1; i <= lastNumber; i++)
            {
                numbers.Add(i);
            }

            List<int> dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            bool isDivisible = false;

            foreach (var number in numbers)
            {
                foreach (var divider in dividers)
                {
                    Predicate<int> dividing = n => n % divider == 0;

                    //isDivisible = dividing(number) ? true : false;

                    if (dividing(number))
                    {
                        isDivisible = true; 
                    }
                    else
                    {
                        isDivisible = false;
                    }

                    if (!isDivisible)
                    {
                        break;
                    }
                }

                if (isDivisible)
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
