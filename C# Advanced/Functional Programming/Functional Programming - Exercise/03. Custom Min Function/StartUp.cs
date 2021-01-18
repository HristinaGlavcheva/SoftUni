using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> minFunc = x => x.Min();

            Console.WriteLine(minFunc(numbers));
        }
    }
}
