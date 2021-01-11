using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());
            double socialScholarship = 0;
            double excellentScolarship = 0;
            if (income < minSalary && averageSuccess > 4.50)
            {
                socialScholarship = 0.35 * minSalary;
            }
            if (averageSuccess >= 5.50)
            {
                excellentScolarship = averageSuccess * 25;
            }
            if (socialScholarship == 0 && excellentScolarship == 0)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (socialScholarship > excellentScolarship)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
            else if (socialScholarship <= excellentScolarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScolarship)} BGN");
            }

        }
    }
}
