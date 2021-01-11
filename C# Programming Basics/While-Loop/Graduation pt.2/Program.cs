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
            int failsCounter = 0;

            while (classCounter <= 12 && failsCounter<=1)
            {
                double currentGrade = double.Parse(Console.ReadLine());

                if (currentGrade >= 4.00)
                {
                    sumGrades = sumGrades + currentGrade;
                    averageGrade = sumGrades / classCounter;
                    classCounter++;
                }

                else if (currentGrade < 4)
                {
                    failsCounter++;
                } 

                if (failsCounter > 1)
                {
                    break;
                }
            }

            
            if (failsCounter <= 1)
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:F2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {classCounter} grade");
            }

        }
    }
}