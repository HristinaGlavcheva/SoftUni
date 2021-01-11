using System;

namespace _02._Movie_Day
{
    class Program
    {
        static void Main(string[] args)
        {
            int availableTimeForShooting = int.Parse(Console.ReadLine());
            int countScenes = int.Parse(Console.ReadLine());
            int sceneDuration = int.Parse(Console.ReadLine());

            double preparationTime = 0.15 * availableTimeForShooting;
            int neededTimeForShooting = countScenes * sceneDuration;
            double totalNeededTime = preparationTime + neededTimeForShooting;

            if(totalNeededTime <= availableTimeForShooting)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {(availableTimeForShooting - totalNeededTime):F0} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {totalNeededTime - availableTimeForShooting} minutes.");
            }
        }
    }
}
