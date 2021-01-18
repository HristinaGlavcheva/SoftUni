using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> occurances = new Dictionary<double, int>();

            foreach (var number in inputNumbers)
            {
                if (!occurances.ContainsKey(number))
                {
                    occurances[number] = 0;
                }

                occurances[number]++;
            }

            foreach (var kvp in occurances)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
