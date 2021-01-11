using System;

namespace _07._Name_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int sum = 0;
            int maxSum = 0;
            string winner = string.Empty;

            while (name != "STOP")
            {
                int lenght = name.Length;
                for (int letter = 0; letter < lenght; letter++)
                {
                    sum += name[letter];
                }

                if (sum > maxSum)
                {
                    winner = name;
                    maxSum = sum;
                }
                name = Console.ReadLine();
                sum = 0;
            }

            Console.WriteLine($"Winner is {winner}  {maxSum}!");
        }
    }
}
