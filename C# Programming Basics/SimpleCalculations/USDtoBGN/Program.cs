using System;

namespace _01.USDtoBGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double USD = double.Parse(Console.ReadLine());
            double BGN = 1.79549 * USD;
            Console.WriteLine(Math.Round(BGN, 2));
        }
    }
}
