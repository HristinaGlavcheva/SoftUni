using System;
using System.IO;
using System.Linq;

namespace _02._Line_Numbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string inputPath = "text.txt";
            string outputPath = "output.txt";

            string[] inputText = File.ReadAllLines(inputPath);

            int counter = 1;

            foreach (var curLine in inputText)
            {
                int lettersCount = curLine.Count(char.IsLetter);
                int punctMarksCount = curLine.Count(char.IsPunctuation);

                File.AppendAllText(outputPath, $"Line {counter}:" +
                    $" {curLine} ({lettersCount})({punctMarksCount})" +
                    $"{Environment.NewLine}");

                counter++;
            }
        }
    }
}
