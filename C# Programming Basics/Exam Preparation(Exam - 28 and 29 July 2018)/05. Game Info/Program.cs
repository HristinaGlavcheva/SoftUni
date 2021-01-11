using System;

namespace _05._Game_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int countGames = int.Parse(Console.ReadLine());

            int totalDurationOfAllGames = 0;
            int countPanaltiesGames = 0;
            int countAdditionalTimeGames = 0;

            for (int currentGame = 1; currentGame <= countGames; currentGame++)
            {
                int gameDuration = int.Parse(Console.ReadLine());
                totalDurationOfAllGames += gameDuration;

                if (gameDuration > 90 && gameDuration <= 120)
                {
                    countAdditionalTimeGames++;
                }
                else if (gameDuration > 120)
                {
                    countPanaltiesGames++;
                }
            }

            double averageDuration = totalDurationOfAllGames*1.0 / countGames;

            Console.WriteLine($"{teamName} has played {totalDurationOfAllGames} minutes. Average minutes per game: {averageDuration:F2}");
            Console.WriteLine($"Games with penalties: {countPanaltiesGames}");
            Console.WriteLine($"Games with additional time: {countAdditionalTimeGames}");
        }
    }
}
