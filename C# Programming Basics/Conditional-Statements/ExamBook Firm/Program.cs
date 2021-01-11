using System;

namespace ExamBook_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int hoursNeeded = int.Parse(Console.ReadLine());
            int daysTotal = int.Parse(Console.ReadLine());
            int numberEmployees = int.Parse(Console.ReadLine());

            double hoursForWork = Math.Floor(daysTotal * 0.9*10*numberEmployees);

            if (hoursForWork >= hoursNeeded)
            {
                Console.WriteLine($"Yes!{hoursForWork -hoursNeeded} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{hoursNeeded - hoursForWork} hours needed.");
            }
        }
    }
}
