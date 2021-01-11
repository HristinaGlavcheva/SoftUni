using System;

namespace _05._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int countFloors = int.Parse(Console.ReadLine());
            int countRooms = int.Parse(Console.ReadLine());

            for (int floor = countFloors; floor > 0; floor--)
            {
                for (int room = 0; room < countRooms; room++)
                {
                    if (floor == countFloors)
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                    else
                    {
                        if (floor % 2 == 1)
                        {
                            Console.Write($"A{floor}{room} ");
                        }
                        else
                        {
                            Console.Write($"O{floor}{room} ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
