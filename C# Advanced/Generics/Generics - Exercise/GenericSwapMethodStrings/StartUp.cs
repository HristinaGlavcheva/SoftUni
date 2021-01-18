using System;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<string> myBox = new Box<string>();

            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                string input = Console.ReadLine();

                myBox.Add(input);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];     
            int secondIndex = indexes[1];

            myBox.Swap(firstIndex, secondIndex);

            Console.WriteLine(myBox);
        }
    }
}
