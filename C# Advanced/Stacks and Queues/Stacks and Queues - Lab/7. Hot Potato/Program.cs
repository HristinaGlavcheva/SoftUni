using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(input);

            while(names.Count > 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    string currentName = names.Dequeue();

                    if (i != n)
                    {
                        names.Enqueue(currentName);
                    }
                    else
                    {
                        Console.WriteLine($"Removed {currentName}");
                    }
                }
            }

            Console.WriteLine($"Last is {names.Peek()}");
        }
    }
}
