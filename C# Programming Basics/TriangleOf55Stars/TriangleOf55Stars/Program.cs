using System;

namespace TriangleOf55Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "*";
            for (int z = 1; z <= 10; z++)
            {
                Console.WriteLine(a);
                a = a + "*";
            }
        }
    }
}
