using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double area = a * b;
            Console.WriteLine(area); 
        }
    }
}

//Коментар - пише се, маркира се и Ctrl+k+c или // пред него (връща се с ctrl+k+u)
/* се ползва ако е 
повече от един ред
и се затваря със */
