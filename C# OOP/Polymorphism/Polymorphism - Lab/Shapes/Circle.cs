using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }

            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Radius must be positive number.");
                }

                this.radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * Radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        //public override string Draw()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    double rIn = this.Radius - 0.4;

        //    double rOut = this.Radius + 0.4;

        //    for (double y = this.Radius; y >= -this.Radius; --y)
        //    {

        //        for (double x = -this.Radius; x < rOut; x += 0.5)
        //        {

        //            double value = x * x + y * y;

        //            if (value >= rIn * rIn && value <= rOut * rOut)

        //                sb.Append("*");

        //            else

        //                sb.Append(" ");
        //        }

        //        sb.AppendLine();
        //    }

        //    return sb.ToString().TrimEnd();
        //}

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
