using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] inputOrders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> waitingOrders = new Queue<int>(inputOrders);

            Console.WriteLine(waitingOrders.Max());

            for (int i = 0; i < inputOrders.Length; i++)
            {
                int currentOrder = waitingOrders.Peek();

                if(currentOrder <= foodQuantity)
                {
                    waitingOrders.Dequeue();
                    foodQuantity -= currentOrder;
                }
            }

            if (waitingOrders.Any())
            {
                Console.WriteLine($"Orders left: {String.Join(" ", waitingOrders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
