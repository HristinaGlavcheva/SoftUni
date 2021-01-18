using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01._Even_Lines
{
    class StartUp
    {
        static void Main(string[] args)
        {
            

            int counter = 0;

            using (StreamReader streamReader = new StreamReader("text.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    if (counter % 2 == 0)
                    {
                        char[] charsToReplace = new char[] { '-', ',', '.', '!', '?' };

                        line = ReplaceChars(charsToReplace, '@', line);
                        line = ReverseWordsOrder(line);

                        Console.WriteLine(line);
                    }

                    counter++;
                }
            }
        }

        private static string ReverseWordsOrder(string line)
        {
            line = String.Join(" ", line.Split(" ").Reverse());
            return line;
        }

        static string ReplaceChars(char[] charsToReplace, char replacement, string str)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                if (charsToReplace.Contains(str[i]))
                {
                    sb.Append(replacement);
                }
                else
                {
                    sb.Append(str[i]);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
