using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _1._Dating_App
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            int[] malesInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] femalesInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> males = new Stack<int>(malesInfo);
            Queue<int> females = new Queue<int>(femalesInfo);
            int matchesCount = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                
                if(females.Peek() <= 0)
                {
                    females.Dequeue();
                }
                else if (males.Peek() <= 0)
                {
                    males.Pop();
                }
                else if (females.Peek() % 25 == 0)
                {
                    females.Dequeue();

                    if(females.Count > 0)
                    {
                        females.Dequeue();
                    }
                }
                else if (males.Peek() % 25 == 0)
                {
                    males.Pop();

                    if(males.Count > 0)
                    {
                        males.Pop();
                    }
                }
                else if(males.Peek() == females.Peek())
                {
                    matchesCount++;
                    males.Pop();
                    females.Dequeue();
                }
                else if(males.Peek() != females.Peek())
                {
                    females.Dequeue();

                    int decreasedMale = males.Pop() - 2;
                    males.Push(decreasedMale);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if(males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.Write("Males left: ");
                Console.WriteLine(string.Join(", ", males));
            }

            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.Write("Females left: ");
                Console.WriteLine(string.Join(", ", females));
            }
        }

    }
}
