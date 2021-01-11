namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cinema.DataProcessor.ExportDto;
    using Cinema.XMLHelper;
    using Data;
    using Newtonsoft.Json;
    using Remotion.Linq.Parsing.Structure.IntermediateModel;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            //var topMovies = context
            //   .Movies
            //   .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 0))
            //   .OrderByDescending(m => m.Rating)
            //   .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
            //   .Select(m => new
            //   {
            //       MovieName = m.Title,
            //       Rating = m.Rating.ToString("F2"),
            //       TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
            //       Customers = m.Projections.SelectMany(p => p.Tickets.Select(t => new
            //       {
            //           FirstName = t.Customer.FirstName,
            //           LastName = t.Customer.LastName,
            //           Balance = t.Customer.Balance.ToString("F2")
            //       })
            //           .OrderByDescending(c => c.Balance)
            //           .ThenBy(c => c.FirstName)
            //           .ThenBy(c => c.LastName))
            //       .ToList()
            //   })
            //   .Take(10)
            //   .ToList();

            var topMovies = context
               .Movies
               .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 1))
               .OrderByDescending(m => m.Rating)
               .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
               .Select(m => new
               {
                   MovieName = m.Title,
                   Rating = m.Rating.ToString("F2"),
                   TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                   Customers = m.Projections.SelectMany(p => p.Tickets.Select(t => new
                   {
                       FirstName = t.Customer.FirstName,
                       LastName = t.Customer.LastName,
                       Balance = t.Customer.Balance.ToString("F2")
                   })
                       .OrderByDescending(c => c.Balance)
                       .ThenBy(c => c.FirstName)
                       .ThenBy(c => c.LastName))
                   .ToList()
               })
               .Take(10)
               .ToList();

            var movies = context
               .Movies
               .Where(r => r.Rating >= rating && r.Projections.Any(t => t.Tickets.Count >= 1))
               .OrderByDescending(r => r.Rating)
               .ThenByDescending(p => p.Projections.Sum(t => t.Tickets.Sum(pc => pc.Price)))
               .Select(x => new
               {
                   MovieName = x.Title,
                   Rating = x.Rating.ToString("F2"),
                   TotalIncomes = x.Projections.Sum(t => t.Tickets.Sum(p => p.Price)).ToString("F2"),
                   Customers = x.Projections.SelectMany(t => t.Tickets).Select(c => new
                   {
                       FirstName = c.Customer.FirstName,
                       LastName = c.Customer.LastName,
                       Balance = c.Customer.Balance.ToString("F2"),
                   })
                       .OrderByDescending(b => b.Balance)
                       .ThenBy(f => f.FirstName)
                       .ThenBy(l => l.LastName)
                       .ToArray()
               })
               .Take(10)
               .ToArray();


            // For each movie, export its name, rating formatted to the second digit, total incomes formatted same way and customers.
            // For each customer, export its first name, last name and balance formatted to the second digit. 
            //Order the customers by balance(descending), then by first name(ascending) and last name(ascending).
            // Take first 10 records and order the movies by rating(descending), then by total incomes(descending).

            var result = JsonConvert.SerializeObject(topMovies, Formatting.Indented);
            return result;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            string rootElement = "Customers";

            //    var customers = context
            //        .Customers
            //        .Where(c => c.Age >= age)
            //        .OrderByDescending(c => c.Tickets.Select(t => t.Price).Sum())
            //        .Select(c => new ExportCustomerDTO
            //        {
            //            FirstName = c.FirstName,
            //            LastName = c.LastName,
            //            SpentMoney = c.Tickets.Select(t => t.Price).Sum().ToString("F2"),
            //            SpentTime = new DateTime(c.Tickets.Sum(t => t.Projection.Movie.Duration.Ticks)).ToString("hh\\:mm\\:ss")
            //        })
            //        .Take(10)
            //        .ToList();

            var customers = context
                .Customers
                .Where(a => a.Age >= age)
                .OrderByDescending(x => x.Tickets.Sum(p => p.Price))
                .Take(10)
                .Select(x => new ExportCustomerDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(p => p.Price).ToString("F2"),
                    SpentTime = TimeSpan.FromSeconds(
                            x.Tickets.Sum(s => s.Projection.Movie.Duration.TotalSeconds))
                        .ToString(@"hh\:mm\:ss")
                })
                .ToArray();


            // For each customer, export their first name, last name, 
            //spent money for tickets(formatted to the second digit) and spent time(in format: "hh\:mm\:ss").
            //Take first 10 records and order the result by spent money in descending order.

            string result = XMLConverter.Serialize<ExportCustomerDTO[]>(customers, rootElement);
            return result;
        }
    }
}