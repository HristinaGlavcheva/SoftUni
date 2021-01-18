using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < countStudents; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputInfo[0];
                decimal grade = decimal.Parse(inputInfo[1]);

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<decimal>();
                }

                studentsGrades[name].Add(grade);
            }

            foreach (var (student, listGrades) in studentsGrades)
            {
                Console.Write($"{student} -> ");

                foreach (var grade in listGrades)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.WriteLine($"(avg: {listGrades.Average():F2})");
            }
        }
    }
}
