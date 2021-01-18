using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int countToPush = input[0];
            int countToPop = input[1];
            int numberToFind = input[2];

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countToPush; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < countToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
