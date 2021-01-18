using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countInputLines = int.Parse(Console.ReadLine());

            Dictionary<string, int> occurances = new Dictionary<string, int>();

            for (int i = 0; i < countInputLines; i++)
            {
                string curNumber = Console.ReadLine();

                if (!occurances.ContainsKey(curNumber))
                {
                    occurances[curNumber] = 0;
                }

                occurances[curNumber]++;
            }

            foreach (var kvp in occurances.Where(kvp => kvp.Value % 2 == 0))
            {
                 Console.WriteLine(kvp.Key);
            }
        }
    }
}
