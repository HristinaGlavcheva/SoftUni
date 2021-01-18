using System;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class SartUp
    {
        public static void Main(string[] args)
        {
            Box<int> myBox = new Box<int>();

            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                int input = int.Parse(Console.ReadLine());

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
