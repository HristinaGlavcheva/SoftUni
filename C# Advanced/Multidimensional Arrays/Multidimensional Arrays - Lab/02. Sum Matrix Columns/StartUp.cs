using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int curCol = 0; curCol < cols; curCol++)
            {
                int sum = 0;

                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, curCol];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
