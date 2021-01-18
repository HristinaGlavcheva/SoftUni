using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string wordsPath = "words.txt";
            string textPath = "text.txt";
            
            string actualResultPath = "actualResult.txt";
            string expectedResultPath = "expectedResult.txt";

            string[] inputWords = File.ReadAllLines(wordsPath);
            string[] inputText = File.ReadAllText(textPath)
                .Split(new char [] {' ', '.', ',', '?', '!', '-' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> occurances = new Dictionary<string, int>();

            foreach (var word in inputWords)
            {
                occurances[word.ToLower()] = 0;
            }

            foreach (var word in inputText)
            {
                if (occurances.ContainsKey(word.ToLower()))
                {
                    occurances[word.ToLower()]++;
                }
            }

            foreach (var (word, times) in occurances)
            {
                File.AppendAllText(actualResultPath, $"{word} - {times}{Environment.NewLine}");
            }

            foreach (var (word, times) in occurances.OrderByDescending(w => w.Value))
            {
                File.AppendAllText(expectedResultPath, $"{word} - {times}{Environment.NewLine}");
            }
        }
    }
}
