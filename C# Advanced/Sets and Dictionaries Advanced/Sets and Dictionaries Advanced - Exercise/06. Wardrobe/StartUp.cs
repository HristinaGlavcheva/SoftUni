using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countLines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> colors = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < countLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string curColor = input[0];

                if (!colors.ContainsKey(curColor))
                {
                    colors[curColor] = new Dictionary<string, int>();
                }

                Dictionary<string, int> clothesAndCounts = colors[curColor];

                string[] clothesOfCurColor = input[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);

                foreach (var clothing in clothesOfCurColor)
                {
                    if (!clothesAndCounts.ContainsKey(clothing))
                    {
                        clothesAndCounts[clothing] = 0;
                    }

                    clothesAndCounts[clothing]++;
                }
            }

            string[] wantedItem = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string wantedColor = wantedItem[0];
            string wantedClothing = wantedItem[1];

            foreach (var colorAndCltothingKvp in colors)
            {
                string color = colorAndCltothingKvp.Key;
                
                Console.WriteLine($"{color} clothes:");

                foreach (var clotheAndCountKvp in colorAndCltothingKvp.Value)
                {
                    string clothing = clotheAndCountKvp.Key;
                    int count = clotheAndCountKvp.Value;

                    if (color == wantedColor && clothing == wantedClothing)
                    {
                        Console.WriteLine($"* {clothing} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing} - {count}");
                    }
                }
            }
        }
    }
}
