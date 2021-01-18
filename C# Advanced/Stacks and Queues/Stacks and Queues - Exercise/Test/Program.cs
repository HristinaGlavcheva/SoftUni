using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            int countOperations = int.Parse(Console.ReadLine());
            string text = String.Empty;
            Stack<string> editOperations = new Stack<string>();
            Stack<string> addedStrings = new Stack<string>();
            Stack<string> deletedStrings = new Stack<string>();

            for (int i = 0; i < countOperations; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if(cmdType == "1")
                {
                    string stringToAdd = cmdArgs[1];
                    text += stringToAdd;
                    editOperations.Push("1");
                    addedStrings.Push(stringToAdd);
                }
                else if (cmdType == "2")
                {
                    int countToDel = int.Parse(cmdArgs[1]);
                    string stringToDel = text.Substring(text.Length - countToDel);
                    text = text.Remove(text.Length - countToDel);
                    editOperations.Push("2");
                    deletedStrings.Push(stringToDel);
                }
                else if (cmdType == "3")
                {
                    int position = int.Parse(cmdArgs[1]);
                    Console.WriteLine(text[position - 1]);
                }
                else if (cmdType == "4")
                {
                    if(editOperations.Peek() == "1")
                    {
                        string lastAdded = addedStrings.Pop();
                        text = text.Remove(text.Length - lastAdded.Length);
                        editOperations.Pop();
                    }
                    else if (editOperations.Peek() == "2")
                    {
                        string lastDeleted = deletedStrings.Pop();
                        text += lastDeleted;
                        editOperations.Pop();
                    }
                }
            }
        }
    }
}
