using System;
using System.Linq;

namespace _03._Maximal_Sum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row ++)
            {
                int[] curRow = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int curSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                                + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = maxSumRow; i <= maxSumRow + 2; i++)
            {
                for (int j = maxSumCol; j <= maxSumCol + 2; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            //Console.WriteLine($"{matrix[maxSumRow, maxSumCol]} {matrix[maxSumRow, maxSumCol + 1]} {matrix[maxSumRow, maxSumCol + 2]}");
            //Console.WriteLine($"{matrix[maxSumRow + 1, maxSumCol]} {matrix[maxSumRow + 1, maxSumCol + 1]} {matrix[maxSumRow + 1, maxSumCol + 2]}");
            //Console.WriteLine($"{matrix[maxSumRow + 2, maxSumCol]} {matrix[maxSumRow + 2, maxSumCol + 1]} {matrix[maxSumRow + 2, maxSumCol + 2]}");
        }
    }
}
