using System;
using System.Linq;

namespace _03._Space_Station_Establishment
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            int currPositionRow = 0;
            int currPositionCol = 0;
            int starPower = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        currPositionRow = row;
                        currPositionCol = col;
                        break;
                    }
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();
                matrix[currPositionRow, currPositionCol] = '-';

                if (direction == "left")
                {
                    int newPositionRow = currPositionRow;
                    int newPositionCol = currPositionCol - 1;
                    
                    if (!ValidateIndex(newPositionRow, newPositionCol, matrix))
                    {
                        break;
                    }
                    else if (matrix[newPositionRow, newPositionCol] == 'O')
                    {
                        matrix[newPositionRow, newPositionCol] = '-';

                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'O' && (row != newPositionRow || col != newPositionCol))
                                {
                                    currPositionRow = row;
                                    currPositionCol = col;

                                    matrix[row, col] = '-';

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (matrix[newPositionRow, newPositionCol] != '-')
                        {
                            starPower += int.Parse(matrix[newPositionRow, newPositionCol].ToString());
                            matrix[newPositionRow, newPositionCol] = 'S';
                        }

                        currPositionRow = newPositionRow;
                        currPositionCol = newPositionCol;

                        if (starPower >= 50)
                        {
                            break;
                        }
                    }
                }
                else if (direction == "right")
                {
                    if (!ValidateIndex(currPositionRow, currPositionCol + 1, matrix))
                    {
                        break;
                    }
                    else if (matrix[currPositionRow, currPositionCol + 1] == 'O')
                    {
                        matrix[currPositionRow, currPositionCol + 1] = '-';

                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'O' && (row != currPositionRow || col != currPositionCol + 1))
                                {
                                    currPositionRow = row;
                                    currPositionCol = col;

                                    matrix[row, col] = '-';

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (matrix[currPositionRow, currPositionCol + 1] != '-')
                        {
                            starPower += int.Parse(matrix[currPositionRow, currPositionCol + 1].ToString());
                            matrix[currPositionRow, currPositionCol + 1] = 'S';
                        }

                        currPositionCol = currPositionCol + 1;

                        if (starPower >= 50)
                        {
                            break;
                        }
                    }
                }
                else if (direction == "up")
                {
                    if (!ValidateIndex(currPositionRow - 1, currPositionCol, matrix))
                    {
                        break;
                    }
                    else if (matrix[currPositionRow - 1, currPositionCol] == 'O')
                    {
                        matrix[currPositionRow - 1, currPositionCol] = '-';

                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'O' && (row != currPositionRow - 1 || col != currPositionCol))
                                {
                                    currPositionRow = row;
                                    currPositionCol = col;

                                    matrix[row, col] = '-';

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (matrix[currPositionRow - 1, currPositionCol] != '-')
                        {
                            starPower += int.Parse(matrix[currPositionRow - 1, currPositionCol].ToString());
                            matrix[currPositionRow - 1, currPositionCol] = 'S';
                        }

                        currPositionRow = currPositionRow - 1;

                        if (starPower >= 50)
                        {
                            break;
                        }
                    }
                }
                else if (direction == "down")
                {
                    if (!ValidateIndex(currPositionRow + 1, currPositionCol, matrix))
                    {
                        break;
                    }
                    else if (matrix[currPositionRow + 1, currPositionCol] == 'O')
                    {
                        matrix[currPositionRow + 1, currPositionCol] = '-';

                        for (int row = 0; row < size; row++)
                        {
                            for (int col = 0; col < size; col++)
                            {
                                if (matrix[row, col] == 'O' && (row != currPositionRow + 1 || col != currPositionCol))
                                {
                                    currPositionRow = row;
                                    currPositionCol = col;

                                    matrix[row, col] = '-';

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (matrix[currPositionRow + 1, currPositionCol] != '-')
                        {
                            starPower += int.Parse(matrix[currPositionRow + 1, currPositionCol].ToString());
                            matrix[currPositionRow + 1, currPositionCol] = 'S';
                        }

                        currPositionRow = currPositionRow + 1;

                        if (starPower >= 50)
                        {
                            break;
                        }
                    }
                }
            }

            if (starPower < 50)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {starPower}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static bool ValidateIndex(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
