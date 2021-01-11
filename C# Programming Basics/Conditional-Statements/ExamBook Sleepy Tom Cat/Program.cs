using System;

namespace ExamBook_Sleepy_Tom_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeDays = int.Parse(Console.ReadLine());
            int workingDays = 365 - freeDays;
            int totalPlayMinutes = freeDays * 127 + workingDays * 63;
            int difference=totalPlayMinutes-30000;
            int differencePlayHours = difference / 60;
            int differencePlayMinutes = difference % 60;

            if (difference >= 0)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{differencePlayHours} hours and {differencePlayMinutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{Math.Abs(differencePlayHours)} hours and {Math.Abs(differencePlayMinutes)} minutes less for play");
            }

        }
    }
}
