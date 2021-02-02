using System;
using System.Linq;

namespace _04._PizzaCalories
{
    public class Engine
    {
        public void Run()
        {
            Pizza pizza = CreatePizza();
            AddToppings(pizza);
            PrintOutput(pizza);
        }

        private static void PrintOutput(Pizza pizza)
        {
            Console.WriteLine(pizza);
        }

        private void AddToppings(Pizza pizza)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                Topping topping = CreateTopping(command);

                pizza.AddTopping(topping);

                command = Console.ReadLine();
            }
        }

        private static Topping CreateTopping(string command)
        {
            string[] toppingInfo = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string toppingName = toppingInfo[1];
            int toppingWeight = int.Parse(toppingInfo[2]);

            Topping topping = new Topping(toppingName, toppingWeight);
            return topping;
        }

        private Pizza CreatePizza()
        {
            string[] pizzaInfo = ReadInput();

            string pizzaName = pizzaInfo[1];

            Dough dough = CreateDough();
            Pizza pizza = new Pizza(pizzaName, dough);
            return pizza;
        }

        private Dough CreateDough()
        {
            string[] doughInfo = ReadInput();

            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            int doughWeight = int.Parse(doughInfo[3]);

            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
            return dough;
        }

        private static string[] ReadInput()
        {
            return Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
        }
    }
}
