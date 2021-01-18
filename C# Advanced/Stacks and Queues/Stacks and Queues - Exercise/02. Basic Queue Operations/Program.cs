using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int countToAdd = input[0];
            int countToRemove = input[1];
            int numberToFind = input[2];

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < countToAdd; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < countToRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else if(queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
