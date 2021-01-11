using System;

namespace _03._Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeSushi = Console.ReadLine();
            string nameRestaurant = Console.ReadLine();
            int countServings = int.Parse(Console.ReadLine());
            char order = char.Parse(Console.ReadLine());

            double pricePerServing = 0;

            if (typeSushi == "sashimi")
            {
                if (nameRestaurant == "Sushi Zone")
                {
                    pricePerServing = 4.99;
                }
                else if (nameRestaurant == "Sushi Time")
                {
                    pricePerServing = 5.49;
                }
                else if (nameRestaurant == "Sushi Bar")
                {
                    pricePerServing = 5.25;
                }
                else if (nameRestaurant == "Asian Pub")
                {
                    pricePerServing = 4.50;
                }
                else
                {
                    Console.WriteLine($"{nameRestaurant} is invalid restaurant!");
                }
            }

            else if (typeSushi == "maki")
            {
                if (nameRestaurant == "Sushi Zone")
                {
                    pricePerServing = 5.29;
                }
                else if (nameRestaurant == "Sushi Time")
                {
                    pricePerServing = 4.69;
                }
                else if (nameRestaurant == "Sushi Bar")
                {
                    pricePerServing = 5.55;
                }
                else if (nameRestaurant == "Asian Pub")
                {
                    pricePerServing = 4.80;
                }
                else
                {
                    Console.WriteLine($"{nameRestaurant} is invalid restaurant!");
                }
            }

            else if (typeSushi == "uramaki")
            {
                if (nameRestaurant == "Sushi Zone")
                {
                    pricePerServing = 5.99;
                }
                else if (nameRestaurant == "Sushi Time")
                {
                    pricePerServing = 4.49;
                }
                else if (nameRestaurant == "Sushi Bar")
                {
                    pricePerServing = 6.25;
                }
                else if (nameRestaurant == "Asian Pub")
                {
                    pricePerServing = 5.50;
                }
                else
                {
                    Console.WriteLine($"{nameRestaurant} is invalid restaurant!");
                }
            }

            else if (typeSushi == "temaki")
            {
                if (nameRestaurant == "Sushi Zone")
                {
                    pricePerServing = 4.29;
                }
                else if (nameRestaurant == "Sushi Time")
                {
                    pricePerServing = 5.19;
                }
                else if (nameRestaurant == "Sushi Bar")
                {
                    pricePerServing = 4.75;
                }
                else if (nameRestaurant == "Asian Pub")
                {
                    pricePerServing = 5.50;
                }
                else
                {
                    Console.WriteLine($"{nameRestaurant} is invalid restaurant!");
                }
            }

            double price = pricePerServing * countServings;

            if (order == 'Y')
            {
                price = price * 1.2;
            }

            if (price != 0)
            {
                Console.WriteLine($"Total price: {Math.Ceiling(price)} lv.");
            }
        }
    }
}
