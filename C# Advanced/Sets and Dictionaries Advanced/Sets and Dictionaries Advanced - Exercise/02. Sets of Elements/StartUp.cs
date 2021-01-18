using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] setsLengths = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstSetLength = setsLengths[0];
            int secondSetLength = setsLengths[1];

            HashSet<string> firstSet = new HashSet<string>();
            HashSet<string> secondtSet = new HashSet<string>();
            Queue<string> equelElemets = new Queue<string>();

            FillingSet(firstSetLength, firstSet);
            FillingSet(secondSetLength, secondtSet);

            foreach (var number in firstSet)
            {
                if (secondtSet.Contains(number))
                {
                    equelElemets.Enqueue(number);
                }
            }

            Console.WriteLine(String.Join(" ", equelElemets));
        }

        private static void FillingSet(int setLength, HashSet<string> hashset)
        {
            for (int i = 0; i < setLength; i++)
            {
                string curElement = Console.ReadLine();
                hashset.Add(curElement);
            }
        }
    }
}
