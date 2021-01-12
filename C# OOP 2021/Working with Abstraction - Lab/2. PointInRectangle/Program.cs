using System;
using System.Linq;

namespace _2._PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rectangleCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int countPointsToCheck = int.Parse(Console.ReadLine());

            int topLeftX = rectangleCoordinates[0];
            int topLeftY = rectangleCoordinates[1];
            int bottomRightX = rectangleCoordinates[2];
            int bottomRightY = rectangleCoordinates[3];

            Rectangle rectangle = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);

            for (int i = 0; i < countPointsToCheck; i++)
            {
                int[] currentPointCoordinates = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int currentPointX = currentPointCoordinates[0];
                int currentPointY = currentPointCoordinates[1];

                Point currentPoint = new Point(currentPointX, currentPointY);

                var output = rectangle.Contains(currentPoint);

                Console.WriteLine(output);
            }
        }
    }
}
