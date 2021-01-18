using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Socks
{
    class StartUp
    {
        private static object stack;

        static void Main(string[] args)
        {
            int[] leftInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rightInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocks = new Stack<int>(leftInput);
            Queue<int> rightSocks = new Queue<int>(rightInput);
            List<int> pairs = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                int currentSum = 0;

                if (leftSocks.Peek() > rightSocks.Peek())
                {
                    currentSum = leftSocks.Pop() + rightSocks.Dequeue();
                    pairs.Add(currentSum);
                }
                else if (leftSocks.Peek() == rightSocks.Peek())
                {
                    rightSocks.Dequeue();
                    int lastLeftSock = leftSocks.Pop() + 1;
                    leftSocks.Push(lastLeftSock);
                }
                else
                {
                    leftSocks.Pop();
                }
            }

            Console.WriteLine(pairs.Max());

            Console.WriteLine(String.Join(" ", pairs);
        }
    }
}
