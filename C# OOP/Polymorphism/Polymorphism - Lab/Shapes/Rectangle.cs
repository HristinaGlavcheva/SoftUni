using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height 
        { 
            get { return this.height; }

            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Height must be positive number.");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get { return this.width; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be positive number.");
                }

                this.width = value;
            }
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }

        //public override string Draw()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine(DrawLine(this.Width, '*', '*'));
            
        //    for (int i = 1; i < this.Height - 1; ++i)

        //    {
        //        sb.AppendLine(DrawLine(this.Width, '*', ' '));
        //    }

        //    sb.AppendLine(DrawLine(this.Width, '*', '*'));

        //    return sb.ToString().TrimEnd();
        //}

        //private string DrawLine(int width, char end, char mid)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append(end.ToString());

        //    for (int i = 1; i < width - 1; ++i)

        //    {
        //        sb.Append(mid.ToString());
        //    }

        //    sb.Append(end.ToString());

        //    return sb.ToString().TrimEnd();
        //}

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
