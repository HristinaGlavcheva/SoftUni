using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            double result = dateModifier.CalculateDifference(firstDate, secondDate);

            Console.WriteLine(result);
        }
    }
}
