using System;

namespace _06._Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int countClients = int.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int currentClient = 1; currentClient <= countClients; currentClient++)
            {
                string itemName = Console.ReadLine();
                double sum = 0;
                int countItems = 0;

                while (itemName != "Finish")
                {
                    if (itemName == "basket")
                    {
                        sum += 1.50;
                    }
                    else if (itemName == "wreath")
                    {
                        sum += 3.80;
                    }
                    else if (itemName == "chocolate bunny")
                    {
                        sum += 7.00;
                    }
                    countItems++;
                    itemName = Console.ReadLine();
                }

                if (countItems % 2 == 0)
                {
                    sum *= 0.8;
                }

                totalSum += sum;
                Console.WriteLine($"You purchased {countItems} items for {sum:F2} leva.");
            }

            Console.WriteLine($"Average bill per client is: {(totalSum/countClients):F2} leva.");
        }
    }
}
