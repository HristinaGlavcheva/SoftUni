using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int countRows = int.Parse(Console.ReadLine());

            string[] headerRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            int countCols = headerRow.Length;

            string[,] table = new string[countRows - 1, countCols];

            for (int row = 0; row < countRows - 1; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < countCols; col++)
                {
                    table[row, col] = currentRow[col];
                }
            }

            int length = table.Length;
            int length1 = table.GetLength(0);
            int length2 = table.GetLength(1);

            Console.WriteLine(length);
            Console.WriteLine(length1);
            Console.WriteLine(length2);
        }
    }
}
