using System;

namespace _02._Football_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string firstGameResult = Console.ReadLine();
            string secondGameResult = Console.ReadLine();
            string thirdGameResult = Console.ReadLine();*/
            int countWonGames = 0;
            int countLostGames = 0;
            int countDrawnGames = 0;

            for (int numberGame = 1; numberGame <= 3; numberGame++)
            {
                string gameResult = Console.ReadLine();
                if (gameResult[0] > gameResult[2])
                {
                    countWonGames++;
                }
                else if (gameResult[0] < gameResult[2])
                {
                    countLostGames++;
                }
                else
                {
                    countDrawnGames++;
                }

                /*if(firstGameResult[0] > firstGameResult[2])
                {
                    countWonGames++;
                }
                else if(firstGameResult[0] < firstGameResult[2])
                {
                    countLostGames++;
                }
                else if (firstGameResult[0] == firstGameResult[2])
                {
                    countDrawnGames++;
                }*/
            }
            Console.WriteLine($"Team won {countWonGames} games.");
            Console.WriteLine($"Team lost {countLostGames} games.");
            Console.WriteLine($" Drawn games: {countDrawnGames}");
        }
    }
}
