using System;

namespace ExamBook_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursNeeded = int.Parse(Console.ReadLine());
            int workDays = int.Parse(Console.ReadLine());
            int overTimeEmployees = int.Parse(Console.ReadLine());

            double workHours = Math.Floor(workDays * 8 * 0.9);
            double overTimeHours = overTimeEmployees*2*workDays;
            double hoursTotal = workHours + overTimeHours;

            if (hoursTotal >= hoursNeeded)
            {
                Console.WriteLine($"Yes!{hoursTotal - hoursNeeded} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursNeeded - hoursTotal} hours needed.");
            }
        }
    }
}
