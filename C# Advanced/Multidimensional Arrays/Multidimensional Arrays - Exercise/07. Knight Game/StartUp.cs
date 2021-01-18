using System;
using System.Linq;

namespace _07._Knight_Game
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            ReadingInputMatrix(size, matrix);

            int maxAccesibleKnights = 0;
            int counter = 0;
            bool isTherePossibleAttack = true;

            while (isTherePossibleAttack)
            {
                int bestRowIndex = 0;
                int bestColIndex = 0;
                maxAccesibleKnights = 0;
                isTherePossibleAttack = false;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int accesibleKnights = 0;

                            for (int curRow = row - 2; curRow <= row + 2; curRow++)
                            {
                                for (int curCol = col - 2; curCol <= col + 2; curCol++)
                                {
                                    bool isValidCell = ValidatingCellIndexes(curRow, curCol, matrix);
                                    
                                    if (isValidCell)
                                    {
                                        bool isKnight = matrix[curRow, curCol] == 'K';
                                            
                                        bool accesibleKnight = (row - 2 == curRow && col - 1 == curCol)
                                                        || (row - 2 == curRow && col + 1 == curCol)
                                                        || (row - 1 == curRow && col - 2 == curCol)
                                                        || (row - 1 == curRow && col + 2 == curCol)
                                                        || (row + 1 == curRow && col - 2 == curCol)
                                                        || (row + 1 == curRow && col + 2 == curCol)
                                                        || (row + 2 == curRow && col - 1 == curCol)
                                                        || (row + 2 == curRow && col + 1 == curCol);

                                        if (isKnight && accesibleKnight)
                                        {
                                            accesibleKnights++;
                                            isTherePossibleAttack = true;
                                        }
                                    }
                                }
                            }

                            if (accesibleKnights > maxAccesibleKnights)
                            {
                                maxAccesibleKnights = accesibleKnights;
                                bestRowIndex = row;
                                bestColIndex = col;
                            }
                        }
                    }
                }

                matrix[bestRowIndex, bestColIndex] = '0';
                counter++;
            }

            Console.WriteLine(counter - 1);
        }

        private static void ReadingInputMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                string curRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }
        }

        private static bool ValidatingCellIndexes (int row, int col, char[,] matrix)
        {
            bool isValid = false;

            if(row >= 0 && row < matrix.GetLength(0) 
                && col >= 0 && col < matrix.GetLength(1))
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
