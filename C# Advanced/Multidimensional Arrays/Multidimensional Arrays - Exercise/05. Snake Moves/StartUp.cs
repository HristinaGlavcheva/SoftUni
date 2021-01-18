using System;
using System.Linq;

namespace _05._Snake_Moves
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            char[,] matrix = new char[rows, cols];

            string inputString = Console.ReadLine();

            string snake = String.Empty;
            int totalCells = rows * cols;

            for (int i = 0; i < totalCells / inputString.Length; i++)
            {
                snake += inputString;
            }
            for (int i = 0; i < totalCells % inputString.Length; i++)
            {
                snake += inputString[i];
            }

            for (int row = 0; row < rows; row++)
            {
                if(row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row,col] = snake[col];
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[cols - col - 1];
                    }
                }
                snake = snake.Substring(cols);
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
