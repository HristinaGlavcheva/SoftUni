namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine();

            //int lengthCheck = int.Parse(Console.ReadLine());

            int result = RemoveBooks(db);

            //IncreasePrices(db);

            Console.WriteLine(result);
        }

        //Problem 02
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var bookTitles = context
                            .Books
                            .AsEnumerable()
                            .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                            .Select(b => b.Title)
                            .OrderBy(bt => bt)
                            .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }

        //Problem 02
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenEditionBooks = context
                                        .Books
                                        .AsEnumerable()
                                        .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                                        .OrderBy(b => b.BookId)
                                        .Select(b => b.Title)
                                        .ToList();

            return String.Join(Environment.NewLine, goldenEditionBooks);
        }

        //Problem 03
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByPrice = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotReleasedIn = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksNotReleasedIn);
        }

        //Problem 05
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            //List<string> categories = input
            //    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(c => c.ToLower())
            //    .ToList();

            //List<string> titles = new List<string>();

            //foreach (var category in categories)
            //{
            //    List<string> curCategoryTitles = context
            //        .Books
            //        .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == category))
            //        .Select(b => b.Title)
            //        .ToList();

            //    titles.AddRange(curCategoryTitles);
            //}

            //return String.Join(Environment.NewLine, titles.OrderBy(t => t));

            //---------------------------------------------------------------------

            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => x.ToLower())
                                  .ToList();

            var targetBooks = context.BooksCategories
                .Where(b => categories.Contains(b.Category.Name.ToLower()))
                .OrderBy(x => x.Book.Title)
                .Select(x => x.Book.Title)
                .ToList();

            var result = new StringBuilder();

            return String.Join(Environment.NewLine, targetBooks);
        }

        //Problem 06
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var targetBooks = context
                .Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var book in targetBooks)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();

            //return String.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }

        //Problem 07
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNamesEndingIn = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authorNamesEndingIn)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitlesContaining = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower())) //Where(b => b.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookTitlesContaining);
        }

        //Problem 09
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            return String.Join(Environment.NewLine, booksByAuthor.Select(b => $"{b.Title} ({b.AuthorFullName})"));
        }

        //Problem 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToList()
                .Count();
        }

        //Problem 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authorCopies = context
                .Authors
                .Select(a => new
                {
                    AuthorFullName = a.FirstName + " " + a.LastName,
                    //BookCopies = a.Books.Sum(b => b.Copies)
                    BookCopies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();

            foreach (var a in authorCopies)
            {
                sb.AppendLine($"{a.AuthorFullName} - {a.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            //var categoryProfits = context
            //.Categories
            //.Select(c => new
            //{
            //    CategoryName = c.Name,
            //    CategoryProfit = c.CategoryBooks
            //        .Select(cb => new 
            //        {
            //            BookProfit = cb.Book.Price * cb.Book.Copies
            //        })
            //        .Sum(cb => cb.BookProfit)
            //})
            //.OrderByDescending(c => c.CategoryProfit)
            //.ThenBy(c => c.CategoryName)
            //.ToList();

            var categoryProfits = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    CategoryProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.CategoryProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            foreach (var cp in categoryProfits)
            {
                sb.AppendLine($"{cp.CategoryName} ${cp.CategoryProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var mostRecentBooksFromCategory = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    MostResentCategoryBooks = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new
                        {
                            BookTitle = cb.Book.Title,
                            BookReleaseYear = cb.Book.ReleaseDate.Value.Year
                        })
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            foreach (var c in mostRecentBooksFromCategory)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.MostResentCategoryBooks)
                {
                    sb.AppendLine($"{b.BookTitle} ({b.BookReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static void IncreasePrices(BookShopContext context)
        {
            var targetBooks = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);
            //.ToList(); // промяната се отразява в базата независимо дали има ToList() 
            //- ако в заявката има Select работим с нова проекция и промените не се отразяват в базата

            //StringBuilder sb = new StringBuilder();

            foreach (var b in targetBooks)
            {
                //sb.AppendLine($"{b.Title} -> {b.Price} -> {b.ReleaseDate.Value.Year}");
                b.Price += 5;
            }

            context.SaveChanges();
            //return sb.ToString();
        }

        //Problem 15
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context
                   .Books
                   .Where(b => b.Copies < 4200)
                   .ToList();

            context.RemoveRange(booksToRemove);
            context.SaveChanges();

            return booksToRemove.Count();
        }
    }
}
