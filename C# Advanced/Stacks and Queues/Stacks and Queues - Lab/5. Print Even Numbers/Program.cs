using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> result = new List<int>();

            Queue<int> queue = new Queue<int>(numbers);

            while (queue.Count > 0)
            {
                if(queue.Peek() % 2 != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    result.Add(queue.Dequeue());
                }
            }

            Console.WriteLine(String.Join(", ", result));
        }
    }
}
