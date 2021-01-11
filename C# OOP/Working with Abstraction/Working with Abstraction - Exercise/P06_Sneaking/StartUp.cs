using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            InitializeRoom(n);

            char[] moves = Console.ReadLine().ToCharArray();

            int[] playerPosition = new int[2];

            FindInitialPlayerPosition(playerPosition);

            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemy();

                int enemyRow;
                int enemyCol;

                for (int j = 0; j < room[playerRow].Length; j++)
                {
                    if (room[playerRow][j] != '.' && room[playerRow][j] != 'S')
                    {
                        enemyRow = playerRow;
                        enemyCol = j;
                    }
                }

                if (playerCol < enemyCol && room[enemyRow][enemyCol] == 'd' && enemyRow == playerRow)
                {
                    room[playerRow][playerCol] = 'X';

                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");

                    PrintRoom();

                    Environment.Exit(0);
                }
                else if (enemyCol < playerCol && room[enemyRow][enemyCol] == 'b' && enemyRow == playerRow)
                {
                    room[playerRow][playerCol] = 'X';

                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");

                    PrintRoom();

                    Environment.Exit(0);
                }


                room[playerRow][playerCol] = '.';

                switch (moves[i])
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                    default:
                        break;
                }

                room[playerRow][playerCol] = 'S';

                for (int j = 0; j < room[playerRow].Length; j++)
                {
                    if (room[playerRow][j] != '.' && room[playerRow][j] != 'S')
                    {
                        enemyRow = playerRow;
                        enemyCol = j;
                    }
                }

                if (room[enemyRow][enemyCol] == 'N' && playerRow == enemyRow)
                {
                    room[enemyRow][enemyCol] = 'X';

                    Console.WriteLine("Nikoladze killed!");

                    PrintRoom();

                    Environment.Exit(0);
                }
            }
        }

        private static bool IsInsideRoom(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < room.Length && targetCol >= 0 && targetCol < room[targetRow].Length;
        }

        private static void MoveEnemy()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (IsInsideRoom(row, col + 1))
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (IsInsideRoom(row, col - 1))
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void FindInitialPlayerPosition(int[] playerPosition)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }
        }

        private static void InitializeRoom(int n)
        {
            room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                room[row] = new char[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    room[row][col] = currentRow[col];
                }
            }
        }

        private static void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
