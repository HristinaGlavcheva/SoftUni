using System;
namespace SquareOfStars
{
    class Program
    {
    static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string a = "*";
            for (int z = 1; z <= N; Console.Write(a))
                {
                z = z + 1;
                }
            Console.WriteLine();
            for (int red=2; red<=(N-1); red++)
            {
                Console.Write("*");
                for(int pos=2; pos<=(N-1);pos++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("*");
            }
            for (int last = 1; last <= N; Console.Write("*"))
                {
                last = last + 1;
                }
        }
    }
}

