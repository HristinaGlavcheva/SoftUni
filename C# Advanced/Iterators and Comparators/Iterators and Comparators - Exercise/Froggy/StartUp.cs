using System;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake myLake = new Lake(inputData);

            Console.WriteLine(String.Join(", ", myLake));
        }
    }
}
