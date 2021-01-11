using System;

namespace _08._Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int countBatches = int.Parse(Console.ReadLine());

            for (int bachNumber = 1; bachNumber <= countBatches; bachNumber++)
            {
                string product = Console.ReadLine();
                bool flour = false;
                bool sugar = false;
                bool eggs = false;

                while (product != "Bake!" || flour == false || sugar == false || eggs == false)
                {
                    if (product == "Bake!")
                    {
                        Console.WriteLine("The batter should contain flour, eggs and sugar!");
                        product = Console.ReadLine();
                    }

                    if (product == "flour")
                    {
                        flour = true;
                    }
                    else if (product == "sugar")
                    {
                        sugar = true;
                    }
                    else if (product == "eggs")
                    {
                        eggs = true;
                    }
                    product = Console.ReadLine();        
                }

                    Console.WriteLine($"Baking batch number {bachNumber}...");
            }


        }
    }
}
