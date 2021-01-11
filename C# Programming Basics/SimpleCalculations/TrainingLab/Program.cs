using System;

namespace TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double rows = Math.Floor(lenght * 100 / 120);
            double colomns = Math.Floor((width * 100 - 100) / 70);
            double seats = rows * colomns - 3;
            Console.WriteLine(seats);
        }
    }
}
