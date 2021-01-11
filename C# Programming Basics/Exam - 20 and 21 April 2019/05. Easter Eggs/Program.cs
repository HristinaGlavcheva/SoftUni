using System;

namespace _05._Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNumberEggs = int.Parse(Console.ReadLine());
            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEgs = 0;
            int maxEggs = 0;
            string maxColour = string.Empty;

            for (int countEggs = 1; countEggs <= totalNumberEggs; countEggs++)
            {
                string colour = Console.ReadLine();
                if (colour == "red")
                {
                    redEggs++;
                    if (redEggs > maxEggs)
                    {
                        maxEggs = redEggs;
                        maxColour = colour;
                    }
                }
                else if (colour == "orange")
                {
                    orangeEggs++;
                    if (orangeEggs > maxEggs)
                    {
                        maxEggs = orangeEggs;
                        maxColour = colour;
                    }
                }
                else if (colour == "blue")
                {
                    blueEggs++;
                    if (blueEggs > maxEggs)
                    {
                        maxEggs = blueEggs;
                        maxColour = colour;
                    }
                }
                else if (colour == "green")
                {
                    greenEgs++;
                    if (greenEgs > maxEggs)
                    {
                        maxEggs = greenEgs;
                        maxColour = colour;
                    }
                }
            }

            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEgs}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {maxColour}");
        }
    }
}
