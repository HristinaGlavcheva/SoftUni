using System;

namespace _04._Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = Console.ReadLine();
            int maxGoals = 0;
            string bestPLayer = String.Empty;

            while (player != "END")
            {
                int goals = int.Parse(Console.ReadLine());
                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    bestPLayer = player;
                }

                if (goals >= 10)
                {
                    break;
                }

                player = Console.ReadLine();
            }

            Console.WriteLine($"{bestPLayer} is the best player!");
            if (maxGoals >= 3)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
