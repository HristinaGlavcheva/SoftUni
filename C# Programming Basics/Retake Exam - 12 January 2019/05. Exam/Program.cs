using System;

namespace _05._Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            int topStudents = 0;
            int goodStudents = 0;
            int badStudents = 0;
            int fail = 0;
            double sumGrades = 0;

            for (int currentStudent = 1; currentStudent <= countStudents; currentStudent++)
            {
                double currentGrade = double.Parse(Console.ReadLine());
                sumGrades += currentGrade;
                if (currentGrade >= 5.00)
                {
                    topStudents++;
                }
                else if (currentGrade >= 4.00 && currentGrade <= 4.99)
                {
                    goodStudents++;
                }
                else if (currentGrade >= 3.00 && currentGrade <= 3.99)
                {
                    badStudents++;
                }
                else if (currentGrade < 3.00)
                {
                    fail++;
                }
            }
            double averageGrade = sumGrades / countStudents;
            double persentTopStudents = topStudents*1.0 / countStudents * 100;
            double persentGoodStudents = goodStudents*1.0 / countStudents * 100;
            double persentBadStudents = badStudents*1.0 / countStudents * 100;
            double persentFail = fail*1.0 / countStudents * 100;

            Console.WriteLine($"Top students: {persentTopStudents:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {persentGoodStudents:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {persentBadStudents:F2}%");
            Console.WriteLine($"Fail: {persentFail:F2}%");
            Console.WriteLine($"Average: {averageGrade:F2}");
        }
    }
}
