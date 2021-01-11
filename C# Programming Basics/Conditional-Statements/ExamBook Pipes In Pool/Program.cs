using System;

namespace ExamBook_Pipes_In_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int flowRatePipe1 = int.Parse(Console.ReadLine());
            int flowRatePipe2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());
            double litersPipe1 = flowRatePipe1 * hours;
            double litersPipe2 = flowRatePipe2 * hours;
            double litersTotal = litersPipe1 + litersPipe2;
            double percentTotal = Math.Truncate((litersPipe1 + litersPipe2) / volume * 100);
            double percentPipe1 = Math.Truncate(litersPipe1 / litersTotal * 100);
            double percentPipe2 = Math.Truncate(litersPipe2 / litersTotal * 100);


            if (litersTotal <= volume)
            {
                Console.WriteLine($"The pool is {percentTotal}% full. Pipe 1: {percentPipe1}%. Pipe 2: {percentPipe2}%.");
            }
            else
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {litersTotal - volume} liters.");
            }

        }
    }
}