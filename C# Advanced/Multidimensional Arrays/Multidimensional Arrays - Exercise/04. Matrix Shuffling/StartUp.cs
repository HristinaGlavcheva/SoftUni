using System;
using System.Linq;

namespace _04._Matrix_Shuffling
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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] curRow = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while(command[0] != "END")
            {
                if(command.Length == 5 && command[0] == "swap")
                {
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);

                    if(row1 < 0 || row1 >= rows || col1 < 0 || col1 >= cols
                        || row2 < 0 || row2 >= rows || col2 < 0 || col2 >= cols)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string firstString = matrix[row1, col1];
                        string secondString = matrix[row2, col2];

                        matrix[row1, col1] = secondString;
                        matrix[row2, col2] = firstString;

                        for (int curRow = 0; curRow < rows; curRow++)
                        {
                            for (int curCol = 0; curCol < cols; curCol++)
                            {
                                Console.Write(matrix[curRow, curCol] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
