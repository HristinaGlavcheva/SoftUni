using System;

namespace _05._Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTournirs = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int finalPoints = startPoints;
            int wonPoints = 0;
            int countWonTournirs = 0;

            for (int currentTournir = 1; currentTournir <= countTournirs; currentTournir++)
            {
                string tournirResult = Console.ReadLine();

                if (tournirResult == "W")
                {
                    finalPoints += 2000;
                    countWonTournirs++;
                }
                else if (tournirResult == "F")
                {
                    finalPoints += 1200;
                }
                else if (tournirResult == "SF")
                {
                    finalPoints += 720;
                }
            }
            double averagePoints = (finalPoints - startPoints) * 1.0 / countTournirs;
            double percentWonTournirs = (countWonTournirs * 1.0 / countTournirs) * 100;

            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{percentWonTournirs:F2}%");
        }
    }
}
