using System;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds1 = int.Parse(Console.ReadLine());
            int seconds2 = int.Parse(Console.ReadLine());
            int seconds3 = int.Parse(Console.ReadLine());
            int sumSeconds = seconds1 + seconds2 + seconds3;
            int minutes = sumSeconds / 60;
            int seconds = sumSeconds % 60;
            if (seconds > 9)
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
        }
    }
}
