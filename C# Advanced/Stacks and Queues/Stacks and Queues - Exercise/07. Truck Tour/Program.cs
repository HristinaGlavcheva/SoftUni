using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int countPumps = int.Parse(Console.ReadLine());
            int index = 0;
            int fuel = 0;
            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < countPumps; i++)
            {
                int[] currentPump = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currentPump);
            }

            for (int i = 1; i <= countPumps; i++)
            {
                fuel += pumps.Peek()[0];
                int distance = pumps.Peek()[1];

                if (fuel < distance)
                {
                    fuel = 0;

                    int[] wrongPump = pumps.Dequeue();
                    pumps.Enqueue(wrongPump);
                    index += i;
                    i = 0;
                }
                else
                {
                    fuel -= distance;
                    int[] wrongPump = pumps.Dequeue();
                    pumps.Enqueue(wrongPump);
                }
            }

            Console.WriteLine(index);

            // просто решение без опашки от форума !!!:
            //int N = int.Parse(Console.ReadLine());

            //int[] pumps = new int[N];

            //for (int i = 0; i < N; i++)
            //{
            //    int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //    pumps[i] = integers[0] - integers[1];
            //}

            //int current = 0;
            //int position = 0;

            //for (int i = 0; i < N; i++)
            //{
            //    current += pumps[i];

            //    if (current < 0)
            //    {
            //        current = 0;
            //        position = i + 1;
            //    }
            //}
            //Console.WriteLine(position);
        }
    }
}

