using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_JediGalaxy
{
    public class Engine
    {
        private int[,] matrix;
        private long totalSum;

        public void Run()
        {
            int[] sizes = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int countRows = sizes[0];
            int countCols = sizes[1];

            this.InitializeMatrix(countRows, countCols);

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] playerStartPosition = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilStartPosition = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilPosRow = evilStartPosition[0];
                int evilPosCol = evilStartPosition[1];

                MoveEvil(evilPosRow, evilPosCol);

                int playerPosRow = playerStartPosition[0];
                int playerPosCol = playerStartPosition[1];

                MovePlayer(playerPosRow, playerPosCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
        }

        private void MovePlayer(int playerPosRow, int playerPosCol)
        {
            while (playerPosRow >= 0 && playerPosCol < matrix.GetLength(1))
            {
                if (IsInside(playerPosRow, playerPosCol))
                {
                    totalSum += matrix[playerPosRow, playerPosCol];
                }

                playerPosCol++;
                playerPosRow--;
            }
        }

        private void MoveEvil(int evilPosRow, int evilPosCol)
        {
            while (evilPosRow >= 0 && evilPosCol >= 0)
            {
                if (IsInside(evilPosRow, evilPosCol))
                {
                    matrix[evilPosRow, evilPosCol] = 0;
                }
                evilPosRow--;
                evilPosCol--;
            }
        }

        private bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < matrix.GetLength(0) 
                && targetCol >= 0 && targetCol < matrix.GetLength(1);
        }

        private void InitializeMatrix(int countRows, int countCols)
        {
            matrix = new int[countRows, countCols];

            int currentNumber = 0;

            for (int row = 0; row < countRows; row++)
            {
                for (int col = 0; col < countCols; col++)
                {
                    matrix[row, col] = currentNumber++;
                }
            }
        }
    }
}
