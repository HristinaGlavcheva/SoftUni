using System;
using System.Collections.Generic;
using System.Text;

namespace _03._ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
            => this.bag.AsReadOnly();

        public void AddProductToBag(Product product)
        {
            if(this.Money < product.Cost)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.bag.Add(product);
            this.Money -= product.Cost;
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count == 0 ? "Nothing bought" : string.Join(", ", this.Bag);

            return $"{this.Name} - {productsOutput}";
        }
    }
}
