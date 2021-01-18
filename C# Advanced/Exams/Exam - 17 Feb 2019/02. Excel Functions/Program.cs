using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int countRows = int.Parse(Console.ReadLine());
            int countDataRows = countRows - 1;

            string[] headerRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string[][] table = new string[countDataRows][];

            for (int row = 0; row < countDataRows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                table[row] = currentRow;
            }

            string[] commandArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandArgs[0];
            string header = commandArgs[1];

            int index = Array.IndexOf(headerRow, header);

            if (command == "hide")
            {
                List<string> headerRowToPrint = headerRow.ToList();
                headerRowToPrint.RemoveAt(index);

                Console.WriteLine(String.Join(" | ", headerRowToPrint));

                for (int row = 0; row < countDataRows; row++)
                {
                    List<string> lineToPrint = new List<string>(table[row]);

                    lineToPrint.RemoveAt(index);

                    //lineToPrint.AddRange(table[row].Take(index));
                    //lineToPrint.AddRange(table[row].Skip(index + 1));

                    Console.WriteLine(String.Join(" | ", lineToPrint));

                    //Console.WriteLine(string.Join(" | ", table[row].Where((x, i) => i != index).ToArray()));
                }
            }
            else if (command == "sort")
            {
                Console.WriteLine(String.Join(" | ", headerRow));

                table = table.OrderBy(x => x[index]).ToArray(); 

                for (int row = 0; row < countDataRows; row++)
                {
                    Console.WriteLine(String.Join(" | ", table[row]));
                }
            }
            else if (command == "filter")
            {
                string value = commandArgs[2];
                
                Console.WriteLine(String.Join(" | ", headerRow));

                table = table.Where((x, i) => x[index] == value).ToArray();

                for (int row = 0; row < table.Length; row++)
                {
                    Console.WriteLine(String.Join(" | ", table[row]));

                    //if (table[row][index] == value)
                    //{
                    //    Console.WriteLine(string.Join(" | ", table[row]));
                    //}
                }
            }
        }
    }
}
