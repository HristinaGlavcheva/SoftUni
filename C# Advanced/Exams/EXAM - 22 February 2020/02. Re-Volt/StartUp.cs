using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Re_Volt
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            int curPosRow = 0;
            int curPosCol = 0;

            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if(matrix[row, col] == 'f')
                    {
                        curPosRow = row;
                        curPosCol = col;
                    }
                }
            }

            bool won = false;

            for (int i = 0; i < countCommands; i++)
            {
                string command = Console.ReadLine();
                int newPosRow = curPosRow;
                int newPosCol = curPosCol;

                matrix[curPosRow, curPosCol] = '-';

                if (command == "up")
                {
                    newPosRow = curPosRow - 1;
                    
                    if(!ValidateIndexes(newPosRow, newPosCol, size))
                    {
                        newPosRow = size - 1;
                    }
                    
                    if(matrix[newPosRow, newPosCol] == 'F')
                    {
                        matrix[newPosRow, newPosCol] = 'f';

                        won = true;
                        break;
                    }
                    else if(matrix[newPosRow, newPosCol] == '-')
                    {
                        matrix[newPosRow, newPosCol] = 'f';
                    }
                    else if (matrix[newPosRow, newPosCol] == 'B')
                    {
                        newPosRow = newPosRow - 1;

                        if (!ValidateIndexes(newPosRow, newPosCol, size))
                        {
                            newPosRow = size - 1;
                        }

                        if (matrix[newPosRow, newPosCol] == 'F')
                        {
                            matrix[newPosRow, newPosCol] = 'f';

                            won = true;
                            break;
                        }
                    }
                    else if (matrix[newPosRow, newPosCol] == 'T')
                    {
                        if(newPosRow + 1 >= size)
                        {
                            newPosRow = 0;
                        }
                        else
                        {
                            newPosRow = newPosRow + 1;
                        }

                        matrix[newPosRow, newPosCol] = 'f';
                    }
                }

                if (command == "down")
                {
                    newPosRow = curPosRow + 1;

                    if (!ValidateIndexes(newPosRow, newPosCol, size))
                    {
                        newPosRow = 0;
                    }

                    if (matrix[newPosRow, newPosCol] == 'F')
                    {
                        matrix[newPosRow, newPosCol] = 'f';

                        won = true;
                        break;
                    }
                    else if (matrix[newPosRow, newPosCol] == '-')
                    {
                        matrix[newPosRow, newPosCol] = 'f';
                    }
                    else if (matrix[newPosRow, newPosCol] == 'B')
                    {
                        newPosRow = newPosRow + 1;

                        if (!ValidateIndexes(newPosRow, newPosCol, size))
                        {
                            newPosRow = 0;
                        }

                        if (matrix[newPosRow, newPosCol] == 'F')
                        {
                            matrix[newPosRow, newPosCol] = 'f';

                            won = true;
                            break;
                        }
                    }
                    else if (matrix[newPosRow, newPosCol] == 'T')
                    {
                        if (newPosRow - 1 < 0)
                        {
                            newPosRow = size - 1;
                        }
                        else
                        {
                            newPosRow = newPosRow - 1;
                        }

                        matrix[newPosRow, newPosCol] = 'f';
                    }
                }

                if (command == "left")
                {
                    newPosCol = curPosCol - 1;

                    if (!ValidateIndexes(newPosRow, newPosCol, size))
                    {
                        newPosCol = size - 1;
                    }

                    if (matrix[newPosRow, newPosCol] == 'F')
                    {
                        matrix[newPosRow, newPosCol] = 'f';

                        won = true;
                        break;
                    }
                    else if (matrix[newPosRow, newPosCol] == '-')
                    {
                        matrix[newPosRow, newPosCol] = 'f';
                    }
                    else if (matrix[newPosRow, newPosCol] == 'B')
                    {
                        newPosCol = newPosCol - 1;

                        if (!ValidateIndexes(newPosRow, newPosCol, size))
                        {
                            newPosCol = size - 1;
                        }

                        if (matrix[newPosRow, newPosCol] == 'F')
                        {
                            matrix[newPosRow, newPosCol] = 'f';

                            won = true;
                            break;
                        }
                    }
                    else if (matrix[newPosRow, newPosCol] == 'T')
                    {
                        if (newPosCol + 1 >= size)
                        {
                            newPosCol = 0;
                        }
                        else
                        {
                            newPosCol = newPosCol + 1;
                        }

                        matrix[newPosRow, newPosCol] = 'f';
                    }
                }

                if (command == "right")
                {
                    newPosCol = curPosCol + 1;

                    if (!ValidateIndexes(newPosRow, newPosCol, size))
                    {
                        newPosCol = 0;
                    }

                    if (matrix[newPosRow, newPosCol] == 'F')
                    {
                        matrix[newPosRow, newPosCol] = 'f';

                        won = true;
                        break;
                    }
                    else if (matrix[newPosRow, newPosCol] == '-')
                    {
                        matrix[newPosRow, newPosCol] = 'f';
                    }
                    else if (matrix[newPosRow, newPosCol] == 'B')
                    {
                        newPosCol = newPosCol + 1;

                        if (!ValidateIndexes(newPosRow, newPosCol, size))
                        {
                            newPosCol = 0;
                        }

                        if (matrix[newPosRow, newPosCol] == 'F')
                        {
                            matrix[newPosRow, newPosCol] = 'f';

                            won = true;
                            break;
                        }
                    }
                    else if (matrix[newPosRow, newPosCol] == 'T')
                    {
                        if (newPosCol - 1 <= 0)
                        {
                            newPosCol = size - 1;
                        }
                        else
                        {
                            newPosCol = newPosCol - 1;
                        }

                        matrix[newPosRow, newPosCol] = 'f';
                    }
                }

                curPosRow = newPosRow;
                curPosCol = newPosCol;
            }

            if (won)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row,col]);
                }

                Console.WriteLine();
            }
           
        }

        public static bool ValidateIndexes(int row, int col, int size)
        {
            if(row >=0 && row < size && col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }
    }
}
