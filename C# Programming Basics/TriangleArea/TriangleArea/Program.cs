using System;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double osnova = double.Parse(Console.ReadLine());
            double visochina = double.Parse(Console.ReadLine());
            Console.WriteLine ((osnova*visochina)/2);
        }
    }
}
