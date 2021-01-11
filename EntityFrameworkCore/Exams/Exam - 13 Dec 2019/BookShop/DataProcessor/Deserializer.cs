namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using BookShop.XML_Helper;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            string rootElement = "Books";
            var importBookDTOs = XMLConverter.Deserializer<ImportBookDTO>(xmlString, rootElement);

            //XmlSerializer serializer = new XmlSerializer(typeof(List<ImportBookDTO>), new XmlRootAttribute("Books"));
            //var importBookDTOs = (List<ImportBookDTO>)serializer.Deserialize(new StringReader(xmlString));

            List<Book> validBooks = new List<Book>();

            foreach (var bookDTO in importBookDTOs)
            {
                if (!IsValid(bookDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime publishedOn;
                bool isDateValid = DateTime.TryParseExact
                    (bookDTO.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newBook = new Book
                {
                    Name = bookDTO.Name,
                    Genre = (Genre)bookDTO.Genre,
                    Price = bookDTO.Price,
                    Pages = bookDTO.Pages,
                    PublishedOn = publishedOn //DateTime.ParseExact(bookDTO.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                validBooks.Add(newBook);

                sb.AppendLine(string.Format(SuccessfullyImportedBook, bookDTO.Name, bookDTO.Price));
            }

            context.Books.AddRange(validBooks);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var authorsDTOs = JsonConvert.DeserializeObject<List<ImportAuthorDTO>>(jsonString);

            List<Author> authors = new List<Author>();

            foreach (var authorDTO in authorsDTOs)
            {
                if (!IsValid(authorDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (authors.Any(a => a.Email == authorDTO.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author newAuthor = new Author
                {
                    FirstName = authorDTO.FirstName,
                    LastName = authorDTO.LastName,
                    Email = authorDTO.Email,
                    Phone = authorDTO.Phone
                };

                foreach (var bookDTO in authorDTO.Books)
                {
                    if (!bookDTO.BookId.HasValue)
                    {
                        continue;
                    }

                    if (!context.Books.Any(b => b.Id == bookDTO.BookId))
                    {
                        continue;
                    }

                    //Book book = context
                    //    .Books
                    //    .FirstOrDefault(b => b.Id == bookDTO.BookId);

                    //if (book == null)
                    //{
                    //    continue;
                    //}

                    AuthorBook newAuthorBook = new AuthorBook
                    {
                        Author = newAuthor,
                        Book = context.Books.First(b => b.Id == bookDTO.BookId)
                    };

                    newAuthor.AuthorsBooks.Add(newAuthorBook);
                }

                if (newAuthor.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(newAuthor);

                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, (newAuthor.FirstName + " " + newAuthor.LastName), newAuthor.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        //    Constraints
        //⦁	If any validation errors occur(such as invalid first name, last name, email or phone), do not import any part of the entity and append an error message to the method output.
        //⦁	If an email exists, do not import the author and append and error message.
        //⦁ 
        //⦁	If an author have zero books(all books are invalid) do not import the author and append an error message to the method output.
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}