using System;

namespace _07._Pascal_Triangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[rows][];

            for (long row = 0; row < rows; row++)
            {
                long[] curRow = new long[row + 1];

                pascalTriangle[row] = curRow;
                pascalTriangle[row][0] = 1;

                for (long col = 1; col < curRow.Length - 1; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col] +
                                                       pascalTriangle[row - 1][col - 1];
                }

                pascalTriangle[row][curRow.Length - 1] = 1;
            }

            for (long row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join(" ", pascalTriangle[row]));
            }
        }
    }
}
