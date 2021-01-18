using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> myBox = new Box<int>();

            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                int input = int.Parse(Console.ReadLine());

                myBox.Add(input);
            }

            Console.WriteLine(myBox);
        }
    }
}
