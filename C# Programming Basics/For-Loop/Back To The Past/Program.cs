using System;

namespace Back_To_The_Past
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int finalYear = int.Parse(Console.ReadLine());
            int currentYear = 1800;

            for (int i = 1800; i <= finalYear; i++)
            {
                if (currentYear % 2 == 0)
                {
                    money -= 12000;
                }
                else
                {
                    money = money - (12000 + 50 * (18 + currentYear - 1800));
                }
                currentYear++;
            }

            if (money >=0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {money:F2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(money):F2} dollars to survive.");
            }
                
        }
    }
}
