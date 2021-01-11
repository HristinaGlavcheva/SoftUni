using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int countRows = sizes[0];
            int countCols = sizes[1];

            int[,] matrix = new int[countRows, countCols];

            int sumStarsValues = 0;

            FillingTheMatrix(countRows, countCols, matrix);

            string command = Console.ReadLine();

            while(command != "Let the Force be with you")
            {
                int[] ivoStartPosition = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int ivoPosRow = ivoStartPosition[0];
                int ivoPosCol = ivoStartPosition[1];

                int[] evilStartPosition = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilPosRow = evilStartPosition[0];
                int evilPosCol = evilStartPosition[1];

                while(evilPosRow >= 0 && evilPosCol >= 0) 
                {
                    if (evilPosRow < countRows && evilPosCol < countCols)
                    {
                        matrix[evilPosRow, evilPosCol] = 0;
                    }

                    evilPosRow--;
                    evilPosCol--;
                }

                while(ivoPosRow >= 0 && ivoPosCol < countCols)
                {
                    if(ivoPosRow < countRows && ivoPosCol >= 0)
                    {
                        sumStarsValues += matrix[ivoPosRow, ivoPosCol];
                    }

                    ivoPosRow--;
                    ivoPosCol++;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sumStarsValues);
        }


        public static void FillingTheMatrix(int countRows, int countCols, int[,] matrix)
        {
            int currentNumber = 0;

            for (int row = 0; row < countRows; row++)
            {
                for (int col = 0; col < countCols; col++)
                {
                    matrix[row, col] = currentNumber;
                    currentNumber++;
                }
            }
        }
    }
}
