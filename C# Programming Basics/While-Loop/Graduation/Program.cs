using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int classCounter = 1;
            double sumGrades = 0;
            double averageGrade = 0;

            while (classCounter <= 12)
            {
                double currentGrade = double.Parse(Console.ReadLine());

                if (currentGrade >= 4.00)
                {
                    sumGrades = sumGrades + currentGrade;
                    averageGrade = sumGrades / classCounter;
                    classCounter++;
                }
            }
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade:F2}");
        }
    }
}