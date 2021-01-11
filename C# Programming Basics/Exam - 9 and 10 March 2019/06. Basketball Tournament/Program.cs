using System;

namespace _06._Basketball_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfTournament = Console.ReadLine();
            int totalCountGames = 0;
            int wonGames = 0;
            int lostGames = 0;

            while (nameOfTournament != "End of tournaments")
            {
                int countGames = int.Parse(Console.ReadLine());
                totalCountGames += countGames;

                for (int currentGame = 1; currentGame <= countGames; currentGame++)
                {
                    int scoredPoints = int.Parse(Console.ReadLine());
                    int lostPoints = int.Parse(Console.ReadLine());
                    if(scoredPoints > lostPoints)
                    {
                        wonGames++;
                        Console.WriteLine($"Game {currentGame} of tournament {nameOfTournament}: win with {scoredPoints - lostPoints} points.");
                    }
                    else
                    {
                        lostGames++;
                        Console.WriteLine($"Game {currentGame} of tournament {nameOfTournament}: lost with {lostPoints - scoredPoints} points.");
                    }
                }
                nameOfTournament = Console.ReadLine();
            }
            double percentWonGames = wonGames*1.0 / totalCountGames * 100;
            double percentLostGames = lostGames*1.0 / totalCountGames * 100;
            Console.WriteLine($"{percentWonGames:F2}% matches win");
            Console.WriteLine($"{percentLostGames:F2}% matches lost");
        }
    }
}
