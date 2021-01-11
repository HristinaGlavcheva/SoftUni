using System;

namespace _06._Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int countEasterBreads = int.Parse(Console.ReadLine());
            int maxPoints = 0;
            int totalPoints = 0;
            string bestBaker = "";

            for (int currentEastBread = 1; currentEastBread <= countEasterBreads; currentEastBread++)
            {
                string nameBaker = Console.ReadLine();
                string command = Console.ReadLine();

                while (command != "Stop")
                {
                    int points = int.Parse(command);
                    totalPoints += points;
                    command = Console.ReadLine();
                }

                Console.WriteLine($"{nameBaker} has {totalPoints} points.");
                if (totalPoints > maxPoints)
                {
                    Console.WriteLine($"{nameBaker} is the new number 1!");
                    maxPoints = totalPoints;
                    bestBaker = nameBaker;
                }
                totalPoints = 0;
            }
            Console.WriteLine($"{bestBaker} won competition with {maxPoints} points!");
        }
    }
}
