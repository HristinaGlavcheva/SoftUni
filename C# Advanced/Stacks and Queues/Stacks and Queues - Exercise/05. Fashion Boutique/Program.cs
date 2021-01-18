using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] receivedClothes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stackClothes = new Stack<int>(receivedClothes);

            int capacity = int.Parse(Console.ReadLine());

            int countRacks = 1;
            int curentRack = 0;

            while (stackClothes.Any())
            {
                curentRack += stackClothes.Peek();

                if (curentRack <= capacity)
                {
                    stackClothes.Pop();
                }
                else
                {
                    curentRack = 0;
                    countRacks++;
                }
            }

            Console.WriteLine(countRacks);
        }
    }
}
