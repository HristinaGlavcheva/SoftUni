using System;

namespace YardGreening
{
    class Program
    {
        static void Main(string[] args)
        {
            double sqM = double.Parse(Console.ReadLine());
            double price = sqM * 7.61;
            double discount = price * 0.18;
            Console.WriteLine($"The final price is: {(price*0.82):F2} lv.");
            Console.WriteLine($"The discount is: {discount:F2} lv.");
         }
    }
}
