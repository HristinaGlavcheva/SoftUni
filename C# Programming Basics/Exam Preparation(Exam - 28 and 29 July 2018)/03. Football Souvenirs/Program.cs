using System;

namespace _03._Football_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string typeSuvenir = Console.ReadLine();
            int countSuvenirs = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            bool invalid = false;

            if (team == "Argentina")
            {
                if (typeSuvenir == "flags")
                {
                    totalPrice = countSuvenirs * 3.25;
                }
                else if (typeSuvenir == "caps")
                {
                    totalPrice = countSuvenirs * 7.20;
                }
                else if (typeSuvenir == "posters")
                {
                    totalPrice = countSuvenirs * 5.10;
                }
                else if (typeSuvenir == "stickers")
                {
                    totalPrice = countSuvenirs * 1.25;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    invalid = true;
                }
            }
            else if (team == "Brazil")
            {
                if (typeSuvenir == "flags")
                {
                    totalPrice = countSuvenirs * 4.20;
                }
                else if (typeSuvenir == "caps")
                {
                    totalPrice = countSuvenirs * 8.50;
                }
                else if (typeSuvenir == "posters")
                {
                    totalPrice = countSuvenirs * 5.35;
                }
                else if (typeSuvenir == "stickers")
                {
                    totalPrice = countSuvenirs * 1.20;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    invalid = true;
                }
            }
            else if (team == "Croatia")
            {
                if (typeSuvenir == "flags")
                {
                    totalPrice = countSuvenirs * 2.75;
                }
                else if (typeSuvenir == "caps")
                {
                    totalPrice = countSuvenirs * 6.90;
                }
                else if (typeSuvenir == "posters")
                {
                    totalPrice = countSuvenirs * 4.95;
                }
                else if (typeSuvenir == "stickers")
                {
                    totalPrice = countSuvenirs * 1.10;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    invalid = true;
                }
            }
            else if (team == "Denmark")
            {
                if (typeSuvenir == "flags")
                {
                    totalPrice = countSuvenirs * 3.10;
                }
                else if (typeSuvenir == "caps")
                {
                    totalPrice = countSuvenirs * 6.50;
                }
                else if (typeSuvenir == "posters")
                {
                    totalPrice = countSuvenirs * 4.80;
                }
                else if (typeSuvenir == "stickers")
                {
                    totalPrice = countSuvenirs * 0.90;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    invalid = true;
                }
            }
            else
            {
                Console.WriteLine("Invalid country!");
                invalid = true;
            }

            if (invalid == false)
            {
                Console.WriteLine($"Pepi bought {countSuvenirs} {typeSuvenir} of {team} for {totalPrice:F2} lv.");
            }
            
        }
    }
}
