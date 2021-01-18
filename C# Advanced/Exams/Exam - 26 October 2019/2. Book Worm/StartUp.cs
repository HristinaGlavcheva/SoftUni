using System;
using System.Text;

namespace _2._Book_Worm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string initialString = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            sb.Append(initialString);

            int size = int.Parse(Console.ReadLine());
            string[,] matrix = new string[size, size];

            int currPosRow = 0;
            int currPosCol = 0;
            bool currPosFound = false;

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = currentRow[col].ToString();

                    if (!currPosFound)
                    {
                        if (matrix[row, col] == "P")
                        {
                            currPosRow = row;
                            currPosCol = col;

                            currPosFound = true;
                        }
                    }
                }
            }

            string command = Console.ReadLine();
            int newPosRow = currPosRow;
            int newPosCol = currPosCol;

            while(command != "end")
            {
                if(command == "left")
                {
                    newPosRow = currPosRow;
                    newPosCol = currPosCol - 1;
                }
                else if (command == "right")
                {
                    newPosRow = currPosRow;
                    newPosCol = currPosCol + 1;
                }
                else if (command == "up")
                {
                    newPosRow = currPosRow - 1;
                    newPosCol = currPosCol;
                }
                else if (command == "down")
                {
                    newPosRow = currPosRow + 1;
                    newPosCol = currPosCol;
                }

                Moving(sb, matrix, ref currPosRow, ref currPosCol, newPosRow, newPosCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(sb.ToString());

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
        }

        private static void Moving(StringBuilder sb, string[,] matrix, ref int currPosRow,
            ref int currPosCol, int newPosRow, int newPosCol)
        {
            if (!ValidateIndex(matrix, newPosRow, newPosCol) && sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            else
            {
                matrix[currPosRow, currPosCol] = "-";

                if (matrix[newPosRow, newPosCol] != "-")
                {
                    sb.Append(matrix[newPosRow, newPosCol]);
                }

                matrix[newPosRow, newPosCol] = "P";

                currPosRow = newPosRow;
                currPosCol = newPosCol;
            }
        }

        static bool ValidateIndex(string[,] matrix, int currPosRow, int currPosCol)
        {
            if (currPosRow >= 0 && currPosRow < matrix.GetLength(0) &&
                currPosCol >= 0 && currPosCol < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
