using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());
            double lostTime = Math.Floor(distance / 15) * 12.5;
            double ivanTime = distance * secondsPerMeter + lostTime;
            double marginTime = ivanTime - record;
            if (marginTime < 0)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {ivanTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {marginTime:F2} seconds slower.");
            }
        }
    }
}
