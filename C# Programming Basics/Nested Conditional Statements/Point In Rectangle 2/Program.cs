    using System;

    namespace Point_In_Rectangle_2
    {
        class Program
        {
            static void Main(string[] args)
            {
                double x1 = double.Parse(Console.ReadLine());
                double y1 = double.Parse(Console.ReadLine());
                double x2 = double.Parse(Console.ReadLine());
                double y2 = double.Parse(Console.ReadLine());
                double x = double.Parse(Console.ReadLine());
                double y = double.Parse(Console.ReadLine());

                bool firstCondition = (x == x1 || x == x2) && (y >= y1 && y <= y2);
                bool secondConditon= (y == y1 || y == y2) && (x >= x1 && x <= x2);

                if (firstCondition || secondConditon)
                {
                    Console.WriteLine("Border");
                }
                else
                {
                    Console.WriteLine("Inside / Outside");
                }
            }
        }
    }
