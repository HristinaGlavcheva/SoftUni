using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO.Category;
using ProductShop.DTO.User;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private const string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            //InitializeMapper();

            ////Problem 01 
            //string jsonString = File.ReadAllText("../../../Datasets/users.json");
            //string result = ImportUsers(context, jsonString);

            //Problem 02
            //string jsonString = File.ReadAllText("../../../Datasets/products.json");
            //string result = ImportProducts(context, jsonString);

            ////Problem 03
            //string jsonString = File.ReadAllText("../../../Datasets/categories.json");
            //string result = ImportCategories(context, jsonString);

            //Problem 04
            //string jsonString = File.ReadAllText("Datasets/categories-products.json"); //когато в options на json файла изберем CopyAlways може да не задаваме целия релативен път
            //string result = ImportCategoryProducts(context, jsonString);

            if (!Directory.Exists(ResultDirectoryPath))
            {
                Directory.CreateDirectory(ResultDirectoryPath);
            }

            //Problem 05
            //string jsonResult = GetProductsInRange(context);
            //File.WriteAllText(ResultDirectoryPath + "/products-in-rangeDTO.json", jsonResult);

            ////Problem 07
            //string jsonResult = GetCategoriesByProductsCount(context);
            //File.WriteAllText(ResultDirectoryPath + "/categories-by-products.json", jsonResult);

            //Problem 08
            string jsonResult = GetUsersWithProducts(context);
            File.WriteAllText(ResultDirectoryPath + "/users-and-products.json", jsonResult);

            //Console.WriteLine(jsonresult);
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            //Doesn't work
            //var serializerSettings = new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //};

            // categories = JsonConvert.DeserializeObject<List<Category>>(inputJson, serializerSettings);

            var categories = JsonConvert
                .DeserializeObject<List<Category>>(inputJson)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productInRange = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .ToList();

            //вариант с DTO:
            //var productInRange = context
            //    .Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price.ToString("F2"))
            //    .Select(p => new ListProductsInRangeDTO
            //    {
            //        Name = p.Name,
            //        Price = p.Price,
            //        SellerName = p.Seller.FirstName + " " + p.Seller.LastName
            //    })
            //    .ToList();

            //вариант с Mapper:
            //var productInRange = context
            //    .Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price.ToString("F2"))
            //    .ProjectTo<ListProductsInRangeDTO>()
            //    .ToList();

            var productsInRangeJson = JsonConvert.SerializeObject(productInRange, Formatting.Indented);

            return productsInRangeJson;
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            //var users = context
            //    .Users
            //    .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            //    .OrderBy(u => u.LastName)
            //    .ThenBy(u => u.FirstName)
            //    .Select(u => new SoldProductWithBuyerInfoDTO
            //    {
            //        FirstName = u.FirstName,
            //        LastName = u.LastName,
            //        SoldProducts = u.ProductsSold
            //            .Where(p => p.Buyer != null)
            //            .Select(p => new UserSoldProductDTO
            //            {
            //                Name = p.Name,
            //                Price = p.Price,
            //                BuyerFirstName = p.Buyer.FirstName,
            //                BuyerLastName = p.Buyer.LastName
            //            })
            //            .ToList()
            //    })
            //    .ToList();

            //var users = context
            //  .Users
            //  .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            //  .OrderBy(u => u.LastName)
            //  .ThenBy(u => u.FirstName)
            //  .ProjectTo<SoldProductWithBuyerInfoDTO>()
            //  .ToList();

            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                })
                .ToList();

            var soldProductsJson = JsonConvert.SerializeObject(users, Formatting.Indented);

            return soldProductsJson;
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            //var categories = context
            //    .Categories
            //    .OrderByDescending(c => c.CategoryProducts.Count)
            //    .Select(c => new
            //    {
            //        category = c.Name,
            //        productsCount = c.CategoryProducts.Count,
            //        averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
            //        //totalRevenue = c.CategoryProducts.Sum(ct => ct.Product.Price).ToString("F2),
            //        totalRevenue = (c.CategoryProducts.Count * c.CategoryProducts.Average(cp => cp.Product.Price)).ToString("F2")
            //    })
            //    .ToList();

            //var categories = context
            //    .Categories
            //    .OrderByDescending(c => c.CategoryProducts.Count)
            //    .Select(c => new CategoriesByProductCountDTO
            //    {
            //        Category = c.Name,
            //        ProductsCount = c.CategoryProducts.Count,
            //        AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2"),
            //        //totalRevenue = c.CategoryProducts.Sum(ct => ct.Product.Price).ToString("F2),
            //        TotalRevenue = (c.CategoryProducts.Count * c.CategoryProducts.Average(cp => cp.Product.Price)).ToString("F2")
            //    })
            //    .ToList();

            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .ProjectTo<CategoriesByProductCountDTO>()
                .ToList();

            string categoriesByProductsJson = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return categoriesByProductsJson;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                            .Count(p => p.Buyer != null),   
                        products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .ToList()
                    }
                }) 
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();

            var result = new
            {
                usersCount = users.Count,
                users = users
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string jsonResult = JsonConvert.SerializeObject(result, settings);

            return jsonResult;
        }
    }
}