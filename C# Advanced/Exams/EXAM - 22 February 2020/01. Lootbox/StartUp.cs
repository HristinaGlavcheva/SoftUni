using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] firstBoxInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] secondBoxInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sumClaimedItems = 0;

            Queue<int> firstBox = new Queue<int>(firstBoxInfo);
            Stack<int> secondBox = new Stack<int>(secondBoxInfo);

            while (firstBox.Any() && secondBox.Any())
            {
                int currentSum = firstBox.Peek() + secondBox.Peek();

                if (currentSum % 2 == 0)
                {
                    sumClaimedItems += currentSum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumClaimedItems}");
            }
        }
    }
}
