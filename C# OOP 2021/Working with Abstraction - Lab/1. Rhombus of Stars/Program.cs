using System;
using System.Text;

namespace _1._Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var rhombusDrawer = new RhombusAsStringDrawer();
            var rhombusAsString = rhombusDrawer.Draw(size);
            Console.WriteLine(rhombusAsString);
        }
    }
}

