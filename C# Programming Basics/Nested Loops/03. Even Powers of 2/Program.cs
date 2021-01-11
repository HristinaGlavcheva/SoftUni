using System;

namespace _03._Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int current = 1;

            for (int power = 0; power <= number; power += 2)
            {
                Console.WriteLine(current);
                current = current *2 * 2;
            }
        }
    }
}
