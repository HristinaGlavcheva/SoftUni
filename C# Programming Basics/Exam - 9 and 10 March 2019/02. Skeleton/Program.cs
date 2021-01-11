using System;

namespace _02._Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlTimeMinutes = int.Parse(Console.ReadLine());
            int controlTimeSeconds = int.Parse(Console.ReadLine());
            double choutLenght = double.Parse(Console.ReadLine());
            int secondsForHundredMeters = int.Parse(Console.ReadLine());
            double reduseTime = 2.5 * (choutLenght / 120);
            double totalTime = (choutLenght / 100) * secondsForHundredMeters - reduseTime;
            double controlTimeInSeconds = controlTimeMinutes * 60 + controlTimeSeconds;

            if(controlTimeInSeconds >= totalTime)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {totalTime:F3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {(totalTime - controlTimeInSeconds):F3} second slower.");
            }
        }
    }
}
