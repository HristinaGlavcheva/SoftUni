using System;

namespace _01._ClassBoxData
{
    public class Box
    {
        private const double SideMinValue = 0;
        private const string InvalidSideMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Length));

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Width));

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Height));

                this.height = value;
            }
        }

        public double CalculateSurfaceArea()
        {
            double surfaceArea = 2 * (this.Length * this.Width) + this.CalculateLateralSurfaceArea();

            return surfaceArea;
        }

        public double CalculateLateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * (this.Height * this.Length + this.Height * this.Width);

            return lateralSurfaceArea;
        }

        public double CalculateVolume()
        {
            double volume = this.Length * this.Width * this.Height;

            return volume;
        }

        private void ValidateSide(double value, string sideName)
        {
            if (value <= SideMinValue)
            {
                throw new ArgumentException(string.Format(InvalidSideMessage, sideName));
            }
        }
    }
}

