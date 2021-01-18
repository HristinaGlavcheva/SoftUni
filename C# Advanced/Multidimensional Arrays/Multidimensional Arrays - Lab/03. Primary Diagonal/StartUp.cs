using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] curRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            int sumPrimaryDiagonal = 0;

            for (int row = 0; row < size; row++)
            {
                sumPrimaryDiagonal += matrix[row, row];
            }

            Console.WriteLine(sumPrimaryDiagonal);
        }
    }
}
