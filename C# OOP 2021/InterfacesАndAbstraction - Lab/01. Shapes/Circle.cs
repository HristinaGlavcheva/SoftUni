using System;

namespace _01._Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            //for (int x = 0; x <= 2 * this.radius; x++)
            //{
            //    for (int y = 0; y <= 2 * this.radius; y++)
            //    {
            //        var distance = Math.Ceiling(Math.Sqrt((radius - x) * (radius - x) + (radius - y) * (radius - y)));

            //        if (distance == radius)
            //        {
            //            Console.Write("**");
            //        }
            //        else
            //        {
            //            Console.Write("  ");
            //        }
            //    }

            //    Console.WriteLine();
            //}

            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;

            for (double y = this.radius; y >= -this.radius; --y)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;

                    if (value >= rIn * rIn && value <= rOut * rOut)

                        Console.Write("*");

                    else

                        Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
