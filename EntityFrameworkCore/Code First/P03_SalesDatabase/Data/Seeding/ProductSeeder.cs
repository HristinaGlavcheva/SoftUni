﻿using System;
using System.Collections.Generic;

using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Data.Seeding.Contracts;
using P03_SalesDatabase.IOManagement.Contracts;

namespace P03_SalesDatabase.Data.Seeding
{
    public class ProductSeeder : ISeeder
    {
        private readonly Random random;
        private readonly SalesContext dbContext;
        private readonly IWriter writer;

        public ProductSeeder(SalesContext context, Random random, IWriter writer)
        {
            this.dbContext = context;
            this.random = random;
            this.writer = writer;
        }

        public void Seed()
        {
            ICollection<Product> products = new List<Product>();
            string[] names = new[]
            {
                "CPU",
                "Motherboard",
                "GPU",
                "RAM",
                "SSD",
                "HDD",
                "CD-RW",
                "Air Cooler",
                "Water Cooler",
                "Thermopaste"
            };

            for (int i = 0; i < 50; i++)
            {
                int nameIndex = this.random.Next(names.Length);
                string currentName = names[nameIndex];
                double quantity = this.random.Next(1000);
                decimal price = this.random.Next(5000) * 1.33m;

                Product product = new Product()
                {
                    Name = currentName,
                    Quantity = quantity,
                    Price = price
                };

                products.Add(product);

                this.writer.WriteLine($"Product: (Name: {currentName} {quantity} {price}$) was added to the database!");
            }

            this.dbContext
                .Products
                .AddRange(products);
            this.dbContext.SaveChanges();
        }
    }
}
