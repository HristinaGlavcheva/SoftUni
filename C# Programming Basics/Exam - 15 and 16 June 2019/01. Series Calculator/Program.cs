using System;

namespace _01._Series_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int countSeasons = int.Parse(Console.ReadLine());
            int countEpisodes = int.Parse(Console.ReadLine());
            double timeForEpisode = int.Parse(Console.ReadLine());

            double timeForEpisodeAfterAdvertisment = timeForEpisode * 1.2;
            double addTimeForSpecialEpisodes = countSeasons * 10;

            double totalTime = timeForEpisodeAfterAdvertisment * countEpisodes * countSeasons + addTimeForSpecialEpisodes;
            Console.WriteLine($"Total time needed to watch the {seriesName} series is {Math.Floor(totalTime)} minutes.");
           
        }
    }
}
