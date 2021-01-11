using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            double sumGrades = 0;
            double topStudents = 0;
            double goodStudents = 0;
            double averageStudents = 0;
            double fail = 0;

            for (int counter = 1; counter <= countStudents; counter++)
            {
                double grade = double.Parse(Console.ReadLine());
                sumGrades += grade;

                if (grade >= 5.00)
                {
                    topStudents++;
                }
                else if (grade >= 4.00 && grade <= 4.99)
                {
                    goodStudents++;
                }
                else if (grade >= 3.00 && grade <= 3.99)
                {
                    averageStudents++;
                }
                else if (grade < 3.00)
                {
                    fail++;
                }
            }

            double averageSuccess = sumGrades / countStudents;
            Console.WriteLine($"Top students: {(topStudents/countStudents*100):F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(goodStudents / countStudents * 100):F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(averageStudents / countStudents * 100):F2}%");
            Console.WriteLine($"Fail: {(fail / countStudents * 100):F2}%");
            Console.WriteLine($"Average: {averageSuccess:F2}");
        }
    }
}
