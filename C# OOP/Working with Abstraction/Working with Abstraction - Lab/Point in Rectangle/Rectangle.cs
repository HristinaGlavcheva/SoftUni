namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }
        
        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains (Point point)
        {
            var xIsInside = this.TopLeft.X <= point.X && point.X <= this.BottomRight.X;
            var yIsInside = point.Y >= this.TopLeft.Y && this.BottomRight.Y >= point.Y;

            return xIsInside && yIsInside;
        }
    }
}
