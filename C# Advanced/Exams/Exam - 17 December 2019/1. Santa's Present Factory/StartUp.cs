using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1._Santa_s_Present_Factory
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] materialsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] magicLevelsInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> materials = new Stack<int>(materialsInfo);
            Queue<int> magicLevels = new Queue<int>(magicLevelsInfo);

            Dictionary<string, int> toys = new Dictionary<string, int>();

            toys["Doll"] = 0;
            toys["Wooden train"] = 0;
            toys["Teddy bear"] = 0;
            toys["Bicycle"] = 0;

            while (materials.Count > 0 && magicLevels.Count > 0)
            {
                if (materials.Peek() == 0 || magicLevels.Peek() == 0)
                {
                    if (magicLevels.Peek() == 0)
                    {
                        magicLevels.Dequeue();
                    }

                    if (materials.Peek() == 0)
                    {
                        materials.Pop();
                    }

                    continue;
                }

                int totalMagicLevel = materials.Peek() * magicLevels.Peek();

                if (totalMagicLevel == 150)
                {
                    toys["Doll"]++;
                    materials.Pop();
                    magicLevels.Dequeue();
                }
                else if (totalMagicLevel == 250)
                {
                    toys["Wooden train"]++;
                    materials.Pop();
                    magicLevels.Dequeue();
                }
                else if (totalMagicLevel == 300)
                {
                    toys["Teddy bear"]++;
                    materials.Pop();
                    magicLevels.Dequeue();
                }
                else if (totalMagicLevel == 400)
                {
                    toys["Bicycle"]++;
                    materials.Pop();
                    magicLevels.Dequeue();
                }
                else if (totalMagicLevel < 0)
                {
                    int newMaterial = materials.Pop() + magicLevels.Dequeue();
                    materials.Push(newMaterial);
                }
                else if (materials.Peek() > 0 && !magicLevels.Any(ml => ml == materials.Peek()))
                {
                    magicLevels.Dequeue();
                    int newMaterial = materials.Pop() + 15;
                    materials.Push(newMaterial);
                }
            }

            if ((toys["Doll"] > 0 && toys["Wooden train"] > 0) || (toys["Teddy bear"] > 0 && toys["Bicycle"] > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if(materials.Count > 0)
            {
                Console.Write("Materials left: ");
                Console.WriteLine(String.Join(", ", materials));
            }

            if (magicLevels.Count > 0)
            {
                Console.Write("Magic left: ");
                Console.WriteLine(String.Join(", ", magicLevels));
            }

            foreach (var toy in toys.Where(t => t.Value > 0).OrderBy(t => t.Key))
            {
                Console.WriteLine($"{toy.Key}: {toy.Value}");
            }
        }
    }
}
