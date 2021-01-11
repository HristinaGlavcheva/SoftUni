using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int totalPieces = width * lenght;
            string readlineInput = "";
            int takenPieces = 0;

            while (takenPieces <= totalPieces)
            {
                readlineInput = Console.ReadLine();

                if (readlineInput == "STOP")
                {
                    break;
                }
                else
                {
                    int countPieces = int.Parse(readlineInput);
                    takenPieces += countPieces;
                }
            }

            if (totalPieces >= takenPieces)
            {
                Console.WriteLine($"{totalPieces - takenPieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {takenPieces - totalPieces} pieces more.");
            }
        }
    }
}
