using System;

namespace _04._Group_Stage
{
    class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            int countGames = int.Parse(Console.ReadLine());
            int currentGoalDifference = 0;
            int totalGoalDifference = 0;
            int points = 0;

            for (int currentGame = 1; currentGame <= countGames; currentGame++)
            {
                int scoredGoals = int.Parse(Console.ReadLine());
                int receivedGoals = int.Parse(Console.ReadLine());
                currentGoalDifference = scoredGoals - receivedGoals;

                if (currentGoalDifference > 0)
                {
                    points += 3;
                }
                else if (currentGoalDifference == 0)
                {
                    points++;
                }

                totalGoalDifference += currentGoalDifference;
                currentGoalDifference = 0;
            }

            if (totalGoalDifference >= 0)
            {
                Console.WriteLine($"{teamName} has finished the group phase with {points} points.");
                Console.WriteLine($"Goal difference: {totalGoalDifference}.");
            }
            else
            {
                Console.WriteLine($"{teamName} has been eliminated from the group phase.");
                Console.WriteLine($"Goal difference: {totalGoalDifference}.");
            }
        }
    }
}
