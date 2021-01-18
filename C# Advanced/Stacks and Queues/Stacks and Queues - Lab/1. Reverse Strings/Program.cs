using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            //или го пълним директно:
            //Stack<char> stack = new Stack<char>(input);

            while (stack.Count > 0) //или while(stack.Any())
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
