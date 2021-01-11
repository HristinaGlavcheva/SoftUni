using System;

namespace _04._Own_Bussiness
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int freeSpace = width * lenght * height;
            string command = Console.ReadLine();
            int occupiedSpace = 0;

            while (command != "Done")
            {
                int countComputers = int.Parse(command);
                occupiedSpace += countComputers;
                if (occupiedSpace > freeSpace)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if(command == "Done")
            {
                Console.WriteLine($"{freeSpace - occupiedSpace} Cubic meters left."); 
            }
            else
            {
                Console.WriteLine($"No more free space! You need {occupiedSpace - freeSpace} Cubic meters more.");
            }
        }
    }
}
