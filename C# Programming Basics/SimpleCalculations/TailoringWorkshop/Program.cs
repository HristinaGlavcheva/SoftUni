using System;

namespace TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTables = int.Parse(Console.ReadLine());
            double lenghtOfTables = double.Parse(Console.ReadLine());
            double widthOfTables = double.Parse(Console.ReadLine());
            double lenghtPokrivka = lenghtOfTables + 0.60;
            double widthPokrivka = widthOfTables + 0.60;
            double lenghtKare = lenghtOfTables / 2;
            double areaPokrivka = lenghtPokrivka * widthPokrivka;
            double areaKare = lenghtKare * lenghtKare;
            double PriceUSD = (areaPokrivka * numberOfTables * 7 + areaKare * numberOfTables * 9);
            double PriceBGN = PriceUSD * 1.85;
            Console.WriteLine($"{PriceUSD:F2} USD");
            Console.WriteLine($"{PriceBGN:F2} BGN");
        }
    }
}
