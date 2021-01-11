using System;

namespace _03._Mobile_operator
{
    class Program
    {
        static void Main(string[] args)
        {
            string contractTerm = Console.ReadLine();
            string contractType = Console.ReadLine();
            string internet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());
            double monthPrice = 0;
            double finalPrice = 0;

            if (contractTerm == "one")
            {
                if (contractType == "Small" && internet == "no")
                {
                    monthPrice = 9.98;
                }
                else if (contractType == "Small" && internet == "yes")
                {
                    monthPrice = 9.98 + 5.50;
                }
                else if (contractType == "Middle" && internet == "no")
                {
                    monthPrice = 18.99;
                }
                else if (contractType == "Middle" && internet == "yes")
                {
                    monthPrice = 18.99 + 4.35;
                }
                else if (contractType == "Large" && internet == "no")
                {
                    monthPrice = 25.98;
                }
                else if (contractType == "Large" && internet == "yes")
                {
                    monthPrice = 25.98 + 4.35;
                }
                else if (contractType == "ExtraLarge" && internet == "no")
                {
                    monthPrice = 35.99;
                }
                else if (contractType == "ExtraLarge" && internet == "yes")
                {
                    monthPrice = 35.99 + 3.85;
                }

                finalPrice = monthPrice * months;
            }

            if (contractTerm == "two")
            {
                if (contractType == "Small")
                {
                    monthPrice = 8.58;
                }
                else if (contractType == "Middle")
                {
                    monthPrice = 17.09;
                }
                else if (contractType == "Large")
                {
                    monthPrice = 23.59;
                }
                else if (contractType == "ExtraLarge")
                {
                    monthPrice = 31.79;
                }

                if (internet == "yes")
                {
                    if (contractType == "Small")
                    {
                        monthPrice += 5.50;
                    }
                    else if (contractType == "Middle" || contractType == "Large")
                    {
                        monthPrice += 4.35;
                    }
                    else if (contractType == "ExtraLarge")
                    {
                        monthPrice += 3.85;
                    }
                }

                monthPrice *= 0.9625;
            }
            finalPrice = months * monthPrice;
            Console.WriteLine($"{finalPrice:F2} lv.");
        }
    }
}
