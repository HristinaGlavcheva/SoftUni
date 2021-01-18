using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int countQueries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countQueries; i++)
            {
                string[] query = Console.ReadLine().Split();
                string typeQuery = query[0];

                if(typeQuery == "1")
                {
                    int numberToPush = int.Parse(query[1]);
                    stack.Push(numberToPush);
                }
                else if (stack.Any())
                {
                    if (typeQuery == "2")
                    {
                        stack.Pop();
                    }
                    else if (typeQuery == "3")
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (typeQuery == "4")
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
