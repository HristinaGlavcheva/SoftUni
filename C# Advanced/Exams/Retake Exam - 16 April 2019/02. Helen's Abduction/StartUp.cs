using System;
using System.Linq;

namespace _02._Helen_s_Abduction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int countRows = int.Parse(Console.ReadLine());

            char[] currentRow = Console.ReadLine()
                  .ToCharArray();

            int countCols = currentRow.Length;

            char[,] field = new char[countRows, countCols];

            int currPosRow = 0;
            int currPosCol = 0;
            int newPosRow = 0;
            int newPosCol = 0;
            int deadPosRow = 0;
            int deadPosCol = 0;

            for (int col = 0; col < countCols; col++)
            {
                field[0, col] = currentRow[col];

                if (field[0, col] == 'P')
                {
                    currPosRow = 0;
                    currPosCol = col;
                }
            }

            for (int row = 1; row < countRows; row++)
            {
                currentRow = Console.ReadLine()
                   .ToCharArray();

                for (int col = 0; col < countCols; col++)
                {
                    field[row, col] = currentRow[col];

                    if (field[row, col] == 'P')
                    {
                        currPosRow = row;
                        currPosCol = col;
                    }
                }
            }

            bool reachedHellen = false;
            bool isDead = false;

            while (!isDead && !reachedHellen)
            {
                string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = commandArgs[0];
                int enemyRow = int.Parse(commandArgs[1]);
                int enemyCol = int.Parse(commandArgs[2]);

                field[enemyRow, enemyCol] = 'S';

                if (direction == "up")
                {
                    if (currPosRow > 0)
                    {
                        newPosRow = currPosRow - 1;
                    }
                    else
                    {
                        newPosRow = currPosRow;
                    }

                    newPosCol = currPosCol;

                    Moving(ref energy, field, ref currPosRow, ref currPosCol, ref deadPosRow, ref deadPosCol,
                        newPosRow, newPosCol, ref reachedHellen, ref isDead, enemyRow, enemyCol);
                }
                else if (direction == "down")
                {
                    if (currPosRow < countRows - 1)
                    {
                        newPosRow = currPosRow + 1;
                    }
                    else
                    {
                        newPosRow = currPosRow;
                    }

                    newPosCol = currPosCol;

                    Moving(ref energy, field, ref currPosRow, ref currPosCol, ref deadPosRow, ref deadPosCol,
                        newPosRow, newPosCol, ref reachedHellen, ref isDead, enemyRow, enemyCol);
                }
                else if (direction == "left")
                {
                    if (currPosCol > 0)
                    {
                        newPosCol = currPosCol - 1;
                    }
                    else
                    {
                        newPosCol = currPosCol;
                    }

                    newPosRow = currPosRow;

                    Moving(ref energy, field, ref currPosRow, ref currPosCol, ref deadPosRow, ref deadPosCol,
                        newPosRow, newPosCol, ref reachedHellen, ref isDead, enemyRow, enemyCol);
                }
                else if (direction == "right")
                {
                    if (currPosCol < countCols - 1)
                    {
                        newPosCol = currPosCol + 1;
                    }
                    else
                    {
                        newPosCol = currPosCol;
                    }

                    newPosRow = currPosRow;

                    Moving(ref energy, field, ref currPosRow, ref currPosCol, ref deadPosRow, ref deadPosCol,
                        newPosRow, newPosCol, ref reachedHellen, ref isDead, enemyRow, enemyCol);
                }
            }

            if (isDead)
            {
                Console.WriteLine($"Paris died at {deadPosRow};{deadPosCol}.");
            }

            if (reachedHellen)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }

            for (int row = 0; row < countRows; row++)
            {
                for (int col = 0; col < countCols; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void Moving(ref int energy, char[,] field, ref int currPosRow, ref int currPosCol, ref int deadPosRow,
            ref int deadPosCol, int newPosRow, int newPosCol, ref bool reachedHellen, ref bool isDead, int enemyRow, int enemyCol)
        {
            energy--;

            field[currPosRow, currPosCol] = '-';

            if (field[newPosRow, newPosCol] == 'S')
            {
                energy -= 2;
            }

            if (field[newPosRow, newPosCol] == 'H')
            {
                field[newPosRow, newPosCol] = '-';
                reachedHellen = true;
            }

            if (energy <= 0 && !reachedHellen)
            {
                isDead = true;
                deadPosRow = newPosRow;
                deadPosCol = newPosCol;
                field[newPosRow, newPosCol] = 'X';
            }

            currPosRow = newPosRow;
            currPosCol = newPosCol;
        }
    }
}
