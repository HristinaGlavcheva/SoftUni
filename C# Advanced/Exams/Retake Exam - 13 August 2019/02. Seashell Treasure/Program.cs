using System;
using System.Collections.Generic;

namespace _02._Seashell_Treasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int countRows = int.Parse(Console.ReadLine());

            string[][] jaggedArray = new string[countRows][];

            for (int row = 0; row < countRows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                jaggedArray[row] = currentRow;
            }

            string[] commandArgs = Console.ReadLine().Split();

            string command = commandArgs[0];

            List<string> collectedSeashells = new List<string>();
            int stolenSeashells = 0;

            while (command != "Sunset")
            {
                int row = int.Parse(commandArgs[1]);
                int col = int.Parse(commandArgs[2]);

                if (InvalidIndex(row, col, jaggedArray))
                {
                    commandArgs = Console.ReadLine().Split();
                    command = commandArgs[0];
                    continue;
                }

                string[] currentRow = jaggedArray[row];

                if (command == "Collect")
                {
                    if(jaggedArray[row][col] != "-")
                    {
                        collectedSeashells.Add(jaggedArray[row][col]);
                        jaggedArray[row][col] = "-";
                    }
                }
                else if (command == "Steal")
                {
                    string direction = commandArgs[3];
                    
                    if (jaggedArray[row][col] != "-")
                    {
                        stolenSeashells++;
                        jaggedArray[row][col] = "-";

                        if(direction == "up")
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                if (row - i >= 0 && jaggedArray[row - i][col] != "-")
                                {
                                    stolenSeashells++;
                                    jaggedArray[row - i][col] = "-";
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                if (row + i < countRows && jaggedArray[row + i][col] != "-")
                                {
                                    stolenSeashells++;
                                    jaggedArray[row + i][col] = "-";
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                if (col - i >= 0 && jaggedArray[row][col - i] != "-")
                                {
                                    stolenSeashells++;
                                    jaggedArray[row][col - i] = "-";
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                if (col + i < jaggedArray[row].Length && jaggedArray[row][col + i] != "-")
                                {
                                    stolenSeashells++;
                                    jaggedArray[row][col + i] = "-";
                                }
                            }
                        }
                    }
                }

                commandArgs = Console.ReadLine().Split();

                command = commandArgs[0];
            }

            foreach (var rowToPrint in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", rowToPrint));
            }

            Console.Write($"Collected seashells: {collectedSeashells.Count}");

            if (collectedSeashells.Count > 0)
            {
                Console.Write(" -> ");
                Console.WriteLine(String.Join(", ", collectedSeashells));
            }
            else
            {
                Console.WriteLine();
            }

            Console.WriteLine($"Stolen seashells: {stolenSeashells}");
        }

        public static bool InvalidIndex(int row, int col, string[][] jaggedArray)
        {
            if (row >= jaggedArray.Length || col >= jaggedArray[row].Length || row < 0 || col < 0)
            {
                return true;
            }

            return false;
        }
    }
}
