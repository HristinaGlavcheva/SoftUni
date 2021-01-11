using System;

namespace _04._Cinema_Voucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int vaucherValue = int.Parse(Console.ReadLine());
            string purchaseName = Console.ReadLine();
            int purchasePrice = 0;
            int countTickets = 0;
            int countProducts = 0;

            while (purchaseName != "End")
            {

                if (purchaseName.Length <= 8)
                {
                    purchasePrice = purchaseName[0];
                    if (purchasePrice <= vaucherValue)
                    {
                        countProducts++;
                        vaucherValue -= purchasePrice;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    purchasePrice = purchaseName[0] + purchaseName[1];
                    if (purchasePrice <= vaucherValue)
                    {
                        countTickets++;
                        vaucherValue -= purchasePrice;
                    }
                    else
                    {
                        break;
                    }
                }

                purchaseName = Console.ReadLine();
            }

            Console.WriteLine(countTickets);
            Console.WriteLine(countProducts);
        }
    }
}
