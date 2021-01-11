using System;

namespace _08._Cookie_factory_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int countBatches = int.Parse(Console.ReadLine());
            string product = Console.ReadLine();

            for (int bachCounter = 1; bachCounter <= countBatches; bachCounter++)
            {
                int countMainProducts = 0;

                while (product != "Bake!")
                {

                    if (product == "flour" || product == "sugar" || product == "eggs")
                    {
                        countMainProducts++;
                    }
                    
                    product = Console.ReadLine();
                }

                while (countMainProducts < 3)
                {
                    Console.WriteLine("The batter should contain flour, eggs and sugar!");
                    product = Console.ReadLine();
                    if (product == "flour" || product == "sugar" || product == "eggs")
                    {
                        break;
                    }
                }
            }

            


        }
    }
}
