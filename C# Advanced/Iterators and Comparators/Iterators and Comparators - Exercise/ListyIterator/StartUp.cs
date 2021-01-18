using System;
using System.Collections.Generic;
using System.Linq;

namespace ListlyIterator
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            string[] data = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToArray();

            var myList = new ListlyIterator<string>(data);

            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    if (command == "Move")
                    {
                        Console.WriteLine(myList.Move());
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(myList.HasNext());
                    }
                    else if (command == "Print")
                    {
                        myList.Print();
                    }
                    else if (command == "PrintAll")
                    {
                        myList.PrintAll();
                    }
                }
                catch (Exception exeption)
                {
                    Console.WriteLine(exeption.Message);
                }

                command = Console.ReadLine();
            }
        }
    }
}
