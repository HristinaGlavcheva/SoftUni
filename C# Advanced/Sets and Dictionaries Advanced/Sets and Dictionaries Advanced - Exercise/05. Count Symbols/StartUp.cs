using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine()
               .ToCharArray();

            SortedDictionary<char, int> occurances = new SortedDictionary<char, int>();

            foreach (var ch in text)
            {
                if (!occurances.ContainsKey(ch))
                {
                    occurances[ch] = 0;
                }

                occurances[ch]++;
            }

            foreach (var ch in occurances)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
