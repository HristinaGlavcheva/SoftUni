using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOperations = int.Parse(Console.ReadLine());
            string text = String.Empty;
            Stack<string> lastVersion = new Stack<string>();

            for (int i = 0; i < countOperations; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "1")
                {
                    string stringToAdd = cmdArgs[1];
                    lastVersion.Push(text);
                    text += stringToAdd;
                }
                else if (cmdType == "2")
                {
                    int countToDel = int.Parse(cmdArgs[1]);
                    lastVersion.Push(text);
                    text = text.Remove(text.Length - countToDel);
                }
                else if (cmdType == "3")
                {
                    int position = int.Parse(cmdArgs[1]);
                    Console.WriteLine(text[position - 1]);
                }
                else if (cmdType == "4")
                {
                    text = lastVersion.Pop();
                }
            }
        }
    }
}
