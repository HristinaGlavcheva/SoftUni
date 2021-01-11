using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double L = double.Parse(Console.ReadLine());
            double W = double.Parse(Console.ReadLine());
            double A = double.Parse(Console.ReadLine());
            double hallArea = L * W;
            double benchArea = hallArea / 10;
            double freeArea = hallArea - A * A - benchArea;
            double numberOfDancers = freeArea / (7040 * 0.0001);
            Console.WriteLine(Math.Floor(numberOfDancers));
        }
    }
}
