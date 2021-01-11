using System;

namespace _05._Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double startPoints = double.Parse(Console.ReadLine());
            int countAssessors = int.Parse(Console.ReadLine());
            double totalPoints = startPoints;

            for (int currentAsessor = 1; currentAsessor <= countAssessors; currentAsessor++)
            {
                string assessorName = Console.ReadLine();
                double currentPoitns = double.Parse(Console.ReadLine());
                totalPoints += assessorName.Length * currentPoitns / 2;

                if(totalPoints > 1250.5)
                {
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {totalPoints:F1}!");
                    break;
                }
            }
            if(totalPoints <= 1250.5)
            {
                Console.WriteLine($"Sorry, {actorName} you need {(1250.5 - totalPoints):F1} more!");
            }
           
        }
    }
}
