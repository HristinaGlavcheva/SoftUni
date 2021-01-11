using System;

namespace _07._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countJudges = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double sumGrades = 0;
            double sumAverageGrades = 0;
            int counter = 0;

            while (presentationName != "Finish")
            {
                for (int countGrades = 1; countGrades <= countJudges; countGrades++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumGrades += grade;
                }

                double averageGradeForPresentation = sumGrades / countJudges;
                sumAverageGrades += averageGradeForPresentation;
                counter++;
                Console.WriteLine($"{presentationName} - {averageGradeForPresentation:F2}.");
                presentationName = Console.ReadLine();
                sumGrades = 0;
            }

            double finalAverageGrade = sumAverageGrades / counter;
            Console.WriteLine($"Student's final assessment is {finalAverageGrade:F2}.");
        }
    }
}
