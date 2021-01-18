using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] curRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = curRow;
            }

            string[] cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = cmdArgs[0];

            while(command != "END")
            {
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if(row < 0 || row >= rows || col < 0 || col >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                else if (command == "Add")
                {
                    jaggedArray[row][col] += value;
                }
                else if (command == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }

                cmdArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                command = cmdArgs[0];
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
