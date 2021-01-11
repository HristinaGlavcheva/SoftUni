using System;

namespace _06._Math_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            bool validCombinations = false;

            for (int a = 1; a <= 30; a++)
            {
                for (int b = 1; b <= 30; b++)
                {
                    for (int c = 1; c <= 30; c++)
                    {
                        if(a + b +c == key && a < b & b < c)
                        {
                            Console.WriteLine($"{a} + {b} + {c} = {key}");
                            validCombinations = true;
                        }
                        if (a * b * c == key && a > b && b > c)
                        {
                            Console.WriteLine($"{a} * {b} * {c} = {key}");
                            validCombinations = true;
                        }
                    }
                }
            }
            if (validCombinations == false)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
