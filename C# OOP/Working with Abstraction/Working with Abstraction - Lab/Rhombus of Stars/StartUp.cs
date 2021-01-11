using System;

namespace Rhombus_of_Stars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            for (int row = 1; row <= size; row++)
            {
                PrintRow(size, row);
            }

            for (int i = size- 1; i >= 1; i--)
            {
                PrintRow(size, i);
            }
        }

        private static void PrintRow(int size, int row)
        {
            for (int j = 1; j <= size - row; j++)
            {
                Console.Write(" ");
            }

            for (int j = 1; j <= row; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine();
        }
    }
}
