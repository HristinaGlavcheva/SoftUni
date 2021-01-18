using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countLines = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < countLines; i++)
            {
                string[] inputElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in inputElements)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(String.Join(" ", elements));
        }
    }
}
