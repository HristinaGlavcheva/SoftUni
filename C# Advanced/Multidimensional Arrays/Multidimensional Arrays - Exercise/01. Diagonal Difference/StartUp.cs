using System;
using System.Linq;

namespace _01._Diagonal_Difference
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
                    matrix[row,col] = curRow[col];
                }
            }

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if(row == col)
                    {
                        sumPrimaryDiagonal += matrix[row, col];
                    } 
                    if(col == size - row - 1)
                    {
                        sumSecondaryDiagonal += matrix[row, col];
                    }
                }
            }

            int diff = Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal);

            Console.WriteLine(diff);
        }
    }
}
