using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Trojan_Invasion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countWaves = int.Parse(Console.ReadLine());

            int[] platesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> plates = new Queue<int>(platesInput);
            Stack<int> waveToPrint = new Stack<int>();

            for (int i = 1; i < countWaves; i++)
            {
                int[] waveInfo = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                Stack<int> cuurentWave = new Stack<int>(waveInfo);

                if (i % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(additionalPlate);
                }

                while (cuurentWave.Any() && plates.Any())
                {
                    if (cuurentWave.Peek() > plates.Peek())
                    {
                        int newWarriorValue = cuurentWave.Pop() - plates.Dequeue();
                        cuurentWave.Push(newWarriorValue);

                        if (!plates.Any())
                        {
                            waveToPrint = new Stack<int>(cuurentWave);
                        }
                    }
                    else if (cuurentWave.Peek() == plates.Peek())
                    {
                        plates.Dequeue();
                        cuurentWave.Pop();
                    }
                    else if (cuurentWave.Peek() < plates.Peek())
                    {
                        int newPlateValue = plates.Dequeue() - cuurentWave.Pop();

                        List<int> temp = new List<int>(plates.Reverse());
                        temp.Add(newPlateValue);
                        temp.Reverse();

                        plates = new Queue<int>(temp);
                    }
                }
            }

            if (!plates.Any())
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");

                if (waveToPrint.Count > 0)
                {
                    Console.Write("Warriors left: ");
                    Console.WriteLine(String.Join(", ", waveToPrint));
                }
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");

                if (plates.Count > 0)
                {
                    Console.Write("Plates left: ");
                    Console.WriteLine(String.Join(", ", plates));
                }
            }
        }
    }
}
