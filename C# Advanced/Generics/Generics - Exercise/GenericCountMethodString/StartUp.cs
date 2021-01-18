using System;

namespace GenericCountMethodString
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

            string itemToCompareWith = Console.ReadLine();

            int result = myBox.CountGreaterItems(itemToCompareWith);

            Console.WriteLine(result);
        }
    }
}
