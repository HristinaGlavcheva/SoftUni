using System;

namespace _02._Lunch_Break
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int episodeTime = int.Parse(Console.ReadLine());
            int breakTime = int.Parse(Console.ReadLine());

            double lunchTime = breakTime*1.0 / 8;
            double relaxTime = breakTime*1.0 / 4;
            double timeForWatchin = breakTime - lunchTime - relaxTime;

            if(timeForWatchin >= episodeTime)
            {
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {Math.Ceiling(timeForWatchin-episodeTime)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {Math.Ceiling(episodeTime - timeForWatchin)} more minutes.");
            }
        }
    }
}
