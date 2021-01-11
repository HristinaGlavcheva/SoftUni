using System;

namespace _02._Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double lenght = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double averageHeight = double.Parse(Console.ReadLine());

            double spaceshipVolume = width * lenght * height;
            double roomVolume = (averageHeight + 0.4) * 2 * 2;
            double numberRooms = Math.Floor(spaceshipVolume / roomVolume);

            if (numberRooms < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (numberRooms > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
            else
            {
                Console.WriteLine($"The spacecraft holds {numberRooms} astronauts.");
            }
        }
    }
}
