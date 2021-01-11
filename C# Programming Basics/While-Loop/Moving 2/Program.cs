using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeSpace = width * lenght * height;
            int occupiedSpace = 0;
            string readlineInput = Console.ReadLine();

            while (readlineInput != "Done")
            {

                int countBoxes = int.Parse(readlineInput);
                occupiedSpace += countBoxes;
                if (freeSpace < occupiedSpace)
                {
                    Console.WriteLine($"No more free space! You need {occupiedSpace - freeSpace} Cubic meters more.");
                    break;
                }

                readlineInput = Console.ReadLine();
            }

            if (readlineInput == "Done")
            {
                Console.WriteLine($"{freeSpace - occupiedSpace} Cubic meters left.");
            }
        }
    }
}
