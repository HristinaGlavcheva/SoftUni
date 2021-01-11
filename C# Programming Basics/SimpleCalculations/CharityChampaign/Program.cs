using System;

namespace CharityChampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int chefs = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int wafers = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            double income = days * chefs * (cakes * 45 + wafers * 5.80 + pancakes * 3.20);
            double outcome = income / 8;
            double profit = income - outcome;
            Console.WriteLine($"{profit:F2}");
        }
    }
}
