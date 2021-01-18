using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> expr = new Stack<string>(input.Reverse());
            int result = int.Parse(expr.Pop());

            while (expr.Count > 0)
            {
                if (expr.Pop() == "+")
                {
                    result += int.Parse(expr.Pop());
                }
                else
                {
                    result -= int.Parse(expr.Pop());
                }
            }
            Console.WriteLine(result);
        }
    }
}
