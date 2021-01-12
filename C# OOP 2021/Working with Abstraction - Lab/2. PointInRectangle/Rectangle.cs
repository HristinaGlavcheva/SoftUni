namespace _2._PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            this.TopLeft = new Point(topLeftX, topLeftY);
            this.BottomRight = new Point(bottomRightX, bottomRightY);
        }
        
        public Rectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            this.TopLeft = topLeftPoint;
            this.BottomRight = bottomRightPoint;
        }

        public Point TopLeft  { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            bool isInHorizontal = TopLeft.X <= point.X && BottomRight.X >= point.X;
            bool isInVertical = TopLeft.Y >= point.Y && BottomRight.Y <= point.Y;

            return isInHorizontal && isInVertical;
        }
    }
}
