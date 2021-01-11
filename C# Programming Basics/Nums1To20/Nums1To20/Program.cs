using System;

namespace Nums1To20
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfUser = int.Parse(Console.ReadLine());
            for (int number = 1; number <= numberOfUser; number++)
            {
                Console.WriteLine(number);
            }
        }
    }
}
