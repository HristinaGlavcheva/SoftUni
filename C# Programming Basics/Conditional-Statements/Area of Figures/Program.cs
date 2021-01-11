using System;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                double squareArea = squareSide * squareSide;
                Console.WriteLine($"{squareArea:F3}");
            }

            else if (type == "rectangle")
            {
                double lenght = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double rectangleArea = lenght * width;
                Console.WriteLine($"{rectangleArea:F3}");
            }

            else if (type == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double circleArea = Math.PI * radius * radius;
                Console.WriteLine($"{circleArea:F3}");
            }

            else if (type == "triangle")
            {
                double triangleSide = double.Parse(Console.ReadLine());
                double triangleHeight = double.Parse(Console.ReadLine());
                double triangleArea = triangleSide * triangleHeight / 2;
                Console.WriteLine($"{triangleArea:F3}");
            }
        }
    }
}
