using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStationRecruitment
{
    class SatrtUp
    {
        static void Main(string[] args)
        {
            int[] liquidsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] itemsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> liquids = new Queue<int>(liquidsInput);
            Stack<int> items = new Stack<int>(itemsInput);

            Dictionary<string, int> advancedMaterials = new Dictionary<string, int>();

            advancedMaterials["Glass"] = 0;
            advancedMaterials["Aluminium"] = 0;
            advancedMaterials["Lithium"] = 0;
            advancedMaterials["Carbon fiber"] = 0;

            while (liquids.Count > 0 && items.Count > 0)
            {
                int currentSum = liquids.Dequeue() + items.Peek();

                if(currentSum == 25)
                {
                    advancedMaterials["Glass"]++;
                    items.Pop();
                }
                else if (currentSum == 50)
                {
                    advancedMaterials["Aluminium"]++;
                    items.Pop();
                }
                else if (currentSum == 75)
                {
                    advancedMaterials["Lithium"]++;
                    items.Pop();
                }
                else if (currentSum == 100)
                {
                    advancedMaterials["Carbon fiber"]++;
                    items.Pop();
                }
                else
                {
                    items.Push(items.Pop() + 3);
                }
            }

            if (advancedMaterials["Glass"] > 0 &&
                advancedMaterials["Aluminium"] > 0 &&
                advancedMaterials["Lithium"] > 0 &&
                advancedMaterials["Carbon fiber"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if(liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.Write("Liquids left: ");
                Console.WriteLine(String.Join(", ", liquids));
            }

            if(items.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.Write("Physical items left: ");
                Console.WriteLine(String.Join(", ", items));
            }

            foreach (var material in advancedMaterials.OrderBy(m => m.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
