using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            Func<List<int>, List<int>> add = numbers => numbers.Select(n => n = n + 1).ToList();
            Func<List<int>, List<int>> multiply = numbers => numbers.Select(n => n = n * 2).ToList();
            Func<List<int>, List<int>> subtract = numbers => numbers.Select(n => n = n - 1).ToList();
            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers); 
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
