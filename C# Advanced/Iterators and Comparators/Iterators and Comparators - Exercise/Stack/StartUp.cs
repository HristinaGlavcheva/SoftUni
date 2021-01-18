using System;
using System.Linq;

namespace Stack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string commandLine = Console.ReadLine();
            Stack<int> myStack = new Stack<int>();

            while(commandLine != "END")
            {
                try
                {
                    string[] cmdArgs = commandLine
                        .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                    string command = cmdArgs[0];

                    if (command == "Push")
                    {
                        int[] numbersToPush = cmdArgs
                            .Skip(1)
                            .Select(int.Parse)
                            .ToArray();

                        foreach (var number in numbersToPush)
                        {
                            myStack.Push(number);
                        }
                    }
                    else if (command == "Pop")
                    {
                        myStack.Pop();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                commandLine = Console.ReadLine();
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
