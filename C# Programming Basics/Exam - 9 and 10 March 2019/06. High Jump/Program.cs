using System;

namespace _06._High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int goalHeight = int.Parse(Console.ReadLine());
            int failJumps = 0;
            int totalJumps = 0;
            int currentHeight = goalHeight - 30; ;

            while (currentHeight <= goalHeight)
            {
                int jumpHeight = int.Parse(Console.ReadLine());
                totalJumps++;
                if(jumpHeight <= currentHeight)
                {
                    failJumps++;
                    if (failJumps == 3)
                    {
                        Console.WriteLine($"Tihomir failed at {currentHeight}cm after {totalJumps} jumps.");
                        return;
                    }
                }
                else
                {
                    failJumps = 0;
                    currentHeight += 5;
                }
            }

            Console.WriteLine($"Tihomir succeeded, he jumped over {currentHeight-5}cm after {totalJumps} jumps.");
        }
    }
}
