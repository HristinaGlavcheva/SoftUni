using System;

namespace _01._Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int heihgt;

        public Rectangle(int width, int heihgt)
        {
            this.width = width;
            this.heihgt = heihgt;
        }

        public void Draw()
        {
            DrawLine(this.width, '*', '*');

            for (int i = 1; i <= heihgt - 2; i++)
            {
                DrawLine(this.width, '*', ' ');
            }

            DrawLine(this.width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            Console.Write(new string(mid, width - 2));
            Console.WriteLine(end);
        }
    }
}
