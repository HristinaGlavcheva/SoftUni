using System;

namespace ChangeTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            double areaWidth = double.Parse(Console.ReadLine());
            double tileaWidth = double.Parse(Console.ReadLine());
            double tileLenght = double.Parse(Console.ReadLine());
            double benchWidth = double.Parse(Console.ReadLine());
            double benchLenght = double.Parse(Console.ReadLine());
            double totalArea = Math.Pow(areaWidth, 2);
            double tileArea = tileaWidth * tileLenght;
            double benchArea = benchLenght * benchWidth;
            double numberTiles = (totalArea - benchArea) / tileArea;
            double timeNeeded = numberTiles * 0.2;
            Console.WriteLine(numberTiles);
            Console.WriteLine(timeNeeded);
        }
    }
}
