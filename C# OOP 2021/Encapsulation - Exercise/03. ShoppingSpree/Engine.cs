using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._ShoppingSpree
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> people;

        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            string[] peopleInput = ReadInput();

            CreatePeople(peopleInput);

            string[] productsInput = ReadInput();

            CreateProducts(productsInput);

            ProcessCommands();
            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }

        private void ProcessCommands()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] purchaseArgs = command
                    .Split()
                    .ToArray();

                string personName = purchaseArgs[0];
                string productName = purchaseArgs[1];

                Person person = this.people.FirstOrDefault(p => p.Name == personName);
                Product product = this.products.FirstOrDefault(p => p.Name == productName);

                try
                {
                    person.AddProductToBag(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }
        }

        private string[] ReadInput()
        {
            return Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
        }

        private void CreatePeople(string[] peopleInput)
        {
            foreach (var personInfo in peopleInput)
            {
                string[] personArgs = personInfo
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);

                Person person = new Person(name, money);
                this.people.Add(person);
            }
        }

        private void CreateProducts(string[] productsInput)
        {
            foreach (var productInfo in productsInput)
            {
                string[] productArgs = productInfo
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = productArgs[0];
                decimal cost = decimal.Parse(productArgs[1]);

                Product product = new Product(name, cost);
                this.products.Add(product);
            }
        }
    }
}

