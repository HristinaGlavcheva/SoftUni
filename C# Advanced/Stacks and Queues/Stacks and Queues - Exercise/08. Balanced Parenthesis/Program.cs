using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            bool balanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    stack.Push(input[i]);
                }
                else
                {
                    if (stack.Any() && (input[i] == stack.Peek() + 1 || input[i] == stack.Peek() + 2))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        balanced = false;
                        break; 
                    }
                }
            }

            Console.WriteLine(balanced ? "YES" : "NO");

            //if (balanced)
            //{
            //    Console.WriteLine("YES");
            //}
            //else
            //{
            //    Console.WriteLine("NO");
            //}
        }
    }
}
