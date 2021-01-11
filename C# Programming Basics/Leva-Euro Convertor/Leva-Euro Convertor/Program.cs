using System;

namespace Leva_Euro_Convertor
{
    class Program
    {
        static void Main(string[] args)
        {
            double Leva = double.Parse(Console.ReadLine());
            double Euro = Leva / 1.95583;
            Console.WriteLine(Euro);
        }
    }
}
