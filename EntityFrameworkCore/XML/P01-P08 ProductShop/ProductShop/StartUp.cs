using ProductShop.Data;
using ProductShop.Datasets;
using ProductShop.Dtos.Import;
using ProductShop;
using ProductShop.Models;
using ProductShop.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using ProductShop.XMLHelper;
using ProductShop.Dtos.Export;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace ProductShop
{
    public class StartUp
    {
        private const string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //Problem 01
            //string imporUsersString = File.ReadAllText("Datasets/users.xml");
            //string resultString = ImportUsers(context, imporUsersString);

            //Problem 02
            //string imporProductsString = File.ReadAllText("Datasets/products.xml");
            //string resultString = ImportProducts(context, imporProductsString);

            //Problem 03
            //string imporCategoriesString = File.ReadAllText("Datasets/categories.xml");
            //string resultString = ImportCategories(context, imporCategoriesString);

            //Problem 04
            //string importCategoiesProductsString = File.ReadAllText("Datasets/categories-products.xml");
            //string resultString = ImportCategoryProducts(context, importCategoiesProductsString);

            //Problem 05
            //string productsInRange = GetProductsInRange(context);
            //File.WriteAllText(ResultDirectoryPath + "/products-in-range.xml", productsInRange);

            //Problem 06
            //string soldProducts = GetSoldProducts(context);
            //File.WriteAllText(ResultDirectoryPath + "/users-sold-products.xml", soldProducts);

            //Problem 07
            //string categoriesByProductsCount = GetCategoriesByProductsCount(context);
            //File.WriteAllText(ResultDirectoryPath + "/categories-by-products.xml", categoriesByProductsCount);

            //Problem 08
            //string usersWithProducts = GetUsersWithProducts(context);
            //File.WriteAllText(ResultDirectoryPath + "/users-and-products.xml", usersWithProducts);

            //Console.WriteLine(resultString);
        }

        //Problem 01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";

            //var importUsersDTOs = XMLConverter.Deserializer<ImportUsersDTO>(inputXml, rootElement);

            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportUsersDTO>), new XmlRootAttribute("Users"));
            var importUsersDTOs = (List<ImportUsersDTO>)serializer.Deserialize(new StringReader(inputXml));

            //List<User> users = new List<User>();

            //foreach (var importUserDTO in importUsersDTOs)
            //{
            //    User user = new User
            //    {
            //        FirstName = importUserDTO.FirstName,
            //        LastName = importUserDTO.LastName,
            //        Age = importUserDTO.Age
            //    };

            //    users.Add(user);
            //}

            var users = importUsersDTOs
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        //Problem 02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportProductsDTO>), new XmlRootAttribute("Products"));

            var importProductsDTOs = (List<ImportProductsDTO>)serializer.Deserialize(new StringReader(inputXml));

            //List<Product> products = new List<Product>();

            //foreach (var importProductsDTO in importProductsDTOs)
            //{
            //    var product = new Product
            //    {
            //        Name = importProductsDTO.Name,
            //        Price = importProductsDTO.Price,
            //        SellerId = importProductsDTO.SellerId,
            //        BuyerId = importProductsDTO.BuyerId
            //    };

            //    products.Add(product);
            //}

            var products = importProductsDTOs
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Problem 03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ImportCategoriesDTO>), new XmlRootAttribute("Categories"));

            var importCategoriesDTOs = (List<ImportCategoriesDTO>)serializer.Deserialize(new StringReader(inputXml));

            var categories = importCategoriesDTOs
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Problem 04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(List<ImportCategories_ProductsDTO>), new XmlRootAttribute("CategoryProducts"));
            var importCategoriesProductsDTOs = (List<ImportCategories_ProductsDTO>)serializer.Deserialize(new StringReader(inputXml));

            //var productIds = context.Products.Select(p => p.Id).ToList();
            //var categoryIds = context.Categories.Select(c => c.Id).ToList();

            //var categoriesProducts = importCategoriesProductsDTOs
            //    .Where(cp => productIds.Contains(cp.ProductId))
            //    .Where(cp => categoryIds.Contains(cp.CategoryId))
            //    .Select(cp => new CategoryProduct
            //    {
            //        CategoryId = cp.CategoryId,
            //        ProductId = cp.ProductId
            //    })
            //    .ToList();

            var categoriesProducts = importCategoriesProductsDTOs
                 .Where(i => context.Categories.Any(s => s.Id == i.CategoryId) &&
                        context.Products.Any(s => s.Id == i.ProductId))
                 .Select(cp => new CategoryProduct
                 {
                     CategoryId = cp.CategoryId,
                     ProductId = cp.ProductId
                 })
                 .ToList();

            //var categoriesProducts = new List<CategoryProduct>();

            //foreach (var cpDTO in importCategoriesProductsDTOs)
            //{
            //    bool exists = context.Products.Any(x => x.Id == cpDTO.ProductId) &&
            //                  context.Categories.Any(x => x.Id == cpDTO.CategoryId);

            //    if (exists)
            //    {
            //        var categoryProduct = new CategoryProduct
            //        {
            //            CategoryId = cpDTO.CategoryId,
            //            ProductId = cpDTO.ProductId
            //        };

            //        categoriesProducts.Add(categoryProduct);
            //    }
            //}

            context.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";
        }

        //Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";

            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductsInRangeDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToList();

            var result = XMLConverter.Serialize(products, rootElement);
            return result;

            //var serializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));

            //serializer.Serialize(File.OpenWrite("Results/products-in-range.xml"), products);

            //using (StringWriter textWriter = new StringWriter())
            //{
            //    serializer.Serialize(textWriter, products);

            //    return textWriter.ToString();
            //}
        }

        //Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            //Get all users who have at least 1 sold item. Order them by last name, then by first name. 
            //    Select the person's first and last name. For each of the sold products, select the product's name and price. 
            //    Take top 5 records.

            var products = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                //.Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUsersWithSoldProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new ExportSoldProductsDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToList();

            var result = XMLConverter.Serialize(products, rootElement);

            return result;
        }

        //Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string rootElement = "Categories";

            var categories = context
                .Categories
                .Select(c => new ExportCtegoriesByProductsDTO
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    //TotalRevenue = c.CategoryProducts.Count * c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                    //TotalRevenue = c.CategoryProducts.Select(cp => cp.Product).Sum(p => p.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var result = XMLConverter.Serialize(categories, rootElement);

            return result;
        }

        //Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";

            var users = context
                .Users
                .ToArray()
                .Where(u => u.ProductsSold.Any())
                .Select(u => new ExportUserDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportProductCountDTO
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductDTO
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToArray();

            var resultDTO = new ExportUserCountDTO
            {
                Count = context.Users.Where(u => u.ProductsSold.Any()).Count(),
                Users = users
            };

            var result = XMLConverter.Serialize(resultDTO, rootElement);

            return result;
        }
    }
}

//<Users>
//  <count>54</count>
//  <users>
//    <User>
//      <firstName>Cathee</firstName>
//      <lastName>Rallings</lastName>
//      <age>33</age>
//      <SoldProducts>
//        <count>9</count>
//        <products>
//          <Product>
//            <name>Fair Foundation SPF 15</name>
//            <price>1394.24</price>
//          </Product>
//          <Product>
//            <name>IOPE RETIGEN MOISTURE TWIN CAKE NO.21</name>
//            <price>1257.71</price>
//          </Product>
//          <Product>
//            <name>ESIKA</name>
//            <price>879.37</price>
//          </Product>
//          <Product>
//            <name>allergy eye</name>
//            <price>426.91</price>
//          </Product>
//...
//</Users>