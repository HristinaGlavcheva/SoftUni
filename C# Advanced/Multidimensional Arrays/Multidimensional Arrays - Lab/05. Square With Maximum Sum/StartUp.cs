using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
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

            for (int row = 0; row < rows; row++)
            {
                int[] curRow = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            int maxSum = int.MinValue;
            int maxSumRow = 0;
            int maxSumCol = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int curSum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1];

                    if(curSum > maxSum)
                    {
                        maxSum = curSum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine(matrix[maxSumRow, maxSumCol] + " " + matrix[maxSumRow, maxSumCol + 1]);
            Console.WriteLine(matrix[maxSumRow + 1, maxSumCol] + " " + matrix[maxSumRow + 1, maxSumCol + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
