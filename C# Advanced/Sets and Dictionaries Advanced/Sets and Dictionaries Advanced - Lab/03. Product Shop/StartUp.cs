using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class StartUp
    {
        public static object Dictinary { get; private set; }

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            while(input[0] != "Revision")
            {
                string shopName = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops[shopName] = new Dictionary<string, double>();
                }

                shops[shopName][product] = price;
                
                input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var (shopName, priceList) in shops.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{shopName}->");

                foreach (var (product, price) in priceList)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
