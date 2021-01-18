using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> openingBracketsIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(')
                {
                    openingBracketsIndexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = openingBracketsIndexes.Pop();
                    int endIndex = i;
                    string subexpr = input.Substring(startIndex, endIndex - (startIndex - 1));
                    Console.WriteLine(subexpr);
                }
            }
        }
    }
}
