using System;

namespace Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxPoorGrades = int.Parse(Console.ReadLine());
            int countPoorGrades = 0;
            string nameProblem = "";
            string lastProblem = "";
            double averageScore = 0;
            int countProblems = 0;
            int sumGrades = 0;

            while (countPoorGrades < maxPoorGrades)
            {
                nameProblem = Console.ReadLine();

                if (nameProblem == "Enough")
                {
                    break;
                }

                int currentGrade = int.Parse(Console.ReadLine());
                sumGrades += currentGrade;
                countProblems++;
                lastProblem = nameProblem;
                averageScore = sumGrades*1.0  / countProblems;

                if (currentGrade <= 4)
                {
                    countPoorGrades++;
                }

                if (countPoorGrades == maxPoorGrades)
                {
                    Console.WriteLine($"You need a break, {countPoorGrades} poor grades.");
                    break;
                }
            }

            if (nameProblem == "Enough")
            {
                Console.WriteLine($"Average score: {averageScore:F2}");
                Console.WriteLine($"Number of problems: {countProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }

        }
    }
}
