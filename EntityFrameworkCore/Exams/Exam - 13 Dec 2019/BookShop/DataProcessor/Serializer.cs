namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using BookShop.XML_Helper;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .OrderByDescending(ab => ab.Book.Price)
                    .Select(ab => new
                    {
                        BookName = ab.Book.Name,
                        BookPrice = ab.Book.Price.ToString("F2")
                    })
                    .ToList()
                })
                .ToList()
                .OrderByDescending(a => a.Books.Count)
                .ThenBy(a => a.AuthorName)
                .ToList();

            string json = JsonConvert.SerializeObject(authors, Formatting.Indented);
            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            string rootElement = "Books";

            var books = context
                .Books
                .Where(b => (int)b.Genre == 3 && b.PublishedOn < date) //b.Genre == Genre.Science
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn) //правим първо подредбата преди Select, за да подреждаме по DateTime, в DTO-то датата е стринг, а ние искаме да сортираме по дата, не по стринг
                .Take(10)
                .Select(b => new ExportBookDTO
                {
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = b.Pages
                })
                .ToList();

            //StringBuilder sb = new StringBuilder();
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ExportBookDTO>), new XmlRootAttribute(rootElement));
            //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(string.Empty, string.Empty);

            //using(StringWriter stringWriter = new StringWriter(sb))
            //{
            //    xmlSerializer.Serialize(stringWriter, books, namespaces);   
            //}

            //return sb.ToString().TrimEnd();

            string result = XMLConverter.Serialize(books, rootElement);
            return result;

                //Export top 10 oldest books that are published before the given date and are of type science. 
                //For each book select its name, date (in format "d") and pages. 
                //Sort them by pages in descending order and then by date in descending order.
                //NOTE: Before the orders, materialize the query(This is issue by Microsoft in InMemory database library)!!!
        }
    }
}