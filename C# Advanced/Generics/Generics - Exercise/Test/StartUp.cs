using System;

namespace Test
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            Box<string> myBox = new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                myBox.Add(input);
            }

            Console.WriteLine(myBox);
        }
    }
}
