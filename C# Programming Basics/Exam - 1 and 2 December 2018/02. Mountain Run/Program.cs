using System;

namespace _02._Mountain_Run
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsForOneMeter = double.Parse(Console.ReadLine());

            double timeForClimbing = distance * secondsForOneMeter;
            double timeForDelay = Math.Floor(distance / 50) * 30;
            double totalTime = timeForClimbing + timeForDelay;

            if (totalTime < record)
            {
                Console.WriteLine($"Yes! The new record is {totalTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {(totalTime - record):F2} seconds slower.");
            }
        }
    }
}
