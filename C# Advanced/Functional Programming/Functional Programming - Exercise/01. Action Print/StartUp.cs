using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Action_Print
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x); 
            
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(print);
        }
    }
}
