using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackNumbers = new Stack<int>(inputNumbers);

            string[] command = Console.ReadLine()
                .ToLower()
                .Split();

            while(command[0] != "end")
            {
                if(command[0] == "add")
                {
                    stackNumbers.Push(int.Parse(command[1]));   
                    stackNumbers.Push(int.Parse(command[2]));   
                }
                else if (command[0] == "remove")
                {
                    int countToRemove = int.Parse(command[1]);

                    if(countToRemove <= stackNumbers.Count)
                    {
                        for (int i = 0; i < countToRemove; i++)
                        {
                            stackNumbers.Pop();
                        }
                    }
                }
                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int sum = stackNumbers.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
