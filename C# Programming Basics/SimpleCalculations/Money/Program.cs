using System;

namespace Money
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitcoin = int.Parse(Console.ReadLine());
            double cny = double.Parse(Console.ReadLine());
            double comission = double.Parse(Console.ReadLine());
            double sumBitcoins = bitcoin * 1168 / 1.95;
            double sumCNY = cny * 0.15 * 1.76/1.95;
            double totalSum = sumBitcoins + sumCNY;
            double netSum = totalSum*(100 - comission) / 100;
            Console.WriteLine(netSum);
        }
    }
}
