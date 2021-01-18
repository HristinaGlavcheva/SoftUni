using System;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Box<double> myBox = new Box<double>();

            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                double input = double.Parse(Console.ReadLine());

                myBox.Add(input);
            }

            double itemToCompareWith = double.Parse(Console.ReadLine());

            int result = myBox.CountGreaterItems(itemToCompareWith);

            Console.WriteLine(result);
        }
    }
}
