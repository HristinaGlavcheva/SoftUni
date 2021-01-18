using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[rows][];

            InitializingJaggedArray(rows, jaggedArr);

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArr[row].Length; col++)
                    {
                        jaggedArr[row][col] *= 2;
                        jaggedArr[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int curCol = 0; curCol < jaggedArr[row].Length; curCol++)
                    {
                        jaggedArr[row][curCol] /= 2;
                    }
                    for (int curCol = 0; curCol < jaggedArr[row + 1].Length; curCol++)
                    {
                        jaggedArr[row + 1][curCol] /= 2;
                    }
                }
            }

            //По-добро решение за умножаване и делене на 2 спрямо дължините!!!
            //for (int row = 0; row < rows - 1; row++)
            //{
            //    if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
            //    {
            //        jaggedArr[row] = jaggedArr[row].Select(x => x * 2).ToArray();
            //        jaggedArr[row + 1] = jaggedArr[row + 1].Select(x => x * 2).ToArray();
            //    }
            //    else
            //    {
            //        jaggedArr[row] = jaggedArr[row].Select(x => x / 2).ToArray();
            //        jaggedArr[row + 1] = jaggedArr[row + 1].Select(x => x / 2).ToArray();
            //    }
            //}

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row >= 0 && row < rows && col >= 0 && col < jaggedArr[row].Length)
                {
                    if (command[0] == "Add")
                    {
                        jaggedArr[row][col] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jaggedArr[row][col] -= value;
                    }
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var row in jaggedArr)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }

        private static void InitializingJaggedArray(int rows, double[][] jaggedArr)
        {
            for (int row = 0; row < rows; row++)
            {
                double[] curRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jaggedArr[row] = curRow;
            }
        }
    }
}
