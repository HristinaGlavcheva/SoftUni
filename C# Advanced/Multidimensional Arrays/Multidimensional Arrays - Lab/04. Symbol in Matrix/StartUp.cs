using System;

namespace _04._Symbol_in_Matrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size]; 

            for (int row = 0; row < size; row++)
            {
                string curRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = curRow[col];
                }
            }

            char symbolToFind = char.Parse(Console.ReadLine());
            bool found = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if(matrix[row, col] == symbolToFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        found = true;
                        return;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }
    }
}
